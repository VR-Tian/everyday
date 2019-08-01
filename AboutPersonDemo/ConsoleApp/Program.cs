using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 20190317-19-40 socket
            string pathSource = @"C:\Users\37770\Desktop\考试流程.txt";


            SendFileSize(pathSource);
            Console.ReadKey();
            #region UDP Client
            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPEndPoint endPoint = new IPEndPoint(hostEntry.AddressList[3], 11001);

            Socket s = new Socket(endPoint.Address.AddressFamily,
                SocketType.Dgram,
                ProtocolType.Udp);

            byte[] message = Encoding.ASCII.GetBytes("This is a test");
            //Console.WriteLine("Sending data.");
            // This call blocks. 
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
                s.SendTo(buffer, SocketFlags.None, endPoint);
                s.Close();
            }


          
            Console.ReadKey();
            return;
            #endregion




            //了解网络传输过程中涉及到的理论知识，以及.NET网络编程的使用方式
            //了解套接字与具体Http、Utp协议的关系与区别
            // Data buffer for incoming data.  
            byte[] bytes = null;

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
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    sender.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}",
                        sender.RemoteEndPoint.ToString());

                    // Encode the data string into a byte array.
                    //较大字节流
                    //var bufferOfreadfile = File.ReadAllBytes(@"C:\Program Files (x86)\VR_Work\CentOS\CentOS-7-x86_64-Minimal-1810.iso");
                    //文字字节流
                    byte[] msg = Encoding.UTF8.GetBytes("我来了");

                    // Send the data through the socket.  
                    int bytesSent = sender.Send(msg);
                    bytes = new byte[sender.ReceiveBufferSize];
                    // Receive the response from the remote device.  
                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine("Echoed test = {0}",
                        Encoding.UTF8.GetString(bytes, 0, bytesRec));

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

            #region 20190614 同步和异步的学习


            #endregion

            #region 委托
            //将函数进行参数化，把函数动态进行调用
            var toastBreadToA = new Action<int>(ToastBread);
            toastBreadToA.Invoke(1);
            Console.ReadKey();
            #endregion

            #region 20190320 关于基本类型学习
            //字节byte、比特(位)bit  = >1byte=8bit 
            //char[] chars = new char[4];
            //chars[0] = 'X';        // Character literal
            //chars[1] = '\x0058';   // Hexadecimal
            //chars[2] = (char)88;   // Cast from integral type
            //chars[3] = '\u0058';   // Unicode
            //foreach (char c in chars)
            //{
            //    Console.Write(c + " ");
            //}


            //string test = "总所周知 A B C";
            //var strToBytes = System.Text.Encoding.Unicode.GetBytes(test);
            //var bytesToStr = System.Text.Encoding.Unicode.GetString(strToBytes);
            //Console.WriteLine(bytesToStr);

            //Console.ReadKey();
            #endregion

            #region 长度问题
            //string printStr = "Pfizer Manufacturing Deutschland GmbH，Betriebsstatte Freiburg";
            //Console.WriteLine(printStr.Length);
            Console.ReadKey();
            #endregion

        }

        public static void SendFileSize(string filename)
        {
            using (var FilleStream= File.OpenRead(filename))
            {
                int numBytesToRead = (int)FilleStream.Length;
                IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
                IPEndPoint endPoint = new IPEndPoint(hostEntry.AddressList[3], 11000);

                using (Socket ssSocket = new Socket(endPoint.Address.AddressFamily,
                    SocketType.Dgram,
                    ProtocolType.Udp))
                {
                    ssSocket.SendTo(System.Text.Encoding.UTF8.GetBytes(numBytesToRead.ToString()), SocketFlags.None, endPoint);
                }
            }
        }

        //public static async Task<string> ExecuteProcAsync()
        //{
        //    await Task.Run(() =>
        //     {
        //         Console.WriteLine("开始执行第一个事件");
        //         Thread.Sleep(1000);
        //         Console.WriteLine("结束执行第一个事件");
        //         return DateTime.Now.ToString();
        //     });
        //}

        public static IEnumerable<int> PrimesInRange_Sequential(int start, int end)
        {
            List<int> primes = new List<int>();
            for (int i = start; i < end; i++)
            {
                if (IsPrime(i)) primes.Add(i);
            }
            return primes;
        }
        public static bool IsPrime(int number)
        {
            if (number == 2)
                return true;
            for (int divisor = 2; divisor < number; divisor++)
            {
                if (number % divisor == 0) return false;
            }
            return true;
        }

        public class MyWebRequest : IAsyncResult
        {
            public object AsyncState
            {
                get { throw new NotImplementedException(); }
            }

            public WaitHandle AsyncWaitHandle
            {
                get { throw new NotImplementedException(); }
            }

            public bool CompletedSynchronously
            {
                get { throw new NotImplementedException(); }
            }

            public bool IsCompleted
            {
                get { throw new NotImplementedException(); }
            }
        }

        private static void ToastBread(int v)
        {
            Task.Run(() =>
            {
                Thread.Sleep(v * 1000);
                Console.WriteLine("打开面包");
                Console.WriteLine("叮叮面包");
            });
        }

        private static void FryBacon(int v)
        {
            Task.Run(() =>
            {
                Thread.Sleep(v * 1000);
                Console.WriteLine("打开培根");
                Console.WriteLine("培根下锅");
            });
        }

        private static void FryEggs(int v)
        {
            Task.Run(() =>
            {
                Thread.Sleep(v * 1000);//模拟耗时
                Console.WriteLine("打开鸡蛋");
                Console.WriteLine("鸡蛋下锅");
            });
        }

        public static string GetFileInfo(string path)
        {
            var fileIsExistFlag = File.Exists(path);
            if (!fileIsExistFlag)
            {
                return null;
            }
            var path1 = Path.GetFileName(path);
            var path2 = Path.GetExtension(path);
            return path1;
        }
    }

    class PetOwner
    {
        public string Name { get; set; }
        public List<string> Pets { get; set; }
    }

    public class ExportHelper<T> where T : IMyExport
    {
        public static void ExportData(T Model)
        {
            var item = Model.myExportMain.Create_Time;
        }
    }

    public interface IMyExport
    {
        IMyExportMain myExportMain { get; set; }
        List<IMyExportDetail> myExportDetail { get; set; }
    }

    public interface IMyExportMain
    {
        DateTime Create_Time { get; set; }
    }

    public interface IMyExportDetail
    {
        int Age { get; set; }
    }

    public class MainInfo : IMyExportMain
    {
        public DateTime Create_Time { get; set; }
    }

    public class DetailExport : IMyExportDetail
    {
        public int Age { get; set; }
    }

    /// <summary>
    /// 实现导出类型
    /// </summary>
    public class TestModel : IMyExport
    {
        public IMyExportMain myExportMain { get; set; }
        public List<IMyExportDetail> myExportDetail { get; set; }
    }
}
