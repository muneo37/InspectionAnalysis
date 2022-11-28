using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InspectionAnalysis
{
    /// <summary>
    /// 品種データ更新ログを表すクラスです
    /// </summary>
    public class WorkDataChangeLog
    {

        /// <summary>
        /// 更新履歴識別子を設定または取得します
        /// </summary>
        public int WorkDataChangeLogId { get; set; }

        /// <summary>
        /// ユーザー識別子を設定または取得します
        /// </summary>
        public int UserId { get; set; }
        public User User { get; set; } = new User();

        /// <summary>
        /// 品種データ識別子を設定または取得します
        /// </summary>
        public int WorkDataId { get; set; }
        public WorkData WorkData { get; set; } = new WorkData();

        /// <summary>
        /// 更新理由を取得または設定します
        /// </summary>
        public string Reason { get; set; } = string.Empty;

        /// <summary>
        /// 更新日時を取得または設定します
        /// </summary>
        [Column(TypeName ="timestamp without time zone")]
        public DateTime DateTime { get; set; }
    }
}
