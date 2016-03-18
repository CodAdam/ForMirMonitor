using System.Collections.Generic;
using FMM.Model.Statistics;
using FMM.Common.Paging;

namespace FMM.BLL.Statistics.InfoBus
{
    public partial interface ISTATInfoBusiness
    {
        #region 判断数据是否存在
        /// <summary>
        /// 通过主键判断STATInfo是否存在
        /// </summary>
        /// <param name="STATId">主键</param>
        /// <returns></returns>
        bool ExistSTATInfo(long STATId);
        #endregion
        #region 获取实例
        /// <summary>
        /// 通过主键获取STATInfo
        /// </summary>
        /// <param name="STATId"></param>
        /// <returns></returns>
        STATInfo getSTATInfoByPrimarykey(long STATId);
        /// <summary>
        /// 通过QQ获取STATInfoList
        /// </summary>
        /// <param name="QQ"></param>
        /// <returns></returns>
        List<STATInfo> getSTATInfoByRMANumber(long QQ);

        /// <summary>
        /// 根据条件获取STATInfo的List
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        List<STATInfo> getSTATInfoListByCriteria(STATInfoSearchCriteria criteria);

        /// <summary>
        /// 根据条件获取STATInfoPagerList
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        Pager<STATInfo> getSTATInfoPagerListByCriteria(STATInfoSearchCriteria critcriteria, int pageIndex, int pageSizeeria);

        /// <summary>
        /// 作废STATInfo
        /// </summary>
        void UpdateSTATInfoStatus(int status, List<long> STATInfo, int OpratorID, string Oprator);

        /// <summary>
        /// 新建统计信息
        /// </summary>
        /// <param name="statinfo">统计信息实体</param>
        void AddSTATInfo(STATInfo statinfo);

        /// <summary>
        /// Excel导入统计信息
        /// </summary>
        /// <param name="statinfo"></param>
        void ImportSTATInfo(STATInfo statinfo);

        #endregion
    }
}
