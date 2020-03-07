using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.Counter;

namespace WC.Counter.Functions
{
    /// <summary>
    /// 计数字母个数
    /// </summary>
    public class LettersCount : WordCounterFunction
    {
        //不需参数的功能，使用单例类
        private static LettersCount _instance;
        public static LettersCount Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LettersCount();
                return _instance;
            }
        }

        private LettersCount() { }

        public int GetInitialValue()
        {
            return 0;
        }

        public string GetLogHead()
        {
            return "Character Count: ";
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
            if (letter != ' ' && letter != '\n' && letter != '\t')
                return 1;
            return 0;
        }
    }
}
