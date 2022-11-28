using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InspectionAnalysis;
using Microsoft.EntityFrameworkCore;

namespace InspectionAnalysis.Operator
{
    /// <summary>
    /// データベースからデータを読み込むクラスです
    /// </summary>
    public class Select : IDisposable
    {
        private static InspectionDatasContext _db;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        static Select()
        {
            _db = new InspectionDatasContext();
        }
        #region InspectResult関係
        /// <summary>
        /// 検査結果を全て取得
        /// </summary>
        /// <returns>検査結果</returns>
        public static IEnumerable<InspectResult> InspectResultAll()
        {
            return _db.InspectResults;
        }
        /// <summary>
        /// ID条件から検査結果を取得します。
        /// </summary>
        /// <param name="lowerValue">下限値</param>
        /// <param name="upperValue">上限値</param>
        /// <returns>条件範囲内の検査結果データリスト</returns>
        public static IEnumerable<InspectResult> InspectResultWhereId(int lowerValue,int upperValue)
        {
            return _db.InspectResults.Where(i => (lowerValue <= i.InspectResultId) && (i.InspectResultId <= upperValue));
        }

        /// <summary>
        /// 検査時間条件から検査結果を取得します。
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns>指定範囲内の検査結果データリスト</returns>
        public static IEnumerable<InspectResult> InspectResultWhereTime(DateTime startTime, DateTime endTime)
        {
            return _db.InspectResults.Where(i => (startTime <= i.InspTime) && (i.InspTime <= endTime));
        }

        /// <summary>
        /// IDで検査結果を取得します。
        /// </summary>
        /// <param name="equalValue"></param>
        /// <returns>指定IDの検査結果</returns>
        public static InspectResult? InspectResultWhereId(int equalValue)
        {
            try {
                return InspectResultWhereId(equalValue, equalValue).First();
            } catch
            {
                return null;
            }
        }
        #endregion

        #region User関係
        /// <summary>
        /// すべてのユーザーリストを取得します
        /// </summary>
        /// <returns></returns>
        public static int UserAll()
        //public static IEnumerable<User> UserAll()
        {
            IEnumerable<User> test = _db.Users;
            return 5;
        }

        /// <summary>
        /// Idの上限値下限値を設定し、条件にあったUserリストを取得します
        /// </summary>
        /// <param name="lowerValue">下限値</param>
        /// <param name="upperValue">上限値</param>
        /// <returns>Userリスト</returns>
        public static IEnumerable<User> UserWhereId(int lowerValue, int upperValue)
        {
            return _db.Users.Where(u => (lowerValue <= u.UserId) && (u.UserId <= upperValue));
        }

        /// <summary>
        /// Idを指定し、条件にあったUserを取得します
        /// </summary>
        /// <param name="equalValue">検索するId値</param>
        /// <returns>User</returns>
        public static User? UserWhereId(int equalValue)
        {
            try
            {
                return UserWhereId(equalValue, equalValue).First();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// ユーザー名を指定し、条件に合致したUserリストを取得します
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<User> UserWhereName(string name)
        {
            return _db.Users.Where(u => u.Name == name);
        }

        /// <summary>
        /// 権限の上限値下限値を設定し、条件にあったUserリストを取得します
        /// </summary>
        /// <param name="lowerValue">下限値</param>
        /// <param name="upperValue">上限値</param>
        /// <returns>Userリスト</returns>
        public static IEnumerable<User> UserWhereAuthority(int lowerValue, int upperValue)
        {
            return _db.Users.Where(u => (lowerValue <= u.Authority) && (u.Authority <= upperValue));
        }

        /// <summary>
        /// 権限を指定し、条件にあったUserを取得します
        /// </summary>
        /// <param name="equalValue">検索する権限</param>
        /// <returns>User</returns>
        public static User? UserWhereAuthority(int equalValue)
        {
            try
            {
                return UserWhereAuthority(equalValue, equalValue).First();
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region WorkData関係
        public static IEnumerable<WorkData> WorkDataAll()
        {
            return _db.WorkDatas;
        }

        public static IEnumerable<WorkData> WorkDataWhereId(int lowerValue, int upperValue)
        {
            return _db.WorkDatas.Where(w => (lowerValue <= w.WorkDataId) && (w.WorkDataId <= upperValue));
        }

        public static WorkData? WorkDataWhereId(int equalValue)
        {
            try
            {
                return WorkDataWhereId(equalValue, equalValue).First();
            }
            catch
            {
                return null;
            }
        }


        #endregion


        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
