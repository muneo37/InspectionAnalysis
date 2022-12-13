using System.Drawing;
using XACs.NET;

using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InspectionAnalysis.Client.ViewModels
{
    public class TopViewModel : NotificationObject
    {
        private string _fixedString = "こっちが表示？";

        public void ToggleDisplay()
        {
            this.DisplayString = string.IsNullOrEmpty(this.DisplayString) ? _fixedString : string.Empty;
        }

        public string DisplayString { get; set; } = "表示出来た";

        #region フィールド

        /// <summary>
        /// チャート
        /// </summary>
        private ChartContents? _judgeBarChartContents;

        private NavigationManager _navigation;

        private HubConnection? _hubConnection;

        #endregion


        #region プロパティ

        /// <summary>
        /// チャートプロパティ
        /// </summary>
        public ChartContents? JudgeBarChartContents
        {
            get => this._judgeBarChartContents;
            set { SetProperty(ref this._judgeBarChartContents, value); }
        }
        #endregion


        #region コマンド
        /// <summary>
        /// チャート表示コマンド
        /// </summary>
        public DelegateCommand CreateChartCommand { get; private set; }
        #endregion


        #region メソッド
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TopViewModel()
        {
            this.CreateChartCommand = new DelegateCommand(_ => CreateChart());

            var task = InitializedAsync();
            //task.Wait();

            int test = 10;
        }

        protected async Task InitializedAsync()
        {
            this._hubConnection = new HubConnectionBuilder().WithUrl("https://localhost:7093/inspectresulthub").Build();
            this._hubConnection.On<IEnumerable<InspectResult>>("ReceiveData", results =>
            {
                var test = results;
            });

            await this._hubConnection.StartAsync();
        }

        /// <summary>
        /// チャート表示更新
        /// </summary>
        private void CreateChart()
        {
            var task = Send();

            task.Wait();
            //int[] ok = {4,5,6,7};

            //var item = new ChartItem(ok) { BackgroundColor = Color.FromArgb(255, 114, 125, 242) };

            //List<ChartItem> items = new List<ChartItem>();

            //items.Add(item);

            //string[] labels = { "\"8/10\"", "\"8/11\"", "\"8/12\"", "\"8/13\"" };

            //this.JudgeBarChartContents = new ChartContents()
            //{
            //    Type = "bar",
            //    Labels = labels,
            //    Items = items,
            //    Options = "\"options\": {\"responsive\": true, \"maintainAspectRatio\": false}"
            //};
        }

        private async Task Send()
        {
            if (this._hubConnection is not null)
            {
                await this._hubConnection.SendAsync("SendData", DateTime.Parse("2022/11/08"), DateTime.Parse("2022/11/14"));
            }
        }

        #endregion

    }
}
