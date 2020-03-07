using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.Counter;

namespace WC.Counter.Functions
{
    /// <summary>
    /// 行数计数
    /// </summary>
    class LineCount : WordCounterFunction
    {
        //不需参数的功能，使用单例类
        private static LineCount _instance;
        public static LineCount Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LineCount();
                return _instance;
            }
        }

        public int GetInitialValue()
        {
            return 1;
        }

        public string GetLogHead()
        {
            return "Line Count: ";
        }

        public void Init() { }

        public int OnStringEnd(char letter)
        {
            return OnTraverse(letter);
        }

        public int OnStringHead(char letter)
        {
            return OnTraverse(letter);
        }

        public int OnTraverse(char letter)
        {
            if (letter == '\n')
                return 1;
            return 0;
        }
    }
}
