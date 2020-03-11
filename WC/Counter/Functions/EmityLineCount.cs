using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.Counter.Functions
{
    /// <summary>
    /// 空行计数
    /// </summary>
    public class EmityLineCount : WordCounterFunction
    {
        private bool isEmity = true;   //是空行吗
        private bool oneVisual = false; //一个可见字符

        public int GetInitialValue()
        {
            return 1;
        }

        public string GetLogHead()
        {
            return "Emity Line: ";
        }

        public void Init()
        {
            isEmity = true;
            oneVisual = false;
        }

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
            if (letter == '\n')     //换行
            {
                oneVisual = false;
                isEmity = true;
                return 1;
            }
            else if (letter == ' ' || letter == '\n' || !isEmity)   //不可见字符
            {
                return 0;
            }
            else
            {
                //只有一个可见字符
                if (oneVisual)
                {
                    isEmity = false;
                    return -1;
                }
                else
                {
                    oneVisual = true;
                    return 0;
                }
            }
        }
    }
}
