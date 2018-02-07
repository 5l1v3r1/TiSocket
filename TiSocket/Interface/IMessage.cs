using System;
using System.Collections.Generic;
using System.Text;
using TiSocket.Common;

namespace TiSocket.Interface
{
    public interface IMessage
    {
        MessageType MessageType { get; }
    }
}
