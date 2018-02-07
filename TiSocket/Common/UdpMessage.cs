using System.Net;
using TiSocket.Interface;
using TiSocket.Packet;

namespace TiSocket.Common
{
    /// <summary>
    /// 接收到的信息
    /// </summary>
    /// <typeparam name="T">命令列举类型</typeparam>
    public class UdpMessage<T, P> : IMessage where T : struct where P : PacketBase, IPacket
    {
        public UdpServer<T> UdpServer = null;
        /// <summary>
        /// 信息源
        /// </summary>      
        public IPEndPoint RemoteEndPoint = null;
        /// <summary>
        /// 信息正文
        /// </summary>
        public P Packet = default(P);

        public MessageType MessageType { get { return MessageType.UdpMessage; } }
    }
}
