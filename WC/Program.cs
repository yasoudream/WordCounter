using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using WC.Counter;
using WC.Counter.Functions;
using WC.IO;
using System.IO;


namespace WC
{
    class Program
    {
        //[STAThread]
        //static void Main(string[] args)
        //{
        //    OpenFileDialog open = new OpenFileDialog();
        //    open.Title = "Choose your text";
        //    open.Filter = "C Source file(*.c)|*.c";
        //    open.Multiselect = true;
        //    if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        //获取文件路径
        //        string[] filePath = open.FileNames;
        //        foreach (string s in filePath)
        //        {
        //            Console.WriteLine(s);
        //        }            
        //        Console.ReadKey();
        //    }
        //}
        //static void Main(string[] args)
        //{
        //    WordCounter wc = new WordCounter();
        //    wc.AddFunction(LettersCount.Instance);
        //    wc.AddFunction(new WordCount());
        //    wc.AddFunction(LineCount.Instance);
        //    wc.SetString("在吗? 你好啊\n hello world\n");
        //    Console.Write(wc.GetAllLogs());
        //    Console.WriteLine(Directory.GetCurrentDirectory());
        //    Console.ReadKey();
        //}
        [STAThread]
        static void Main(string[] args)
        {
            //没有命令无法执行
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("No commond !");
                return;
            }

            //args = new string[] { "-x", "-c", "-l" };

            //获取指令蕴含信息
            CommondInfo info = CommondReader.GetInfo(args);

            //错误处理
            if (info.isError)
            {
                ErrorHanding(info.errorType);
                return;
            }

            //生成计数器
            WordCounter counter = new WordCounter();
            counter.AddFunction(info.funcs);
            string data;
            //获取信息
            if (!FileDataReader.GetDataByPath(info.filePath, out data))
            {
                Console.WriteLine("Open file failed !");
                return;
            }
            //设置信息并进行计数
            counter.SetString(data);
            //输出
            Console.WriteLine(counter.GetAllLogs());

            //Console.ReadKey();
        }

        /// <summary>
        /// 错误处理集合
        /// </summary>
        private static void ErrorHanding(CommondInfo.ErrorType type)
        {
            switch (type)
            {
                case CommondInfo.ErrorType.FileNotChosen:
                    Console.WriteLine("Didn't choose a file !");
                    break;

                case CommondInfo.ErrorType.FileError:
                    Console.WriteLine("File not found , file type not supported !");
                    break;
                case CommondInfo.ErrorType.CommondError:
                    Console.WriteLine("Commond error !");
                    break;
            }
            return;
        }
    }
}
