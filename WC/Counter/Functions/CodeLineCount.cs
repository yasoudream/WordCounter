//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace WC.Counter.Functions
//{
//    /// <summary>
//    /// 代码行计数
//    /// 尚未解决注释空行的问题
//    /// </summary>
//    public class CodeLineCount : WordCounterFunction
//    {
//        //代码行 = 总行数 - 空行 - 注释行
//        private AnnotationCount ac = new AnnotationCount();
//        private EmityLineCount ec = new EmityLineCount();
//        private LineCount lc = new LineCount();
//        private int aCount;
//        private int eCount;
//        private int lCount;

//        public int GetInitialValue()
//        {
//            return 0;
//        }

//        public string GetLogHead()
//        {
//            return "Code Line: ";
//        }

//        public void Init()
//        {
//            ac.Init();
//            ec.Init();
//            lc.Init();
//            aCount = ac.GetInitialValue();
//            eCount = ec.GetInitialValue();
//            lCount = lc.GetInitialValue();
//        }

//        public int OnStringEnd(char letter)
//        {
//            aCount += ac.OnStringEnd(letter);
//            eCount += ec.OnStringEnd(letter);
//            lCount += ec.OnStringEnd(letter);
//            return lCount - aCount - eCount;
//        }

//        public int OnStringHead(char letter)
//        {
//            aCount += ac.OnStringHead(letter);
//            eCount += ec.OnStringHead(letter);
//            lCount += ec.OnStringHead(letter);
//            return 0;
//        }

//        public int OnTraverse(char letter)
//        {
//            aCount += ac.OnTraverse(letter);
//            eCount += ec.OnTraverse(letter);
//            lCount += lc.OnTraverse(letter);
//            return 0;
//        }
//    }
//}
