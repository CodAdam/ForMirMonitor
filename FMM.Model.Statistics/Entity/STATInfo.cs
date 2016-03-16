using System;
using System.Runtime.Serialization;

namespace FMM.Model.Statistics
{
    [DataContract,Serializable]
    public class STATInfo
    {
        /// <summary>
        /// 主键统计事件ID
        /// </summary>
        [DataMember]
        public int? STATId { get; set; }

       /// <summary>
       /// QQ
       /// </summary>
        [DataMember]
        public int? QQ { get; set; }

        /// <summary>
        /// 分组编号
        /// </summary>
        [DataMember]
        public int? GroupNo { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// 标签编号
        /// </summary>
        [DataMember]
        public int? Tag { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Tips { get; set; }

        /// <summary>
        /// 录入时间
        /// </summary>
        [DataMember]
        public DateTime? Indate { get; set; }

        /// <summary>
        /// 编辑时间
        /// </summary>
        [DataMember]
	    public DateTime? Eidtdate { get; set; }

        /// <summary>
        /// 操作人
        ///</summary>
        [DataMember]
        public string Operator { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [DataMember]
        public int status { get; set; }
        public object Status { get; set; }
    }
}
