using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.Counter.Functions
{
    public class AnnotationCount : WordCounterFunction
    {
        private bool lastStar = false;
        private bool lastSlash = false;
        private bool inLineAnno = false;            //单行注释
        private bool inLinesAnno = false;           //多行注释
        private bool lastVisual = false;            //单可见
        private bool isEmity = true;                //空行

        public int GetInitialValue()
        {
            return 0;
        }

        public string GetLogHead()
        {
            return "Annotation: ";
        }

        public void Init()
        {
            lastStar = false;
            lastSlash = false;
            inLineAnno = false;
            inLinesAnno = false;
            lastVisual = false;
            isEmity = true;
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
            if (letter == '\n')
            {
                lastSlash = false;
                lastStar = false;
                inLineAnno = false;
                lastVisual = false;
                isEmity = true;
                if (inLinesAnno)
                    return 1;
                return 0;
            }
            if (letter == '/' && lastSlash && !inLinesAnno && !inLineAnno && isEmity)  //单行注释开始
            {
                inLineAnno = true;
                return 1;
            }
            if (letter == '*' && lastSlash && !inLinesAnno && !inLineAnno && isEmity)  //多行注释开始
            {
                inLinesAnno = true;
                return 1;
            }
            if (letter == '/' && lastStar && inLinesAnno)   //多行注释结束
            {
                inLinesAnno = false;
                return 0;
            }
            //保留上一个字符信息
            if (letter == '/')
            {
                lastSlash = true;
            }
            else if (letter == '*')
            {
                lastStar = true;
            }
            else if (!(letter == ' ' || letter == '\t')) //不是空行
            {
                if (lastVisual)
                {
                    isEmity = false;
                }
                else
                {
                    lastVisual = true;
                }
            }
            return 0;
            

        }
    }
}
