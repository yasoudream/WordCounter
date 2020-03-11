using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.Counter.Functions
{
    /// <summary>
    /// 检测英文单词词数
    /// </summary>
    class WordCount : WordCounterFunction
    {
        private bool inWord = false;

        public int GetInitialValue()
        {
            return 0;
        }

        public string GetLogHead()
        {
            return "Word Count: ";
        }

        public void Init() { inWord = false; }

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
            if (letter <= 'Z' && letter >= 'A' || letter <= 'z' && letter >= 'a' || letter <= '9' && letter >= '0')
            {
                if (!inWord)
                {
                    inWord = true;
                    return 1;
                }
            }
            else
            {
                inWord = false;
            }
            return 0;
        }
    }
}
