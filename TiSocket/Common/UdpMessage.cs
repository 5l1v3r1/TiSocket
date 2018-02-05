using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TiSocket.Interface;
using TiSocket.Packet;

namespace TiSocket.Common
{
    /// <summary>
    /// 接收到的信息
    /// </summary>
    /// <typeparam name="T">命令列举类型</typeparam>
    public class UdpMessage<T, P> where T : struct where P : PacketBase, IPacket
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
    }
}
