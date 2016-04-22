using System.Collections.Generic;
using FMM.Model.Statistics;
using FMM.Common.Paging;
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
              ,[Editdate]
              ,[OperatorId]
              ,[Operator]
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

        string InsertSTATInfo = @"INSERT INTO [STATDB].[dbo].[STATInfo] 
                                                    ([QQ]
                                                    ,[GroupNo]
                                                    ,[UserName]
                                                    ,[Tag]
                                                    ,[Tips]
                                                    ,[Indate]
                                                    ,[EditDate]
                                                    ,[OperatorId]
                                                    ,[Operator]
                                                    ,[Status])
                                             VALUES
                                                    ({0}
                                                    ,{1}
                                                    ,'{2}'
                                                    ,'{3}'
                                                    ,'{4}'
                                                    ,'{5}'
                                                    ,'{6}'
                                                    ,'{7}'
                                                    ,'{8}'
                                                    ,{9})";

        #endregion

        #region UpdateSTATInfoById

        readonly string strUpdateSTATInfoById = @"UPDATE [STATDB].[dbo].[STATInfo] SET 
                                                     [QQ]={0}
                                                    ,[GroupNo]={1}
                                                    ,[UserName]={2}
                                                    ,[Tag]={3}
                                                    ,[Tips]={4}
                                                    ,[EditDate]={5}
                                                    ,[OpratorId]={6}
                                                    ,[Oprator]={7}
                                                    ,[Status]={8}
                                             WHERE [STATId]={9}";

        #endregion
        readonly string strInvalidStatInfo = @"UPDATE [STATDB].[dbo].[STATInfo] SET 
                                                    ,[Status]=0
                                             WHERE [STATId]= in ({0})";
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
        public List<STATInfo> getSTATInfoListByCriteria(STATInfoSearchCriteria criteria)
        {
            StringBuilder sql = new StringBuilder("");
            sql.Append(strSTATInfoSelectSQL);
            sql.Append(strCriteriaSqlWhere(criteria));


            List<STATInfo> STATInfoList = new List<STATInfo>();
            for (int i = 100; i < 200; i++)
            {
                STATInfoList.Add(new STATInfo()
                {
                    STATId = i,
                    QQ = 132123541 + i,
                    GroupNo = 1,
                    UserName = "testadam",
                    Tag = 2,
                    Tips = "lala",
                    Status = 1
                });
            }
            //SqlDataReader objReader = SQLHelper.GetReader(sql.ToString());

            //List<STATInfo> STATInfoList = new List<STATInfo>();
            //while (objReader.Read())
            //{
            //    STATInfoList.Add(new STATInfo()
            //    {
            //        STATId = Convert.ToInt32(objReader["STATId"]),
            //        QQ = Convert.ToInt32(objReader["QQ"]),
            //        GroupNo = Convert.ToInt32(objReader["GroupNo"]),
            //        UserName = Convert.ToString(objReader["UserName"]),
            //        Tag = Convert.ToInt32(objReader["Tag"]),
            //        Tips = Convert.ToString(objReader["Tips"]),
            //        Status = Convert.ToInt32(objReader["Status"])
            //    });
            //}
            //objReader.Close();

            return STATInfoList;
        }
        private string strCriteriaSqlWhere(STATInfoSearchCriteria criteria)
        {
            StringBuilder sqlwhere = new StringBuilder(" WHERE 1=1");
            if (criteria.STATId != null)
                sqlwhere.AppendFormat(" AND STATId={0}", criteria.STATId);
            if (criteria.QQ != -1)
                sqlwhere.AppendFormat(" AND QQ={0}", criteria.QQ);
            if (criteria.GroupNo != null)
                sqlwhere.AppendFormat(" AND GroupNo={0}", criteria.GroupNo);
            if (criteria.Tag != null)
                sqlwhere.AppendFormat(" AND Tag={0}", criteria.Tag);
            if (criteria.Status != -1)
                sqlwhere.AppendFormat(" AND Status={0}", criteria.Status);
            if (criteria.BeginDate != null)
                sqlwhere.AppendFormat(" AND Indate>={0}", criteria.BeginDate);
            if (criteria.EndDate != null)
                sqlwhere.AppendFormat(" AND Indate<={0}", criteria.EndDate);

            return sqlwhere.ToString();
        }


        /// <summary>
        /// 新建统计信息
        /// </summary>
        /// <param name="statinfo">统计信息实体</param>
        public bool AddSTATInfo(STATInfo statinfo)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(AddInparaForInsert(statinfo));


            int result = SQLHelper.Update(sql.ToString());
            return result > 0;
        }
        /// <summary>
        /// 新增用到的参数
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="Entity"></param>
        private string AddInparaForInsert(STATInfo statinfo)
        {
            string InsertSTATInfosql = "";
            STATInfo InsertModel = new STATInfo();
            InsertModel = MakeInsertModel(statinfo);
            InsertSTATInfosql = String.Format(InsertSTATInfo,
                InsertModel.QQ,
                InsertModel.GroupNo,
                InsertModel.UserName,
                InsertModel.Tag,
                InsertModel.Tips,
                InsertModel.Indate,
                InsertModel.Eidtdate,
                InsertModel.OperatorId,
                InsertModel.Operator,
                InsertModel.Status);
            return InsertSTATInfosql;
        }

        private STATInfo MakeInsertModel(STATInfo statinfo)
        {
            STATInfo InsertModel = new STATInfo();
            InsertModel.QQ = statinfo.QQ;
            InsertModel.GroupNo = statinfo.GroupNo;
            InsertModel.Tips = statinfo.Tips;
            InsertModel.Indate = statinfo.Indate == null ? DateTime.Now : DateTime.Now;
            InsertModel.Eidtdate = statinfo.Eidtdate == null ? DateTime.Now : DateTime.Now;
            InsertModel.OperatorId = statinfo.OperatorId == null ? "0" : statinfo.OperatorId;
            InsertModel.UserName = statinfo.UserName;
            InsertModel.Tag = statinfo.Tag;
            InsertModel.Operator = statinfo.Operator == null ? "0" : statinfo.Operator;
            InsertModel.Status = statinfo.Status == null ? 1 : statinfo.Status;
            return InsertModel;
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
        public DataTable ExportSTATInfo(STATInfoSearchCriteria criteria)
        {
            DataTable ExportSTATInfo = new DataTable();
            StringBuilder sql = new StringBuilder("");
            sql.Append(strSTATInfoSelectSQL);
            sql.Append(strCriteriaSqlWhere(criteria));
            DataSet ds = new DataSet();
            ds = SQLHelper.GetDataSet(sql.ToString());
            return ds.Tables[0];
        }

        /// <summary>
        /// 根据STATId更新STATInfo
        /// </summary>
        /// <param name="STATInfo"></param>
        public bool EditStatInfoById(STATInfo statinfo)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(AddInparaForUpdateById(statinfo));
            int result = SQLHelper.Update(sql.ToString());
            return result > 0;

        }
        private string AddInparaForUpdateById(STATInfo statinfo)
        {
            string updateSTATInfosql = "";
            STATInfo UpdateModel = new STATInfo();
            UpdateModel = MakeUpdateModel(statinfo);
            updateSTATInfosql = String.Format(strUpdateSTATInfoById,
                UpdateModel.QQ,
                UpdateModel.GroupNo,
                UpdateModel.UserName,
                UpdateModel.Tag,
                UpdateModel.Tips,
                UpdateModel.Eidtdate,
                UpdateModel.OperatorId,
                UpdateModel.Operator,
                UpdateModel.Status,
                UpdateModel.STATId
                );
            return updateSTATInfosql;



        }

        private STATInfo MakeUpdateModel(STATInfo statinfo)
        {

            STATInfo UpdateModel = new STATInfo();

            UpdateModel.STATId = statinfo.STATId;
            UpdateModel.QQ = statinfo.QQ;
            UpdateModel.GroupNo = statinfo.GroupNo;
            UpdateModel.UserName = statinfo.UserName;
            UpdateModel.Tag = statinfo.Tag;
            UpdateModel.Tips = statinfo.Tips;
            UpdateModel.Status = statinfo.Status == null ? 1 : statinfo.Status;
            UpdateModel.Eidtdate = DateTime.Now;

            UpdateModel.OperatorId = statinfo.OperatorId == null ? "0" : statinfo.OperatorId;
            UpdateModel.Operator = statinfo.Operator == null ? "0" : statinfo.Operator;

            return UpdateModel;
        }

        /// <summary>
        /// 作废STATInfo
        /// </summary>
        /// <param name="STATIdStr"></param>
        public bool InvalidStatInfo(string STATIdStr)
        { 
            StringBuilder sql = new StringBuilder();
            sql.Append(AddInparaForInvalidStatInfo(STATIdStr));
            int result = SQLHelper.Update(sql.ToString());
            return result > 0;
        }
        private string AddInparaForInvalidStatInfo(string STATIdStr)
        {
            return String.Format(strInvalidStatInfo, STATIdStr);
        }
    }

}

