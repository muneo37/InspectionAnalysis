using System;
using System.Collections.Generic;

namespace InspectionAnalysis
{
    /// <summary>
    /// 品種データを表すクラスです
    /// </summary>
    public class WorkData
    {
        /// <summary>
        /// 品種識別子を設定または取得します
        /// </summary>
        public int WorkDataId { get; set; }

        /// <summary>
        /// 品種名を設定または取得します
        /// </summary>
        public string WorkDataName { get; set; } = string.Empty;

        /// <summary>
        /// 作成ユーザー識別子を設定または取得します
        /// </summary>
        public int UserId { get; set; }
        public User User { get; set; } = new User();

        /// <summary>
        /// 更新ログを設定または取得します
        /// </summary>
        public List<WorkDataChangeLog>? WorkDataChangeLog { get; set; }
    }
}
