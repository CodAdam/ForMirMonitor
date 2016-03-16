using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FMM.Service.Statistics;
using FMM.Common.Paging;
using FMM.Model.Statistics;
using FMM.Common.Extensions;
using Microsoft.Practices.Unity;

namespace ForMirMonitor.ViewModels
{
    public class SearchViewListModels
    {
        ISTATInfoService STATInfoService = STATInfoServiceContainer.Instance.Container.Resolve<ISTATInfoService>();
        public SearchViewListModels(Pager<STATInfo> statInfoList, PageItem pager)
        {
            this.Pagers = pager;
            if (statInfoList != null && statInfoList.ItemList != null && statInfoList.ItemList.Count > 0)
            {
                this.STATInfoListHtml = GetSTATInfoListPageHtml(statInfoList.ItemList);
            }
            else
            {
                this.STATInfoListHtml = "<tr><td colspan=\"8\">没有查询到数据</td></tr>";
            }
            this.PagersTopHtml = pager.CreatePagingControlHtml("STATSearch");
            this.PagersBottomHtml = pager.CreatePagingControlHtml("STATSearchBottom");
        }



        public Pager<STATInfo> STATInfoPager { get; private set; }
        public string STATInfoListHtml { get; private set; }
        public string STATInfoListHtmlPagingInfo { get; private set; }

        private string GetEumnDescByEumnValue(string enumname, object obj)
        {
            string desc = string.Empty;
            if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
            {
                switch (enumname)
                {
                    //    case "RMAEnumType":
                    //        desc = ((RMAEnumType)obj).GetEnumDesc();
                    //        break;
                    //    case "RMAEnumStatus":
                    //        desc = ((RMAEnumStatus)obj).GetEnumDesc();
                    //        break;
                    //    case "RefundType":
                    //        desc = ((RefundType)obj).GetEnumDesc();
                    //        break;
                    //    case "WmsToRmaSync":
                    //        desc = ((WmsToRmaSync)obj).GetEnumDesc();
                    //        break;
                    //    case "DutyFreightEnum":
                    //        desc = ((DutyFreightEnum)obj).GetEnumDesc();
                    //        break;
                    //}
                }
            }
            return desc;
        }


        public string GetSTATInfoListPageHtml(List<STATInfo> statInfoList)
        {
            try
            {
                string str = "";

                if (this.STATInfoPager.ItemList == null || this.STATInfoPager.ItemList.Count == 0)
                {
                    return str = "<tr><td colspan=\"7\">没有查询到数据</td></tr>";
                }
                else {
                    foreach (var dr in this.STATInfoPager.ItemList)
                    {
                        str += "<tr>";
                        str += string.Format("<td>{0}</td>", dr.STATId);
                        str += string.Format("<td>{0}</td>", dr.QQ);
                        str += string.Format("<td>{0}</td>", dr.GroupNo);
                        str += string.Format("<td>{0}</td>", dr.UserName);
                        str += string.Format("<td>{0}</td>", dr.Tag);
                        str += string.Format("<td>{0}</td>", dr.Tips);
                        str += string.Format("<td>{0}</td>", dr.Status);
                        str += "</tr>";
                    }
                    return str;
                }

            }
            catch (Exception ex)
            {
                //FMM.Common.Log.LogService.Instance.Warn("查询数据错误！原因：" + ex.Message + "\r\n" + ex.StackTrace);
                throw ex;
            }

        }

        /// <summary>
        /// 分页实体
        /// </summary>
        public PageItem Pagers { get; private set; }
        /// <summary>
        /// 分页Html
        /// </summary>
        public string PagersTopHtml { get; private set; }
        /// <summary>
        /// 分页Html
        /// </summary>
        public string PagersBottomHtml { get; private set; }

    }


}
