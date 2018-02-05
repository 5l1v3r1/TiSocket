using System;
using System.Collections.Generic;
using System.Text;
using TiSocket.Interface;
using TiSocket.Packet;

namespace TiSocket.Common
{
    /// <summary>
    /// 接收到的信息
    /// </summary>
    /// <typeparam name="T">命令列举类型</typeparam>
    public class TcpMessage<T, P> where T : struct where P : PacketBase, IPacket
    {
        /// <summary>
        /// 信息源
        /// </summary>      
        public SimpleTcpClient<T> Socket = null;
        /// <summary>
        /// 信息正文
        /// </summary>
        public P Packet = default(P);
    }
}
