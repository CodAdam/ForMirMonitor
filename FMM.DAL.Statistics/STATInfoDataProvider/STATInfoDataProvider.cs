using System.Collections.Generic;
using FMM.Model.Statistics;
using FMM.Common.Paging;
using System.Data.Common;
using System.Data;
using FMM.Common.Helper;
using System.Data.SqlClient;
using System;
using System.Text;

namespace FMM.DAL.Statistics
{
    public class STATInfoDataProvider : ISTATInfoDataProviderBase
    {
        #region SQL

        #region strSTATInfoSQL

        readonly string strSTATInfoSelectSQL = @"SELECT  
               [STATId]
              ,[QQ]
              ,[GroupNo]
              ,[UserName]
              ,[Tag]
              ,[Tips]
              ,[Indate]
              ,[EditDate]
              ,[Oprator]
              ,[Status]
          FROM [STATDB].[dbo].[STATInfo]  with(nolock) ";

        #endregion

        #region STATList

        readonly string strSTATInfoSearchListSQL = @"  ROW_NUMBER() OVER(ORDER BY statinfo.[EditDate] desc) AS ROWID
                                  ,statinfo.[STATId]
                                  ,statinfo.[QQ]
                                  ,statinfo.[GroupNo]
                                  ,statinfo.[UserName]
                                  ,statinfo.[Tag]
                                  ,statinfo.[Tips]
                                  ,statinfo.[Indate]
                                  ,statinfo.[EditDate]
                                  ,statinfo.[Oprator]
                                  ,statinfo.[Status]";
        //,category.[Description] AS CategoryName 
        //,isnull(properties.Description,'') + ' ' + isnull(propertyvalue.Description,'') AS PropertyName ";

        readonly string strSTATInfoSearchListForm = @" [STATDB].[dbo].[STATInfo] with(nolock)

            //LEFT JOIN YinTaiContent.dbo.BrandInfo brand WITH(NOLOCK) ON brand.BrandID=rmarule.BrandID
            //LEFT JOIN YinTaiContent.dbo.ItemCategory category WITH(NOLOCK) ON category.CategoryID=rmarule.CategoryID 
            //LEFT JOIN YinTaiContent.dbo.ItemProfilePropertyValues propertyvalue WITH(NOLOCK) ON propertyvalue.ValueID=rmarule.PropertyID
            //LEFT JOIN YinTaiContent.dbo.ItemProfileProperties properties WITH(NOLOCK) ON properties.PropertyID=propertyvalue.PropertyID 
            //LEFT JOIN ERPSCM.dbo.Provider Providers WITH(NOLOCK) ON Providers.Providerid=rmarule.ProviderCode";

        #endregion

        #region InsertSTATInfo

        string InsertSTATInfo = @"INSERT INTO [YinTaiService].[dbo].[RMARule]
                                                    ([STATId]
                                                    ,[QQ]
                                                    ,[GroupNo]
                                                    ,[UserName]
                                                    ,[Tag]
                                                    ,[Tips]
                                                    ,[Indate]
                                                    ,[EditDate]
                                                    ,[Oprator]
                                                    ,[Status])
                                             VALUES
                                                    (@STATId
                                                    ,@QQ
                                                    ,@GroupNo
                                                    ,@UserName
                                                    ,@Tag
                                                    ,@Tips
                                                    ,@Indate
                                                    ,@EditDate
                                                    ,@Oprator
                                                    ,@Status)
                                        ";

        #endregion

        #region STATInfo

        readonly string strUpdateRMARule = @"UPDATE [YinTaiService].[dbo].[RMARule] SET 
                                                     [STATId]=@STATId
                                                    ,[QQ]=@QQ
                                                    ,[GroupNo]=@GroupNo
                                                    ,[UserName]=@UserName
                                                    ,[Tag]=@Tag
                                                    ,[Tips]=@Tips
                                                    ,[Indate]=@Indate
                                                    ,[EditDate]=@EditDate
                                                    ,[Oprator]=@Oprator
                                                    ,[Status]=@Status
                                             WHERE [STATId]=@STATId";

        #endregion
        #endregion 
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
        public STATInfo GetSTATInfoByPrimarykey(long STATId)
        {
            STATInfo statInfo = new STATInfo();
            return statInfo;
        }
        #endregion
        /// <summary>
        /// 通过RMANumber获取RMATransaction
        /// </summary>
        /// <param name="QQ"></param>
        /// <returns></returns>
        public List<STATInfo> GetSTATInfoByRMANumber(long QQ)
        {
            List<STATInfo> statInfoList = new List<STATInfo>();
            return statInfoList;
        }
        /// <summary>
        /// 根据条件获取RMATransaction的List
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public List<STATInfo> STATInfoList(STATInfoSearchCriteria criteria)
        {
            List<STATInfo> statInfoList = new List<STATInfo>();
            return statInfoList;
        }


        /// <summary>
        /// 根据条件获取STATInfoPagerList
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSizecriteria"></param>
        /// <returns></returns>
        public Pager<STATInfo> getSTATInfoPagerListByCriteria(STATInfoSearchCriteria criteria, int pageIndex, int pageSize)
        {
            Pager<STATInfo> STATInfoPagerList = new Pager<STATInfo>();
            return STATInfoPagerList;

        }

        /// <summary>
        /// 根据条件获取STATInfoList
        /// </summary>
        /// <param name="pageSizecriteria"></param>
        /// <returns></returns>
        public List<STATInfo> getSTATInfoListByCriteria(STATInfoSearchCriteria criteria) {
            StringBuilder sql = new StringBuilder("");
            sql.Append(strSTATInfoSelectSQL);
            sql.Append(strCriteriaSqlWhere(criteria));
  
            SqlDataReader objReader = SQLHelper.GetReader(sql.ToString());

            List<STATInfo> STATInfoList = new List<STATInfo>();
          
            while (objReader.Read())
            {
                STATInfoList.Add(new STATInfo()
                {
                STATId = Convert.ToInt32(objReader["STATId"]),
                QQ = Convert.ToInt32(objReader["QQ"]),                
                GroupNo= Convert.ToInt32(objReader["GroupNo"]),
                UserName= Convert.ToString(objReader["UserName"]),
                Tag= Convert.ToInt32(objReader["Tag"]),
                Tips= Convert.ToString(objReader["Tips"]),
                Status= Convert.ToInt32(objReader["Status"])
                });
            }
            objReader.Close();
            return STATInfoList;
    }
        private string strCriteriaSqlWhere(STATInfoSearchCriteria criteria) {
            StringBuilder sqlwhere = new StringBuilder(" WHERE 1=1");
            if(criteria.STATId!=null)
            sqlwhere.AppendFormat(" AND STATId={0}", criteria.STATId);
            if (criteria.STATId != null)
                sqlwhere.AppendFormat(" AND QQ={0}", criteria.QQ);
            if (criteria.STATId != null)
                sqlwhere.AppendFormat(" AND GroupNo={0}", criteria.GroupNo);
            if (criteria.STATId != null)
                sqlwhere.AppendFormat(" AND UserName={0}", criteria.UserName);
            if (criteria.STATId != null)
                sqlwhere.AppendFormat(" AND Tag={0}", criteria.Tag);
            if (criteria.STATId != null)
                sqlwhere.AppendFormat(" AND Tips={0}", criteria.Tips);
            if (criteria.STATId != null)
                sqlwhere.AppendFormat(" AND status={0}", criteria.status);

            return sqlwhere.ToString();
        }

        /// <summary>
        /// 作废STATInfo
        /// </summary>
        public void UpdateSTATInfoStatus(int status, List<long> STATInfo, int OpratorID, string Oprator)
        {

        }

        /// <summary>
        /// 新建统计信息
        /// </summary>
        /// <param name="statinfo">统计信息实体</param>
        public void AddSTATInfo(STATInfo statinfo)
        {
            string sql=AddInparaByInsert(statinfo);
            int result=SQLHelper.Update(sql);
        }
        /// <summary>
        /// 新增用到的参数
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="Entity"></param>
        string AddInparaByInsert(STATInfo Entity)
        {
            // InsertSTATInfo.Replace("@QQ", "\'" + Entity.QQ.ToString() + "'\'");
            InsertSTATInfo.Replace("@QQ","\'"+Entity.QQ.ToString()+"'\'");
            InsertSTATInfo.Replace("@UserName", "\'"+Entity.QQ.ToString()+ "\'");
            InsertSTATInfo.Replace("@Tag", "\'"+Entity.QQ.ToString()+ "\'");
            InsertSTATInfo.Replace("@Tips", "\'"+Entity.QQ.ToString()+ "\'");
            InsertSTATInfo.Replace("@Indate", "\'"+DataSetDateTime.Local.ToString()+ "\'");
            InsertSTATInfo.Replace("@EditDate", "\'"+ DataSetDateTime.Local.ToString()+ "\'");
            InsertSTATInfo.Replace("@Oprator", "\'0\'");
            InsertSTATInfo.Replace("@Status", "\'1\'");
            return InsertSTATInfo;
        }

        /// <summary>
        /// Excel导入统计信息
        /// </summary>
        /// <param name="statinfo"></param>
        public void ImportSTATInfo(STATInfo statinfo)
        {

        }
    }
}
