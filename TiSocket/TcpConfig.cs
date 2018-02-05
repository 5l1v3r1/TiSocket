using TiSocket.Converter;
using TiSocket.Interface;

namespace TiSocket
{
    public static class TcpConfig
    {
        public static IConvert Convert = new DefaultConvert();
        public static int ServerMaxClient = 70000;
    }
}
