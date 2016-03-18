using System;
using System.ComponentModel;

namespace ForMirMonitor.ViewModels
{
    public class SearchViewModels
    {
           
        /// <summary>
        /// 主键统计事件ID
        /// </summary>
        [DisplayName("统计信息Id")]
        public int? STATId { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        [DisplayName("QQ")]
        public int? QQ { get; set; }

        /// <summary>
        /// 分组编号
        /// </summary>
        [DisplayName("GroupNo")]
        public int? GroupNo { get; set; }

        /// <summary>
        /// 分组名
        /// </summary>
        [DisplayName("GroupName")]
        public string GroupName { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        [DisplayName("ID")]
        public string UserName { get; set; }

        /// <summary>
        /// 标签编号
        /// </summary>
        [DisplayName("TagNo")]
        public int? Tag { get; set; }

        /// <summary>
        /// 标签名
        /// </summary>
        [DisplayName("TagName")]
        public string TagName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("Tips")]
        public string Tips { get; set; }


        /// <summary>
        /// 录入时间
        /// </summary>
        [DisplayName("Indate")]
        public DateTime? Indate { get; set; }

        /// <summary>
        /// 编辑时间
        /// </summary>
        [DisplayName("Editdate")]
        public DateTime? Eidtdate { get; set; }

        /// <summary>
        /// 操作编号
        ///</summary>
        [DisplayName("Operator")]
        public int Operator { get; set; }

        /// <summary>
        /// 操作人名
        ///</summary>
        [DisplayName("OperatorName")]
        public string OperatorName { get; set; }

        /// <summary>
        /// 状态值
        /// </summary>
        [DisplayName("status")]
        public int Status { get; set; }

        /// <summary>
        /// 状态名
        /// </summary>
        [DisplayName("StatusName")]
        public string StatusName { get; set; }
    }
}
