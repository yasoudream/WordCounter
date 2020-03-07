using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.Counter;
using System.IO;
using WC.Counter.Functions;

namespace WC.IO
{
    /// <summary>
    /// 命令蕴含信息
    /// </summary>
    public struct CommondInfo
    {
        public bool isError;    //是否是错误信息
        public enum ErrorType { FileError, CommondError, FileNotChosen}
        public ErrorType errorType; //错误的类型
        public List<WordCounterFunction> funcs;    //命令指定的功能
        public string filePath;  //文件地址
        public void SetError(ErrorType type)
        {
            isError = true;
            errorType = type;
        }

    }

    public class CommondReader
    {
        public static CommondInfo GetInfo(string[] commond)
        {
            CommondInfo info = new CommondInfo();
            info.funcs = new List<WordCounterFunction>();
            info.isError = false;
            int funcIndex = 0;
            int finalIndex;
            //GUI寻找文件
            if (commond[0] == "-x")
            {
                if (commond.Length <= 1)
                {
                    info.SetError(CommondInfo.ErrorType.CommondError);
                    return info;
                }

                if ((info.filePath = FileDataReader.GetFilePathByGUI()) == null)
                {
                    info.SetError(CommondInfo.ErrorType.FileNotChosen);
                    return info;
                }
                funcIndex++;
                finalIndex = commond.Length;
            }
            else
            {
                info.filePath = FileDataReader.GetCurrentPathWithFileName(commond[commond.Length - 1]);
                finalIndex = commond.Length - 1;
            }

            //多计数指令处理
            while (funcIndex < finalIndex)
            {
                if (commond[funcIndex] == "-c")     //LettersCount
                {
                    info.funcs.Add(LettersCount.Instance);
                    //if (funcIndex == 0)
                    //    info.filePath = FileDataReader.GetCurrentPathWithFileName(commond[funcIndex + 1]);
                    //if (!CheckPathLegal(info.filePath))
                    //    info.SetError(CommondInfo.ErrorType.FileError);
                    //return info;
                }
                else if (commond[funcIndex] == "-l") //LineCount
                {
                    info.funcs.Add(LineCount.Instance);
                    //if (funcIndex == 0)
                    //    info.filePath = FileDataReader.GetCurrentPathWithFileName(commond[funcIndex + 1]);

                    //if (!CheckPathLegal(info.filePath))
                    //    info.SetError(CommondInfo.ErrorType.FileError);
                    //return info;
                }
                else if (commond[funcIndex] == "-w") //WordCount
                {
                    info.funcs.Add(new WordCount());
                    //if (funcIndex == 0)
                    //    info.filePath = FileDataReader.GetCurrentPathWithFileName(commond[funcIndex + 1]);

                    //if (!CheckPathLegal(info.filePath))
                    //    info.SetError(CommondInfo.ErrorType.FileError);
                    //return info;
                }
                else
                {
                    info.SetError(CommondInfo.ErrorType.CommondError);
                    return info;
                }
                funcIndex++;
            }

            if (!CheckPathLegal(info.filePath))
                info.SetError(CommondInfo.ErrorType.FileError);

            return info;

            //if (commond[funcIndex] == "-c")     //LettersCount
            //{
            //    info.func = LettersCount.Instance;
            //    if (funcIndex == 0)
            //        info.filePath = FileDataReader.GetCurrentPathWithFileName(commond[funcIndex + 1]);

            //    if (!CheckPathLegal(info.filePath))
            //        info.SetError(CommondInfo.ErrorType.FileError);
            //    return info;
            //}
            //else if(commond[funcIndex] == "-l") //LineCount
            //{
            //    info.func = LineCount.Instance;
            //    if (funcIndex == 0)
            //        info.filePath = FileDataReader.GetCurrentPathWithFileName(commond[funcIndex + 1]);

            //    if (!CheckPathLegal(info.filePath))
            //        info.SetError(CommondInfo.ErrorType.FileError);
            //    return info;
            //}
            //else if(commond[funcIndex] == "-w") //WordCount
            //{
            //    info.func = new WordCount();
            //    if (funcIndex == 0)
            //        info.filePath = FileDataReader.GetCurrentPathWithFileName(commond[funcIndex + 1]);

            //    if (!CheckPathLegal(info.filePath))
            //        info.SetError(CommondInfo.ErrorType.FileError);
            //    return info;
            //}
            //else
            //{
            //    info.SetError(CommondInfo.ErrorType.CommondError);
            //    return info;
            //}


        }

        /// <summary>
        /// 确定地址合法性
        /// </summary>
        private static bool CheckPathLegal(string path)
        {
            if (!File.Exists(path) || !SupportTypes.Exists(x => x == Path.GetExtension(path)))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 支持的文件类型，GUI支持的需另修改
        /// </summary>
        private static List<string> SupportTypes = new List<string>
        {
            ".c", ".txt"
        };

    }
}
