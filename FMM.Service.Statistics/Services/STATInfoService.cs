using System;
using System.Collections.Generic;
using FMM.Model.Statistics;
using FMM.Common.Paging;
//using FMM.BLL.Statistics.InfoBus;
using FMM.BLL.Statistics;
using Microsoft.Practices.Unity;
using System.Data;

namespace FMM.Service.Statistics
{
    public partial class STATInfoService:ISTATInfoService
    {
        /// <summary>
        /// BLL接口
        /// </summary>
        private ISTATInfoBusiness statInfoBusiness = null;
        public STATInfoService()
        {
            statInfoBusiness = STATInfoBusinessContainer.Instance.Container.Resolve<ISTATInfoBusiness>();
        }
        
        #region 判断数据是否存在
        /// <summary>
        /// 通过主键判断STATInfo是否存在
        /// </summary>
        /// <param name="STATId">主键</param>
        /// <returns></returns>
        public bool ExistSTATInfo(long STATId)
        {
            return true;
        }

        #endregion
        #region 获取实例
        /// <summary>
        /// 通过主键获取STATInfo
        /// </summary>
        /// <param name="STATId"></param>
        /// <returns></returns>
        public STATInfo getSTATInfoByPrimarykey(long STATId)
        {
            STATInfo statInfo = new STATInfo();
            return statInfo;
        }
        #endregion
        /// <summary>
        /// 通过QQ获取获取STATInfo的List
        /// </summary>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public List<STATInfo> getSTATInfoByRMANumber(long QQ)
        {
            List<STATInfo> statInfoList = new List<STATInfo>();
            return statInfoList;
        }
        /// <summary>
        /// 根据条件获取STATInfo的List
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public List<STATInfo> getSTATInfoListByCriteria(STATInfoSearchCriteria criteria)
        {
            List<STATInfo> STATInfoList = new List<STATInfo>();
            return STATInfoList;
        }

        /// <summary>
        /// 根据条件获取STATInfoPagerList
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public Pager<STATInfo> getSTATInfoPagerListByCriteria(STATInfoSearchCriteria criteria, int pageIndex, int pageSize)
        {
            //Pager<STATInfo> i = new Pager<STATInfo>();
            //return i;
            return statInfoBusiness.getSTATInfoPagerListByCriteria(criteria, pageIndex, pageSize);
        }

        /// <summary>
        /// 作废STATInfo
        /// </summary>
        public bool InvalidStatInfo(string STATIdStr)
        {
            return statInfoBusiness.InvalidStatInfo(STATIdStr);
        }

        /// <summary>
        /// 新建统计信息
        /// </summary>
        /// <param name="statinfo">统计信息实体</param>
        public bool AddSTATInfo(STATInfo statinfo)
        {
           return statInfoBusiness.AddSTATInfo(statinfo);
        }

        /// <summary>
        /// Excel导入统计信息
        /// </summary>
        /// <param name="statinfo"></param>
        public bool ImportSTATInfo(STATInfo statinfo)
        {
            return true;
        }


        public List<STATInfo> getSTATInfoListbyCriteria(STATInfoSearchCriteria criteria)
        {
            return statInfoBusiness.getSTATInfoListByCriteria(criteria);
        }


        /// <summary>
        /// Excel导出统计信息
        /// </summary>
        /// <param name="statinfo"></param>
        public DataTable ExportSTATInfo(STATInfoSearchCriteria criteria) {
            return (statInfoBusiness.ExportSTATInfo(criteria));
        }


        public bool EditStatInfoById(STATInfo statInfo)
        {
            return statInfoBusiness.EditStatInfoById(statInfo);
        }
    }
}
