using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FMM.Common.Paging
{

    /// <summary>
    /// 分页
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class Pager<T>
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

        /// <summary>
        /// 记录总条数
        /// </summary>
        public int SumCount
        {
            get;
            set;
        }

        /// <summary>
        /// 总金额
        /// </summary>
        public Decimal SumMoney
        {
            get;
            set;
        }

        /// <summary>
        /// 总件数
        /// </summary>
        public decimal SumQty
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public decimal sumCurrentRecptQty
        {
            get;
            set;
        }

        /// <summary>
        /// 外币币种
        /// </summary>
        public int Currency { get; set; }

        /// <summary>
        /// 外币币种名称
        /// </summary>
        public string CurrencyName { get; set; }

        /// <summary>
        /// 外币应付金额
        /// </summary>
        public decimal ForeignPayable { get; set; }

        /// <summary>
        /// 外币实付金额
        /// </summary>
        public decimal ForeignPaid { get; set; }

        /// <summary>
        /// 外币货款
        /// </summary>
        public Decimal ForeignGoodsMoney { get; set; }

        /// <summary>
        /// 外币佣金
        /// </summary>
        public Decimal ForeignCommission { get; set; }

    }
}