using System.Collections.Generic;
using FMM.Model.Statistics;

namespace FMM.Service.Statistics
{
    public interface ISTATInfoService
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
