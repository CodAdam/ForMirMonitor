using System.Collections.Generic;
using FMM.Model.Statistics;
using FMM.Common.Paging;
using System.Data;

namespace FMM.DAL.Statistics
{
    public interface ISTATInfoDataProviderBase
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
        STATInfo GetSTATInfoByPrimarykey(long STATId);
        #endregion
        /// <summary>
        /// 通过RMANumber获取RMATransaction
        /// </summary>
        /// <param name="QQ"></param>
        /// <returns></returns>
        List<STATInfo> GetSTATInfoByRMANumber(long QQ);

        /// <summary>
        /// 根据条件获取RMATransaction的List
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        List<STATInfo> STATInfoList(STATInfoSearchCriteria criteria);

        /// <summary>
        /// 根据条件获取STATInfoPagerList
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSizecriteria"></param>
        /// <returns></returns>
        Pager<STATInfo> getSTATInfoPagerListByCriteria(STATInfoSearchCriteria criteria, int pageIndex, int pageSizecriteria);

        /// <summary>
        /// 根据条件获取STATInfoList
        /// </summary>
        /// <param name="pageSizecriteria"></param>
        /// <returns></returns>
        List<STATInfo> getSTATInfoListByCriteria(STATInfoSearchCriteria criteria);


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


        /// <summary>
        /// Excel导出统计信息
        /// </summary>
        /// <param name="statinfo"></param>
        DataTable ExportSTATInfo(STATInfoSearchCriteria criteria);

        /// <summary>
        /// 根据STATId更新STATInfo
        /// </summary>
        /// <param name="STATInfo"></param>
        void EditStatInfoById(STATInfo statInfo);
    }
}
