using System;
using System.Collections.Generic;
using System.Text;

namespace TiSocket.Interface
{
    public interface IPacket
    {
        byte[] GetBytes();
    }
}
