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
        // Incoming data from the client.  
        public static string data = null;
        static void Main(string[] args)
        {
            StartListening();
        }

        public static void StartListening()
        {
            #region UDP Server

            //传送文件：
            //0套接字监听
            //1获取文件的字节数据
            //2套接字发生

            string pathSource = @"C:\Users\37770\Desktop\考试流程.txt";
            string pathNew = @"C:\Users\37770\Desktop\自考\newfile.txt";

            string endPointOfIP = null;
            //if (string.IsNullOrEmpty(endPointOfIP))
            //{
            //    endPointOfIP = "172.21.197.17";
            //}
            //IPAddress ipAddress1 = IPAddress.Parse(endPointOfIP);

            IPHostEntry ipHostInfo1 = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress1 = ipHostInfo1.AddressList[3]; //
            IPEndPoint localEndPoint1 = new IPEndPoint(ipAddress1, 11000);
            using (Socket serverSk = new Socket(ipAddress1.AddressFamily,
                    SocketType.Dgram, ProtocolType.Udp))
            {

                serverSk.Bind(localEndPoint1);
                //serverSk.Listen(10);

                byte[] msg = new Byte[256];
                Console.WriteLine("Waiting to receive datagrams from client...");
                // This call blocks. 
                EndPoint senderRemote = (EndPoint)localEndPoint1;
                serverSk.ReceiveFrom(msg, SocketFlags.None, ref senderRemote);

                Console.WriteLine(msg.Length);
                Console.ReadKey();
                return;
                using (FileStream fsSource = new FileStream(pathSource, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[fsSource.Length];
                    int numBytesToRead = (int)fsSource.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        // Read may return anything from 0 to numBytesToRead.
                        int n = fsSource.Read(buffer, numBytesRead, numBytesToRead);

                        // Break when the end of the file is reached.
                        if (n == 0)
                        {
                            //numBytesToRead = 0;
                            break;
                        }

                        numBytesRead += n;
                        numBytesToRead -= n;
                    }

                    // Write the byte array to the other FileStream.
                    //using (FileStream fsNew = new FileStream(pathNew,
                    //    FileMode.Create, FileAccess.Write))
                    //{
                    //    fsNew.Write(buffer, 0, buffer.Length);
                    //}
                }

            }
           
            #endregion


            #region MSDN SocketServer Deom
            // Data buffer for incoming data.  
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.  
            // Dns.GetHostName returns the name of the   
            // host running the application.  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and   
            // listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.  
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    // Program is suspended while waiting for an incoming connection.  
                    Socket handler = listener.Accept();
                    data = null;

                    // An incoming connection needs to be processed.  
                    while (true)
                    {
                        int bytesRec = handler.Receive(bytes);
                        //File.WriteAllBytes(@"C:\Users\37770\Desktop\vpn\1.iso", bytes);

                        data += Encoding.UTF8.GetString(bytes, 0, bytesRec);
                        //if (data.IndexOf(" < EOF>") > -1)
                        //{
                        //    break;
                        //}
                        break;
                    }

                    // Show the data on the console.  
                    Console.WriteLine("Server received : {0}", data);

                    // Echo the data back to the client.  
                    byte[] msg = Encoding.UTF8.GetBytes("Server received");

                    handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                StartListening();
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read(); 
            #endregion

        }
    }
}
