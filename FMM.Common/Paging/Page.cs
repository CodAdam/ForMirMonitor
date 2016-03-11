using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;

namespace FMM.Common.Paging
{
    [DataContract, Serializable]
    public class Page<T>
    {

        /// <summary>
        /// 总记录数
        /// </summary>
        [DataMember]
        public long TotalRecords
        {
            get;
            set;
        }

        private int pageSize = 0;
        /// <summary>
        /// 每页条目数
        /// </summary>
        [DataMember]
        public int PageSize
        {
            get
            {
                if (pageSize <= 0)
                    pageSize = 20;
                return pageSize;
            }
            set
            {
                pageSize = value;
            }
        }


        private int totalPage = 0;
        /// <summary>
        /// 总页数
        /// </summary>
        [DataMember]
        public int TotalPage
        {
            get
            {
                if (totalPage == 0)
                {
                    totalPage = (int)TotalRecords / PageSize;
                    if ((TotalRecords % PageSize) > 0)
                        totalPage++;
                }
                return totalPage;
            }
            set
            {
                totalPage = value;
            }
            //get { return (int)Math.Ceiling((double)TotalRecords / PageSize); }
        }


        private int currentPage = 1;
        /// <summary>
        /// 当前页
        /// </summary>
        [DataMember]
        public int CurrentPage
        {
            get
            {

                return currentPage;
            }
            set
            {

                currentPage = value;
            }
        }

        /// <summary>
        /// 数据list
        /// </summary>
        [DataMember]
        public List<T> ItemList
        {
            get;
            set;
        }

        [DataMember]
        public string Description
        {
            get;
            set;
        }

        public static Page<T> Convert(Pager<T> pager)
        {
            var page = new Page<T>();
            page.CurrentPage = pager.CurrentPage;
            page.Description = pager.Description;
            page.ItemList = pager.ItemList;
            page.PageSize = pager.PageSize;
            page.TotalPage = pager.TotalPage;
            page.TotalRecords = pager.TotalRecords;
            return page;
        }
    }
}
