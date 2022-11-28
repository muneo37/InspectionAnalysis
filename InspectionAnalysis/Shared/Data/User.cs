using System;
using System.Collections.Generic;

namespace InspectionAnalysis
{
    /// <summary>
    /// ユーザー情報を表すクラスです
    /// </summary>
    public class User
    {

        /// <summary>
        /// 識別子を設定または取得します
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 名前を取得または取得します
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 権限を設定または取得します
        /// </summary>
        public int Authority { get; set; }
    }
}
