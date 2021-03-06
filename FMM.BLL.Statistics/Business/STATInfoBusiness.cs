﻿using System.Collections.Generic;
using FMM.Common.Paging;
using FMM.Model.Statistics;
using FMM.DAL.Statistics;
using Microsoft.Practices.Unity;
using System.Data;

namespace FMM.BLL.Statistics
{
    public class STATInfoBusiness : ISTATInfoBusiness
    {
        /// <summary>
        /// DAL接口
        /// </summary>
        private ISTATInfoDataProviderBase statInfoDataAccess = null;
        public STATInfoBusiness()
        {
            statInfoDataAccess = STATInfoDataAccessContainer.Instance.Container.Resolve<ISTATInfoDataProviderBase>();
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
        /// 通过QQ获取STATInfoList
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
        public List<STATInfo> getSTATInfoListByCriteria(STATInfoSearchCriteria criteria) {
            return (statInfoDataAccess.getSTATInfoListByCriteria(criteria));
        }

        /// <summary>
        /// 根据条件获取STATInfoPagerList
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public Pager<STATInfo> getSTATInfoPagerListByCriteria(STATInfoSearchCriteria criteria, int pageIndex, int pageSize) {
            return(statInfoDataAccess.getSTATInfoPagerListByCriteria(criteria, pageIndex, pageSize));
        }

        /// <summary>
        /// 作废STATInfo
        /// </summary>
        /// <param name="STATIdStr"></param>
        public bool InvalidStatInfo(string STATIdStr)
        {
            return statInfoDataAccess.InvalidStatInfo(STATIdStr);
        }

        /// <summary>
        /// 新建统计信息
        /// </summary>
        /// <param name="statinfo">统计信息实体</param>
        public bool AddSTATInfo(STATInfo statinfo)
        {
            return statInfoDataAccess.AddSTATInfo(statinfo);
        }

        /// <summary>
        /// Excel导入统计信息
        /// </summary>
        /// <param name="statinfo"></param>
        public bool ImportSTATInfo(STATInfo statinfo)
        {
            return true;
        }

        /// <summary>
        /// Excel导出统计信息
        /// </summary>
        /// <param name="statinfo"></param>
        public DataTable ExportSTATInfo(STATInfoSearchCriteria criteria) {
            return (statInfoDataAccess.ExportSTATInfo(criteria));
        }



        /// <summary>
        /// 根据STATId更新STATInfo
        /// </summary>
        /// <param name="STATInfo"></param>
        public bool EditStatInfoById(STATInfo statInfo)
        {
           return statInfoDataAccess.EditStatInfoById(statInfo);
        }
    }
}
