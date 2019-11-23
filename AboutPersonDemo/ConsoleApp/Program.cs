using Apache.NMS.ActiveMQ.Commands;
using Common.MQ;
using ConsoleApp.WCFService;
using Newtonsoft.Json;
using Respositories;
using Respositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public interface IAmial
    {
         int Age { get; set; }
    }

    public abstract class Animal : IAmial
    {
        public abstract int Age { get; set; }
    }

    public abstract class Person : Animal
    {

        public virtual void MakeLove(int time)
        {
           
            if (this.Age < 16)
            {
                Console.WriteLine("Stop ！You just a brother");
                return;
            }
            HowMakeLove();
            Console.WriteLine("Person DoWork Speak " + time);
        }
        public abstract void HowMakeLove();
    }

    public class Japanese : Person
    {
        public override int Age
        {
            get;
            set;
        }

        public override void HowMakeLove()
        {
            Console.WriteLine("do ci do ci do do");
        }
    }

    public class Korea : Person
    {
        public override int Age
        {
            get; set;
        }

        public override void HowMakeLove()
        {
            Console.WriteLine("pa ci pa ci ci ci");
        }

        public override void MakeLove(int time)
        {
            Console.WriteLine("Korea MakeLove speak " + time);
        }
    }

    public delegate bool ControlCtrlDelegate(int CtrlType);
    class Program
    {
        [DllImport("kernel32.dll")]
        private static extern bool SetConsoleCtrlHandler(ControlCtrlDelegate HandlerRoutine, bool Add);

        static ControlCtrlDelegate newDelegate = new ControlCtrlDelegate(HandlerRoutine);

        public static bool HandlerRoutine(int CtrlType)
        {
            Console.WriteLine("控制台正在关闭");
            if (clientService != null)
            {
                clientService.OffLine();
            }
            return false;
        }




        static string ReceiveIP = "172.21.197.23";
        static string SendIP = "10.1.1.221";
        static MessageClient clientService;
        static void Main(string[] args)
        {

            #region 20191106
            //List<int> list = new List<int>() { 1, 2, 2, 3, 4, 5 };
            //var temp = list.GroupBy(t => t);
            //Console.WriteLine(temp.Count());
            //Console.ReadKey();
            //return;
            #endregion

            #region  封装(类的定义)-继承(接口、抽象类的实现)-多态(继承类和实现类的关系)
            //涉及概念：堆栈、重构、重写
            //Person japanese = new Japanese();
            //japanese.Age = 19;
            //japanese.MakeLove(10);

            //Korea korea = new Korea();
            //korea.Age = 22;
            //korea.MakeLove(20);

            //Person koreAsPerson = (Person)korea;
            //koreAsPerson.MakeLove(30);

            //Console.Read();
            //return;
            #endregion

            #region 关于linq to entity和表达树Expression的关系
            ////在.NET的linq to entity 中有两种等价写法：
            ////1、一般通过面向对象的linq写法。
            ////2、lambda是.NET框架提供的语法糖引擎，通过匿名委托的写法生成linq语句。

            //My7WDbContext dbContext = new My7WDbContext();
            //var queryEntity = dbContext.My7W.Where(x => x.Id == 1).FirstOrDefault();
            //var queryEntityOfLinq = (from my7w in dbContext.My7W
            //                         where my7w.Id == 1
            //                         select my7w).FirstOrDefault();

            //return;
            #endregion

            #region 20191025 关于DDD规约的Demo测试
            //MY7WRepository mY7WRepository = new MY7WRepository(new Respositories.EntityFramework.EntityFrameworkRepositoryContext());
            //var querySelect = mY7WRepository.DoFindAll(new Respositories.EntityFramework.UserInfo() { Name = "Tick" }).ToList();

            //Console.ReadKey();
            //return;
            #endregion

            #region 测试WCF同步数据（ActiveMQ消息队列）
            SetConsoleCtrlHandler(newDelegate, true);
            var inputValue = Console.ReadLine();
            if (bool.Parse(inputValue))
            {
                clientService = new MessageClient(x => { Console.WriteLine(x); });
            }
            Console.ReadKey();
            clientService.OffLine();
            return;
            //TestConsumer();
            #endregion


            #region 20190317-19-40 socket
            string pathSource = @"C:\123.txt";


            SendFileSize(pathSource);
            Console.ReadKey();
            SendFileInfo(pathSource);
            Console.ReadKey();
            return;
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

        public static void TestConsumer()
        {
            #region 消费
            var consumer = new ActiveMQConsumer();
            consumer.BrokerUri = @"tcp://192.168.39.92:61616/";
            //consumer.UserName = "admin";
            //consumer.Password = "admin";
            consumer.QueueName = "TestQueueName";
            consumer.MQMode = MQMode.Queue;

            consumer.OnMessageReceived = (msg) =>
            {
                var objMessage = msg as ActiveMQTextMessage;
                if (objMessage != null)
                {

                    //var DataCenterMessage = objMessage.Body as DataCenterMessage;
                    clientService.SendMsg(objMessage.Text);
                    Console.WriteLine("发送成功");
                }
                else
                {
                    Console.WriteLine(msg);
                }
            };
            consumer.Open();
            consumer.StartListen();
            #endregion
        }

        public static void TestProducer(string jsonData)
        {
            #region 发布
            var producer = new ActiveMQProducer();
            producer.BrokerUri = @"tcp://192.168.39.92:61616/";
            //producer.UserName = "admin";
            //producer.Password = "admin";
            producer.QueueName = "TestQueueName";
            producer.MQMode = MQMode.Queue;

            //var message = new DataCenterMessage()
            //{
            //    ID = 1,
            //    OrderNumber = "2"
            //};
            producer.Open();
            producer.Put(jsonData);
            producer.Close();
            #endregion
        }

        private static void SendFileInfo(string pathSource)
        {
            #region UDP Client

            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(SendIP), 11001);

            Socket s = new Socket(endPoint.Address.AddressFamily, SocketType.Dgram, ProtocolType.Udp);

            using (FileStream fsSource = new FileStream(pathSource, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[fsSource.Length];
                int numBytesToRead = (int)fsSource.Length;
                int numBytesRead = 0;
                while (numBytesToRead > 0)
                {
                    int n = fsSource.Read(buffer, numBytesRead, numBytesToRead);
                    if (n == 0)
                    {
                        break;
                    }
                    numBytesRead += n;
                    numBytesToRead -= n;
                }
                s.SendTo(buffer, SocketFlags.None, new IPEndPoint(IPAddress.Parse(ReceiveIP), 11001));
                s.Close();
                Console.WriteLine("to send fileInfo is success");
            }
            #endregion
        }

        public static void SendFileSize(string filename)
        {
            using (var FilleStream = File.OpenRead(filename))
            {
                int numBytesToRead = (int)FilleStream.Length;
                //IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(SendIP), 11000);

                using (Socket ssSocket = new Socket(endPoint.Address.AddressFamily,
                    SocketType.Dgram,
                    ProtocolType.Udp))
                {
                    ssSocket.SendTo(System.Text.Encoding.UTF8.GetBytes(numBytesToRead.ToString()), SocketFlags.None, new IPEndPoint(IPAddress.Parse(ReceiveIP), 11000));
                    Console.WriteLine("to send fileSize is success");
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
