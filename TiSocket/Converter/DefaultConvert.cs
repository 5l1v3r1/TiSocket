using System;
using System.Collections.Generic;
using System.Text;
using TiSocket.Interface;

namespace TiSocket.Converter
{
    public class DefaultConvert : IConvert
    {
        public byte[] Decode(byte[] src)
        {
            return src;
        }
        public byte[] Encode(byte[] src)
        {
            return src;
        }
    }
}
