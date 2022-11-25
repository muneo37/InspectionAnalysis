using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XACs.NET
{
    /// <summary>
    /// <c>System.ComponentModel.INotifyPropertyChanged</c> を実装したクラスを提供します。
    /// </summary>
    [Serializable]
    public class NotificationObject : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged のメンバ

        /// <summary>
        /// プロパティ値が変更されたときに発生します。
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion INotifyPropertyChanged のメンバ

        /// <summary>
        /// PropertyChanged イベントを発行します。
        /// </summary>
        /// <param name="propertyName">値が変更されたプロパティ名を指定します。</param>
        protected void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            var h = this.PropertyChanged;
            if (h != null) h(this, new PropertyChangedEventArgs(propertyName));
        }


        /// <summary>
        /// プロパティ値を変更するヘルパです
        /// </summary>
        /// <typeparam name="T">プロパティの型を表します。</typeparam>
        /// <param name="target">変更するプロパティの実体を ref 指定します。</param>
        /// <param name="value">変更後の値を指定します。</param>
        /// <param name="otherPropertyName">他プロパティ名を指定します。</param>
        /// <param name="propertyName">プロパティ名を指定します。</param>
        /// <returns>プロパティ値に変更があった場合に true を返します。</returns>
        protected bool SetProperty<T>(ref T target, T value, string? otherPropertyName = null, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(target, value))
                return false;

            target = value;
            RaisePropertyChanged(propertyName);
            if (otherPropertyName != null)
            {
                RaisePropertyChanged(otherPropertyName);
            }
            return true;
        }

        /// <summary>
        /// プロパティ値を変更するヘルパです
        /// </summary>
        /// <typeparam name="T">プロパティの型を表します。</typeparam>
        /// <param name="target">変更するプロパティの実体を ref 指定します。</param>
        /// <param name="value">変更後の値を指定します。</param>
        /// <param name="otherPropertyNames">他プロパティ名を指定します。</param>
        /// <param name="propertyName">プロパティ名を指定します。</param>
        /// <returns>プロパティ値に変更があった場合に true を返します。</returns>
        protected bool SetProperty<T>(ref T target, T value, string[] otherPropertyNames, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(target, value))
                return false;

            target = value;
            RaisePropertyChanged(propertyName);
            foreach (var name in otherPropertyNames)
            {
                RaisePropertyChanged(name);
            }
            return true;
        }


    }
}