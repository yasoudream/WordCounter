using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.Counter
{
    /// <summary>
    /// 计数器主体，主要用法在里面添加Function来自定义功能
    /// </summary>
    public class WordCounter
    {
        /// <summary>
        /// 当前的字符串
        /// </summary>
        private string currentString = null;
        /// <summary>
        /// 脏标记
        /// </summary>
        private bool isDirty = true;
        
        /// <summary>
        /// 存储功能
        /// </summary>
        private List<WordCounterFunction> functions = new List<WordCounterFunction>();

        /// <summary>
        /// 每个功能的计数值
        /// </summary>
        private List<int> functionsCount = new List<int>();

        /// <summary>
        /// 获得输入序号的log
        /// </summary>
        /// <param name="index">序号</param>
        /// <returns>log</returns>
        private string GetLog(int index)
        {
            if (isDirty)
                CountMain();
            return functions[index].GetLogHead() + functionsCount[index];
        }

        /// <summary>
        /// 在控制台打印出所有信息
        /// </summary>
        public string GetAllLogs()
        {
            if (isDirty)
                CountMain();
            string log = "";
            for (int i = 0; i < functions.Count; i++)
            {
                log += GetLog(i) + "\n";
            }
            return log;
        }

        /// <summary>
        /// 获得一个装有log的list
        /// </summary>
        /// <returns>装有log的list</returns>
        public List<string> GetAllLogsList()
        {
            List<string> logList = new List<string>();
            for (int i = 0; i < functions.Count; i++)
            {
                logList.Add(GetLog(i));
            }
            return logList;
        }

        /// <summary>
        /// 设置要计数的字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="countImmediately">是否立刻计数</param>
        public void SetString(string str, bool countImmediately = true)
        {
            currentString = str;
            isDirty = true;
            if (countImmediately)
            {
                CountMain();
            }
        }

        /// <summary>
        /// 计数主方法
        /// </summary>
        private void CountMain()
        {
            isDirty = false;
            Init(); 
            if (currentString == null)
                return;
            //当前字符下标
            int currentLetterIndex = 0;

            int functionsListCount = functions.Count;
            //第一个字符
            if (currentLetterIndex < currentString.Length)
            {
                for (int i = 0; i < functionsListCount; i++)
                {
                    functionsCount[i] += functions[i].OnStringHead(currentString[currentLetterIndex]);
                }
                currentLetterIndex++;
            }
            else//空串
            {
                return;
            }
            //中间的字符
            while (currentLetterIndex < currentString.Length - 1)
            {
                for (int i = 0; i < functionsListCount; i++)
                {
                    functionsCount[i] += functions[i].OnTraverse(currentString[currentLetterIndex]);
                }
                currentLetterIndex++;
            }
            //最后一个字符
            if (currentLetterIndex == currentString.Length - 1)
            {
                for (int i = 0; i < functionsListCount; i++)
                {
                    functionsCount[i] += functions[i].OnStringEnd(currentString[currentLetterIndex]);
                }
            }

            //for (int ii = 0; ii < currentString.Length; ii++)
            //{
            //    Console.WriteLine(currentString[ii]);
            //}

            return;
        }
        /// <summary>
        /// 外部手动重新计数
        /// </summary>
        public void ReCount()
        {
            CountMain();
        }

        private void Init()
        {
            functionsCount.Clear();
            for (int i = 0; i < functions.Count; i++)
            {
                functions[i].Init();
                functionsCount.Add(functions[i].GetInitialValue());
            }
        }

        /// <summary>
        /// 添加新功能
        /// </summary>
        /// <param name="func">功能</param>
        public void AddFunction(WordCounterFunction func)
        {
            isDirty = true;
            functions.Add(func);
            functionsCount.Add(func.GetInitialValue());
        }

        /// <summary>
        /// 添加新功能
        /// </summary>
        /// <param name="func">功能</param>
        public void AddFunction(List<WordCounterFunction> func)
        {
            isDirty = true;
            for (int i = 0; i < func.Count; i++)
            {
                functions.Add(func[i]);
                functionsCount.Add(func[i].GetInitialValue());
            }
        }

        /// <summary>
        /// 清空所有功能
        /// </summary>
        public void ClearFunctions()
        {
            functions.Clear();
            functionsCount.Clear();
            isDirty = true;
        }

    }


}
