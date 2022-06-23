using System;
using System.Net.Sockets;

namespace BuildserverMonitor
{
    public class SocketPacket
    {
        #region Fields

        private Socket m_socket;
        private Int32 m_id;
        private Byte[] m_data;

        #endregion


        public SocketPacket(Socket socket, Int32 clientNumber)
        {
            m_socket = socket;
            m_id = clientNumber;
            m_data = new Byte[1024];
        }

        public Socket Socket
        {
            get { return m_socket; }
            set { m_socket = value; }
        }

        public Int32 ID
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public Byte[] Data
        {
            get { return m_data; }
            set { m_data = value; }
        }
    }
}
