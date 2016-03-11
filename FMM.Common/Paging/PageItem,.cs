using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FMM.Common.Paging
{
    /// <summary>
    /// 分页对象
    /// </summary>
    [Serializable]
    public class PageItem
    {
        /// <summary>
        /// 当前页数
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 总行数
        /// </summary>
        public int TotalItemCount { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPageCount
        {
            get { return (int)Math.Ceiling((double)TotalItemCount / PageSize); }
        }
        /// <summary>
        /// 每页开始行数
        /// </summary>
        public int StartPosition
        {
            get { return (CurrentPage - 1) * PageSize + 1; }
        }
        /// <summary>
        /// 每页结束行数
        /// </summary>
        public int EndPosition
        {
            get { return CurrentPage * PageSize > TotalItemCount ? TotalItemCount : CurrentPage * PageSize; }
        }
    }
}
