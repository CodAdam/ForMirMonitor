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
        public SearchViewListModels(STATInfoSearchCriteria criteria, string selectType)
        {
            STATInfoPager = STATInfoService.getSTATInfoPagerListByCriteria(criteria);
            PageItem pageItem = new PageItem { CurrentPage = STATInfoPager.CurrentPage, PageSize = STATInfoPager.PageSize, TotalItemCount = (int)STATInfoPager.TotalRecords };
            this.RMAMasterPagingInfo = pageItem.CreatePagingControlHtml("STATInfo");
            this.RMAMasterListHtml = GetSTATInfoListPage(selectType);
        }



        public Pager<STATInfo> STATInfoPager { get; private set; }
        public string RMAMasterListHtml { get; private set; }
        public string RMAMasterPagingInfo { get; private set; }

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
        

            public string GetSTATInfoListPage(string a)
             {
                //string str = "", returnReasonName = "", channelName = "";
                //if (this.RMAMasterPager.ItemList == null || this.RMAMasterPager.ItemList.Count == 0)
                //{
                //    return str = "<tr><td colspan=\"10\">没有查询到数据</td></tr>";
                //}
                //List<DrawMoneyEntity> drawList = RMAMasterService.GetDrawMoney(this.RMAMasterPager.ItemList.Select(p => p.RMANumber).ToList(), this.RMAMasterPager.PageSize);
                //try
                //{
                //    int[] rmatypeArr = new int[] { 1, 3, 4 };

                //    var allSource = new List<DictValueEntity>();

                //    if (this.RMAMasterPager.ItemList.Count > 0)
                //    {
                //        //获得订单的类型
                //        IDictValueService dicService = BaseServiceContainer.Instance.Container.Resolve<IDictValueService>();
                //        var result = dicService.GetDictValueList(new DictValueQuery() { Dict = "OrderLabel" });
                //        if (result != null)
                //        {
                //            allSource.AddRange(result);
                //        }
                //    }

                //    foreach (var dr in this.RMAMasterPager.ItemList)
                //    {
                //        dr.RMAMasterListBySoNumber = RMAMasterService.GetRMAMasterBySONumberList(dr.OriginalSONumber);
                //        //RMAMasterEntity dr = RMAMasterService.GetRMAMasterByRMANumber(item.RMANumber);
                //        var luxuryTag = "";
                //        var isVIP = "";
                //        var first = allSource.FirstOrDefault(p => p.Valueid == dr.OrderLabel);
                //        if (first != null && first.Valueid != 0)
                //        {
                //            luxuryTag = first.Value;
                //        }
                //        isVIP = GetVIP(dr.CustomerStatus.ToString());

                //        string otherRMAstr = "";
                //        string ManySingleWithParcel = "";
                //        dr.RMAMasterListBySoNumber.RemoveAll(p => p.RMANumber == dr.RMANumber);
                //        if (dr.RMAMasterListBySoNumber != null && dr.RMAMasterListBySoNumber.Count() > 0)
                //        {
                //            otherRMAstr = string.Format("<br><a href=\"#\" onclick=\"GetRMAListBySoNumber({0})\">其它RMA</a>", dr.OriginalSONumber);
                //        }
                //        if (!string.IsNullOrEmpty(dr.LogisticsNumber))
                //        {
                //            if (dr.LogisticsNumber.Contains(";"))
                //            {
                //                List<object> li = new List<object>();
                //                List<string> AllContainsCommaInfo = RMAMasterService.GetRMAMasterContainsComma();
                //                foreach (var item in AllContainsCommaInfo)
                //                {
                //                    var logColl = item.Split(';');
                //                    foreach (var log in logColl)
                //                        li.Add(log);
                //                }
                //                int temp = 0;
                //                string[] spiltValue = dr.LogisticsNumber.Split(';');
                //                for (var i = 0; i < spiltValue.Count(); i++)
                //                {
                //                    li.ForEach(x =>
                //                    {
                //                        if (x.ToString() == spiltValue[i])
                //                            temp++;
                //                    });
                //                }
                //                if (temp > 2)
                //                    ManySingleWithParcel = string.Format("<br><a href=\"#\" style=\"color:Red\" onclick=\"GetManySingleWithParcel('{0}')\">多单同包裹</a>", dr.LogisticsNumber);
                //            }
                //            else
                //            {
                //                var allRMANumberByLogisticsNumber = RMAMasterService.GetRMAMasterByLogisticsNumber(dr.LogisticsNumber);
                //                if (allRMANumberByLogisticsNumber.Count > 1)
                //                    ManySingleWithParcel = string.Format("<br><a href=\"#\" style=\"color:Red\" onclick=\"GetManySingleWithParcel('{0}')\">多单同包裹</a>", dr.LogisticsNumber);
                //            }
                //        }

                //        int[] referencetypes = new int[] { 1, 7, 8, 24, 25 };
                //        RMAEnumStatus[] limitSatus = new RMAEnumStatus[] { RMAEnumStatus.AuditFail, RMAEnumStatus.Delete, RMAEnumStatus.GoodsReturn, RMAEnumStatus.WaitAudit };
                //        string refundAmountstr = "", restAmountstr = "";
                //        if (dr.RMAType == RMAEnumType.Swapin || dr.RMAType == RMAEnumType.Swapout)
                //        {
                //            refundAmountstr = "-";
                //            restAmountstr = "-";
                //        }
                //        else
                //        {
                //            decimal refundamount = 0M;
                //            if (dr.RefundDetail != null)
                //                refundamount = dr.RefundDetail.FindAll(t => referencetypes.Contains(t.ReferenceType)).Sum(p => p.RefundAmount);
                //            decimal returnedamount = 0M; //已退或整在退的金额
                //            decimal restamount = 0M; //剩余金额
                //            foreach (var rma in dr.RMAMasterListBySoNumber)
                //            {
                //                if (rma.RMAType != RMAEnumType.Swapin && rma.RMAType != RMAEnumType.Swapout && !limitSatus.Contains(rma.Status) && rma.RefundDetail != null)
                //                {
                //                    var rfddetail = rma.RefundDetail.FindAll(t => referencetypes.Contains(t.ReferenceType));
                //                    if (rfddetail != null)
                //                    {
                //                        returnedamount += rfddetail.Sum(p => p.RefundAmount);
                //                    }
                //                }
                //            }
                //            restamount = (dr.OrderAmount == null ? 0M : (decimal)dr.OrderAmount) - returnedamount - refundamount;

                //            refundAmountstr = refundamount.ToString();
                //            restAmountstr = restamount.ToString();
                //        }
                //        str += string.Format("<tr><td><input id=\"rdo_{0}\" type=\"{2}\" name=\"rdo\" value=\"{1}\"/><input type=\"hidden\" name=\"hiddenRMANumber\" value=\"{0}\" /></td>", dr.RMANumber, dr.RMANumber, selectType);
                //        //str += string.Format("<td>{0}</td>", dr.RMANumber);
                //        str += string.Format("<td><a name=\"aRMANumber\" href=\"#\" onclick=\"ViewPost('{0}','{2}','{3}')\">{1} {0} {4}</a>{5}</td>", dr.RMANumber, luxuryTag, (int)dr.RMAType, (int)dr.Status, isVIP, ManySingleWithParcel);

                //        str += string.Format("<td>{0}<input type='hidden' name='rmaType' value='{1}'/></td>", GetEumnDescByEumnValue("RMAEnumType", dr.RMAType), (int)dr.RMAType);
                //        str += string.Format("<td><a href=\"#\" onclick=\"ViewOrderInfo('{0}')\">{0}</a>{1}</td>", dr.OriginalSONumber, otherRMAstr);
                //        str += string.Format("<td>{0}</td>", dr.MasterSONumber);    //父订单号
                //        channelName = "";
                //        if (dr.Channelid != null && !string.IsNullOrEmpty(dr.Channelid.ToString()))
                //        {
                //            channelName = (new ChannelEntity()).GetChannelName((int)dr.Channelid);
                //            if (string.IsNullOrEmpty(channelName))
                //                channelName = dr.Channelid.ToString();
                //        }
                //        str += string.Format("<td>{0}</td>", channelName);
                //        str += string.Format("<td>{0}</td>", dr.InDate);
                //        str += string.Format("<td>{0}<input type='hidden' name='rmaStatus' value='{1}'/></td>", GetEumnDescByEumnValue("RMAEnumStatus", dr.Status), (int)dr.Status);
                //        str += string.Format("<td>{0}<br>[ID:{1}]</td>", dr.LoginName, dr.CustomerID);
                //        str += string.Format("<td>{0}</td>", BaseController.GetDictValueEntity("VIPRank", dr.HoldUserID == null || dr.HoldUserID == 0 ? 1 : dr.HoldUserID.Value).Value);
                //        str += string.Format("<td>{0}</td>", dr.InUserName);
                //        str += string.Format("<td>{0}<input type='hidden' name='rmaRefundType' value='{1}'/></td>", GetEumnDescByEumnValue("RefundType", dr.RefundType), dr.RefundType);
                //        str += string.Format("<td>{0}</td>", refundAmountstr);//退款金额
                //        str += string.Format("<td>{0}</td>", restAmountstr);//剩余金额
                //        str += string.Format("<td>{0}</td>", dr.ShippingVARCHARge);//寄回运费
                //        returnReasonName = "";
                //        if (dr.LastInvoiceNumber != null && !string.IsNullOrEmpty(dr.LastInvoiceNumber.ToString()))
                //        {
                //            returnReasonName = (new ReturnReasonEntity()).GetReturnReasonName(Int16.Parse(dr.LastInvoiceNumber.ToString()));
                //        }
                //        str += string.Format("<td>{0}</td>", returnReasonName);
                //        str += string.Format("<td>{0}</td>", GetEumnDescByEumnValue("DutyFreightEnum", dr.DutyFreight));
                //        str += string.Format("<td>{0}</td>", dr.Description);
                //        string drawStatus = "";
                //        if (drawList != null && drawList.Count > 0)
                //        {
                //            DrawMoneyEntity draw = drawList.Find(p => p.RMANumber == dr.RMANumber && p.PaymentMethodCode == p.PaymentMethodCode);
                //            if (draw != null)
                //                drawStatus = ((DrawMoneyStatus)draw.Status).GetEnumDesc();
                //        }

                //        str += string.Format("<td>{0}</td>", drawStatus);
                //        str += "</tr>";
                //    }
                //}
                //catch (Exception ex)
                //{
                //    Yintai.ERP.Log.LogService.Instance.Warn("查询数据错误！原因：" + ex.Message + "\r\n" + ex.StackTrace);
                //    throw ex;
                //}
                return a;
            }

        }
    }
