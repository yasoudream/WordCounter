using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using WC.Counter;
using WC.Counter.Functions;


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
        static void Main(string[] args)
        {
            WordCounter wc = new WordCounter();
            wc.AddFunction(LettersCount.Instance);
            wc.AddFunction(new WordCount());
            wc.AddFunction(LineCount.Instance);
            wc.SetString("在吗? 你好啊\n hello world\n");
            Console.Write(wc.GetAllLogs());
            Console.ReadKey();
        }
    }
}
