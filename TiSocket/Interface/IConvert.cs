using System;
using System.Collections.Generic;
using System.Text;

namespace TiSocket.Interface
{
    public interface IConvert
    {
        byte[] Encode(byte[] src);
        byte[] Decode(byte[] src);
    }
}
