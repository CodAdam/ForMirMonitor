using System.Collections.Generic;
using FMM.Model.Statistics;
using FMM.Common.Paging;
using FMM.BLL.Statistics.InfoBus;
using System;

namespace FMM.Service.Statistics
{
    public partial class STATInfoService:ISTATInfoService
    {

        /// <summary>
        /// 总线接口
        /// </summary>
        private ISTATInfoBusiness statInfoBusiness = null;

        #region 判断数据是否存在
        /// <summary>
        /// 通过主键判断STATInfo是否存在
        /// </summary>
        /// <param name="STATId">主键</param>
        /// <returns></returns>
        bool ExistSTATInfo(long STATId)
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
        STATInfo getSTATInfoByPrimarykey(long STATId)
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
        List<STATInfo> getSTATInfoByRMANumber(long QQ)
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
            return statInfoBusiness.GetPagerSearchRMARuleList(criteria, pageIndex, pageSize);
        }

        /// <summary>
        /// 作废STATInfo
        /// </summary>
        void UpdateSTATInfoStatus(int status, List<long> STATInfo, int OpratorID, string Oprator)
        {

        }

        /// <summary>
        /// 新建统计信息
        /// </summary>
        /// <param name="statinfo">统计信息实体</param>
        void AddSTATInfo(STATInfo statinfo)
        {

        }

        /// <summary>
        /// Excel导入统计信息
        /// </summary>
        /// <param name="statinfo"></param>
        void ImportSTATInfo(STATInfo statinfo)
        {

        }

        bool ISTATInfoService.ExistSTATInfo(long STATId)
        {
            throw new NotImplementedException();
        }

        STATInfo ISTATInfoService.getSTATInfoByPrimarykey(long STATId)
        {
            throw new NotImplementedException();
        }

        List<STATInfo> ISTATInfoService.getSTATInfoByRMANumber(long QQ)
        {
            throw new NotImplementedException();
        }

        public List<STATInfo> getSTATInfoListbyCriteria(STATInfoSearchCriteria criteria)
        {
            throw new NotImplementedException();
        }

        void ISTATInfoService.UpdateSTATInfoStatus(int status, List<long> STATInfo, int OpratorID, string Oprator)
        {
            throw new NotImplementedException();
        }

        void ISTATInfoService.AddSTATInfo(STATInfo statinfo)
        {
            throw new NotImplementedException();
        }

        void ISTATInfoService.ImportSTATInfo(STATInfo statinfo)
        {
            throw new NotImplementedException();
        }
    }
}
