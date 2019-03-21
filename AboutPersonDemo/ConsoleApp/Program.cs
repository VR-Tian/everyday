using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 20190320 关于基本类型学习
            //字节byte、比特(位)bit  = >1byte=8bit 
            char[] chars = new char[4];
            chars[0] = 'X';        // Character literal
            chars[1] = '\x0058';   // Hexadecimal
            chars[2] = (char)88;   // Cast from integral type
            chars[3] = '\u0058';   // Unicode
            foreach (char c in chars)
            {
                Console.Write(c + " ");
            }


            string test = "总所周知 A B C";
            var strToBytes = System.Text.Encoding.Unicode.GetBytes(test);
            var bytesToStr = System.Text.Encoding.Unicode.GetString(strToBytes);
            Console.WriteLine(bytesToStr);
            
            Console.ReadKey();
            #endregion

            #region 20190317-19-40 socket

            //了解网络传输过程中涉及到的理论知识，以及.NET网络编程的使用方式
            //了解套接字与具体Http、Utp协议的关系与区别
            // Data buffer for incoming data.  
            byte[] bytes = new byte[1024];

            // Connect to a remote device.  
            try
            {
                // Establish the remote endpoint for the socket.  
                // This example uses port 11000 on the local computer.  
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP  socket.  
                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Raw, ProtocolType.Raw);

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    sender.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}",
                        sender.RemoteEndPoint.ToString());

                    // Encode the data string into a byte array.  
                    byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");

                    // Send the data through the socket.  
                    int bytesSent = sender.Send(msg);

                    // Receive the response from the remote device.  
                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine("Echoed test = {0}",
                        Encoding.ASCII.GetString(bytes, 0, bytesRec));

                    // Release the socket.  
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }


            #endregion

            #region 长度问题
            string printStr = "Pfizer Manufacturing Deutschland GmbH，Betriebsstatte Freiburg";
            Console.WriteLine(printStr.Length);
            Console.ReadKey();
            #endregion
        }
    }
}
