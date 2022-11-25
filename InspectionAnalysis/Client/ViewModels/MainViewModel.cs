using System.Reflection;
using XACs.NET;

namespace InspectionAnalysis.Client.ViewModels;
public class MainViewModel : NotificationObject
{
    public string ProductName
    {
        get => Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyProductAttribute>()?.Product ?? "名無し";
    }
}

