using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.Counter
{
    /// <summary>
    /// 每一个功能类都要继承的基类，便于拓展
    /// </summary>
    public interface WordCounterFunction
    {      
        ///// <summary>
        ///// 结果
        ///// </summary>
        //protected int Result = 0;

        /// <summary>
        /// 获得初始值
        /// </summary>
        /// <returns>初始值</returns>
        int GetInitialValue();


        ///// <summary>
        ///// 返回计数的值
        ///// </summary>
        ///// <returns></returns>
        //int GetResult();

        ///// <summary>
        ///// 基础的初始化，负责初始化当前类
        ///// </summary>
        //public void InitBase()
        //{
        //    Result = 0;
        //}
        /// <summary>
        /// 继承类的初始化
        /// </summary>
        void Init();

        /// <summary>
        /// 访问第一个字母时调用
        /// </summary>
        /// <param name="letter">第一个字母</param>
        /// <returns>返回此次访问的变化值</returns>
        int OnStringHead(char letter);

        /// <summary>
        /// 遍历时调用，按提取的字符串遍历
        /// </summary>
        /// <param name="letter">字母</param>
        /// <return>返回此次访问的变化值</return> 
        int OnTraverse(char letter);

        /// <summary>
        /// 最后一个字母且该字母不是最后一个时调用
        /// </summary>
        /// <param name="letter"><最后一个字母/param>
        /// <returns>返回此次访问的变化值</returns>
        int OnStringEnd(char letter);

        /// <summary>
        /// 获得字符串形式输出结构
        /// </summary>
        string GetLogHead();

        ///// <summary>
        ///// 刷新数据
        ///// </summary>
        //public void Clear()
        //{
        //    Init();
        //    //InitBase();
        //}
    }
}
