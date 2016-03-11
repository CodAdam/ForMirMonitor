using System.Collections.Generic;
using System.Configuration.Provider;
using FMM.Model.Statistics;
using FMM.Common.Paging;

namespace FMM.BLL.Statistics.Providers
{
    public abstract partial class STATInfoProviderBase : ProviderBase
    {
        //public static STATInfoProviderBase Instance
        //{
        //    get
        //    {
        //        STATInfoProviderBase instance = new STATInfoProviderBase();
        //        return instance;
        //    }
        //}


        #region 判断数据是否存在
        /// <summary>
        /// 通过主键判断STATInfo是否存在
        /// </summary>
        /// <param name="STATId">主键</param>
        /// <returns></returns>
        public abstract bool ExistSTATInfo(long STATId);
        #endregion
        #region 获取实例
        /// <summary>
        /// 通过主键获取STATInfo
        /// </summary>
        /// <param name="STATId"></param>
        /// <returns></returns>
        public abstract STATInfo getSTATInfoByPrimarykey(long STATId);
        /// <summary>
        /// 通过QQ获取STATInfo的List
        /// </summary>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public abstract List<STATInfo> getSTATInfoByRMANumber(long QQ);
        /// <summary>
        /// 根据条件获取STATInfo的List
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public abstract List<STATInfo> getSTATInfoListByCriteria(STATInfoSearchCriteria criteria);

        /// <summary>
        /// 根据条件获取STATInfoPagerList
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public abstract Pager<STATInfo> getSTATInfoPagerListByCriteria(STATInfoSearchCriteria criteria);

        /// <summary>
        /// 作废STATInfo
        /// </summary>
        public abstract void UpdateSTATInfoStatus(int status, List<long> STATInfo, int OpratorID, string Oprator);

        /// <summary>
        /// 新建统计信息
        /// </summary>
        /// <param name="statinfo">统计信息实体</param>
        public abstract void AddSTATInfo(STATInfo statinfo);

        /// <summary>
        /// Excel导入统计信息
        /// </summary>
        /// <param name="statinfo"></param>
        public abstract void ImportSTATInfo(STATInfo statinfo);

        #endregion
    }
}
