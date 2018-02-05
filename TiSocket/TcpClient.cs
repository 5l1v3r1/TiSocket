﻿using TiSocket.Interface;
using System;
using System.Net;
using TiSocket.Common;
using TiSocket.Packet;
using TiSocket.Converter;
using TiSocket;

namespace TcpLibrary
{



    public class TcpClient<T> : TcpBase<T>, IDisposable where T : struct
    {
        public delegate void MessageEventHandler(object sender, T commandType, byte[] snp);

        public event DisconnectEventHandler Disconnect;
        public event DisconnectEventHandler Connected;

        SimpleTcpClient<T> Client = null;
        public string Name;
        public string ServerAddr = string.Empty;
        public int ServerPort = 0;

        public TcpClient()
        {
            ObjectFactory.Init();
        }
        public IPEndPoint ServerInfo()
        {
            return new IPEndPoint(IPAddress.Parse((ServerAddr)), ServerPort);
        }
        public bool IsConnected { get { return Client == null ? false : Client.Socket.Connected; } }
        /// <summary>
        /// 发起连接
        /// </summary>
        /// <param name="iep"></param>
        /// <returns></returns>
        public bool Connect(IPEndPoint iep)
        {
            return Connect(iep.Address.ToString(), iep.Port);
        }

        public bool RetryConnect(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                if (Connect(ServerInfo()))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Connect(string hostName, int port)
        {
            if (Client != null)
            {
                Client.Dispose();
            }
            ServerAddr = hostName;
            ServerPort = port;
            Client = new SimpleTcpClient<T>(hostName, port);
            Client.ReceivePacket += Switch;
            Client.Disconnect += Client_Disconnect;
            if (Client.Connect())
            {
                Connected?.Invoke(this, "OK");
                return true;
            }
            else return false;
        }

        private void Client_Disconnect(object sender, string errmsg)
        {
            Disconnect?.Invoke(this, errmsg);
        }

        /// <summary>
        /// 发送数据包
        /// </summary>
        /// <param name="packet"></param>
        public void Send(MainPacket<T> packet)
        {
            Client.Send(packet);
        }

        /// <summary>
        /// 发送数据包
        /// </summary>
        /// <param name="packet"></param>
        public void Send(T commandtype, IPacket packet)
        {
            Client.Send(new MainPacket<T>(commandtype, packet));
        }

        public void Dispose()
        {
            Client.Dispose();
        }
    }
}
