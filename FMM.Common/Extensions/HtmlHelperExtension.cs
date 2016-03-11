using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FMM.Common.Paging;

namespace FMM.Common.Extensions
{
    public static class HtmlHelperExtension
    {
        #region 创建分页控件 
        public static string CreatePagingControlHtml(this PageItem item, string id)
        {
            StringBuilder str = new StringBuilder(string.Format("<span>共 <span name=\"totalrecords{0}\">{1}</span> 条记录，", id, item.TotalItemCount));
            str.AppendFormat("每页 <span name=\"pagesize{0}\">{1}</span> 条，", id, item.PageSize);
            str.AppendFormat("当前第 <span name=\"currentpage{0}\">{1}</span>/<span name=\"totalpages{2}\">{3}</span> 页</span>", id, item.CurrentPage, id, item.TotalPageCount);
            str.AppendFormat("<a name=\"firstpage{0}\" href=javascript:HeadPage{1}()>首页</a>", id, id);
            ;
            str.AppendFormat("<a name=\"previouspage{0}\" href=javascript:PrePage{1}()>上一页</a>", id, id);
            str.AppendFormat("<a name=\"nextpage{0}\" href=javascript:NextPage{1}()>下一页</a>", id, id);
            str.AppendFormat("<a name=\"endpage{0}\" href=javascript:EndPage{1}()>末页</a>", id, id);
            str.AppendFormat("<span>转到第 <input type=\"text\" name=\"gotopage{0}\" class=\"input-txt\" /> 页</span>", id);
            str.AppendFormat("<button type=\"button\" name=\"gotopagebutton{0}\" onclick=\"PageGO{1}()\" >跳转</button>", id, id);
            return str.ToString();
        }
        #endregion
    }
}
