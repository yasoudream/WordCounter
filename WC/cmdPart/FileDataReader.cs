using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WC.IO
{
    public class FileDataReader
    {
        /// <summary>
        /// 通过完整路径来获得信息
        /// </summary>
        public static bool GetDataByPath(string filePath, out string data)
        {
            data = "";
            try
            {
                FileStream file = new FileStream(filePath, FileMode.Open);
                if (file == null)
                    return false;
                StreamReader sr = new StreamReader(file);
                data = sr.ReadToEnd();
            }
            catch (IOException ex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 通过文件名获得信息，文件在cmd打开路径下
        /// </summary>
        public static bool GetDataByFileName(string fileName, out string data)
        {
            return GetDataByPath(GetCurrentPath() + "\\" + fileName,out data);
        }

        /// <summary>
        /// 获得cmd处于的位置
        /// </summary>
        public static string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }

        /// <summary>
        /// 获得cmd处于的位置并合成文件路径
        /// </summary>
        public static string GetCurrentPathWithFileName(string fileName)
        {
            return Directory.GetCurrentDirectory() + "\\" + fileName;
        }

        /// <summary>
        /// 用GUI获得文件路径
        /// </summary>
        public static string GetFilePathByGUI()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Choose your file";
            open.Filter = "C Source file(*.c)|*.c|Text file(*.txt)|*.txt";
            open.Multiselect = false;
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //获取文件路径
                return open.FileName;
            }
            return null;
        }
    }
   
}
