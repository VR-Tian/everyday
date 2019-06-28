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
            int numb1 = 55;
            int numm2 = 30;
            decimal menoy = 480.0000m;
            var val = (numb1 / numm2) * menoy;
            Console.WriteLine(val);
            Console.ReadKey();

            //同步
            #region 20190614 同步和异步的学习
            //int i = 1;
            //while (true)
            //{
            //    FryEggs(2);
            //    Console.WriteLine("第" + i + "位的顾客鸡蛋正在准备");
            //    ToastBread(2);
            //    Console.WriteLine("第" + i + "位的顾客面包正在准备");
            //    FryBacon(3);
            //    Console.WriteLine("第" + i + "位的顾客培根正在准备");
            //    i++;
            //    Console.ReadLine();
            //}

            Console.WriteLine("开始获取资源");
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var request = WebRequest.Create("http://github.com/");
            //request.GetResponse();//发送请求   

            #region 异步
            request.BeginGetResponse(new AsyncCallback(t =>
              {
                  request.EndGetResponse(t);//发送请求
              }), null);
            #endregion
            Console.WriteLine("不等待");
            Console.ReadKey();
            #endregion

        }


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
            for (int divisor = 2; divisor < number; divisor ++)
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

        static async Task DoBreakfast()
        {

            #region 20190613 正则
            //var value = Regex.Match("我123我11", "\\d+(\\.\\d+){0,1}").Value;
            //Console.ReadKey();


            #endregion

            #region int?
            //int? number = null;
            //var temp1 = number.Value;
            //if (number > 1)
            //{
            //    Console.WriteLine(1);
            //}
            //Console.ReadKey();

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

            #region 20190317-19-40 socket

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

            #region 长度问题
            //string printStr = "Pfizer Manufacturing Deutschland GmbH，Betriebsstatte Freiburg";
            //Console.WriteLine(printStr.Length);
            Console.ReadKey();
            #endregion

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

    public class ExportHelper<T> where T: IMyExport
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
