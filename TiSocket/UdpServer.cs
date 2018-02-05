using System;
using System.Net;
using System.Net.Sockets;
using TiSocket.Common;
using TiSocket.Converter;
using TiSocket.Interface;
using TiSocket.Packet;

namespace TiSocket
{
    public class UdpServer<T> : UdpBase<T>, IDisposable where T : struct
    {
        private UdpClient udpClient = null;
        public int Port = int.MinValue;
        public IConvert Convert;
        public UdpServer(int port)
        {
            Convert = new DefaultConvert();
            ObjectFactory.Init();
            Port = port;
        }
        public void Start()
        {
            udpClient = new UdpClient(Port);
            udpClient.AllowNatTraversal(true);
            udpClient.BeginReceive(Receive_Callback, udpClient);
        }
        private void Receive_Callback(IAsyncResult ar)
        {
            var uc = ar.AsyncState as UdpClient;
            var remoteEP = new IPEndPoint(1, 1);
            var receveBytes = uc.EndReceive(ar, ref remoteEP);
            try
            {
                MainPacket<T> mp = new MainPacket<T>();
                PacketHelper.CreatePacketFromBytes(receveBytes, ref mp);
                Switch(this, remoteEP, mp);
            }
            catch (Exception)
            {
                throw;
            }
            uc.BeginReceive(Receive_Callback, uc);
        }
        public void Send(IPEndPoint remoteEP, MainPacket<T> packet)
        {
            packet.Data = Convert.Encode(packet.Data);
            var sendBytes = packet.GetBytes();
            udpClient.Send(sendBytes, sendBytes.Length, remoteEP);
        }
        public void Dispose()
        {
            udpClient.Close();
            udpClient.Dispose();
        }
    }
}
