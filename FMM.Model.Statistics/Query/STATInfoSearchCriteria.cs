using System;
using System.Runtime.Serialization;

namespace FMM.Model.Statistics
{
        [DataContract, Serializable]
        public class STATInfoSearchCriteria
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
            public long QQ { get; set; }

            /// <summary>
            /// 分组编号
            /// </summary>
            [DataMember]
            public int? GroupNo { get; set; }


            /// <summary>
            /// 标签编号
            /// </summary>
            [DataMember]
            public int? Tag { get; set; }


            /// <summary>
            /// 录入时间
            /// </summary>
            [DataMember]
            public DateTime? BeginDate { get; set; }

            /// <summary>
            /// 编辑时间
            /// </summary>
            [DataMember]
            public DateTime? EndDate { get; set; }

            /// <summary>
            /// 状态
            /// </summary>
            [DataMember]
            public int Status { get; set; }
        }
    
}
