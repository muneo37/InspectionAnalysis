using System.Windows.Input;

/// <summary>
/// System.Windows.Input.ICommand インターフェースを実装したコマンド機能を提供します。
/// </summary>
public class DelegateCommand : ICommand
{
    /// <summary>
    /// 新しいインスタンスを生成します。
    /// </summary>
    /// <param name="execute">コマンド実行のデリゲートを指定します。</param>
    public DelegateCommand(Action<object?> execute)
        : this(execute, null)
    {
    }

    /// <summary>
    /// 新しいインスタンスを生成します。
    /// </summary>
    /// <param name="execute">コマンド実行のデリゲートを指定します。</param>
    /// <param name="canExecute">コマンド実行可能判別のデリゲートを指定します。</param>
    public DelegateCommand(Action<object?> execute, Func<object?, bool>? canExecute)
    {
        this._execute = execute;
        this._canExecute = canExecute;
    }

    /// <summary>
    /// コマンド実行可能判別条件が変更されたときに発生します。
    /// </summary>
    public event EventHandler? CanExecuteChanged;

    /// <summary>
    /// CanExecuteChanged イベントを発行します。
    /// </summary>
    public void RaiseCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);

    /// <summary>
    /// コマンドが実行可能かどうかを判別します。
    /// </summary>
    /// <param name="parameter">コマンドに対するパラメータを指定します。</param>
    /// <returns>コマンドが実行可能な場合に true を返します。</returns>
    public bool CanExecute(object? parameter) => this._canExecute?.Invoke(parameter) ?? true;

    /// <summary>
    /// コマンドを実行します。
    /// </summary>
    /// <param name="parameter">コマンドに対するパラメータを指定します。</param>
    public void Execute(object? parameter) => this._execute.Invoke(parameter);

    /// <summary>
    /// コマンド実行のデリゲート
    /// </summary>
    private Action<object?> _execute;

    /// <summary>
    /// コマンド実行可能判定のデリゲート
    /// </summary>
    private Func<object?, bool>? _canExecute;
}