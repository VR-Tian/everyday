using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAboutStockServer
{
    class Program
    {
        static string toIP = "172.21.197.23";
        static string fromIP = "10.1.1.221";
        // Incoming data from the client.  
        public static string data = null;
        static byte[] msg = null;
        static void Main(string[] args)
        {
            SetBufferSize();
            Console.ReadKey();
            StartListening();
        }

        private static void SetBufferSize()
        {

            IPHostEntry ipHostInfo1 = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress1 = IPAddress.Parse(toIP);// ipHostInfo1.AddressList[3];
            var ipaddress2 = IPAddress.Parse(fromIP);
            IPEndPoint localEndPoint1 = new IPEndPoint(ipAddress1, 11000);
            IPEndPoint localEndPoint2 = new IPEndPoint(ipaddress2, 11000);
            using (Socket serverSk = new Socket(ipAddress1.AddressFamily, SocketType.Dgram, ProtocolType.Udp))
            {
                byte[] msgLength = new byte[255];
                serverSk.Bind(localEndPoint1);
                EndPoint senderRemote = (EndPoint)localEndPoint2;
                Console.WriteLine("Waiting to receive fileSize from client...");
                serverSk.ReceiveFrom(msgLength, SocketFlags.None, ref senderRemote);
                msg = new byte[Convert.ToInt32(System.Text.Encoding.UTF8.GetString(msgLength))];
            }
            Console.WriteLine("to receive fileSize is success");
        }

        public static void StartListening()
        {
            #region UDP Server

            //传送文件：
            //0套接字监听
            //1获取文件的字节数据
            //2套接字发生

            string pathNew = @"C:\123\newfile.txt";



            IPHostEntry ipHostInfo1 = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress1 = IPAddress.Parse(toIP);//ipHostInfo1.AddressList[2];
            var ipaddress2 = IPAddress.Parse(fromIP);
            IPEndPoint localEndPoint1 = new IPEndPoint(ipAddress1, 11001);
            IPEndPoint localEndPoint2 = new IPEndPoint(ipaddress2, 11001);
            using (Socket serverSk = new Socket(ipAddress1.AddressFamily,
                    SocketType.Dgram, ProtocolType.Udp))
            {

                serverSk.Bind(localEndPoint1);

                Console.WriteLine("Waiting to receive datagrams from client...");

                EndPoint senderRemote = (EndPoint)localEndPoint2;
                serverSk.ReceiveFrom(msg, SocketFlags.None, ref senderRemote);

                using (StreamWriter streamW = new StreamWriter(pathNew))
                {
                    streamW.WriteLine(System.Text.Encoding.Default.GetChars(msg));
                }
                Console.WriteLine("to receive fileInfo is success");
            }

            #endregion

        }
    }
}
