namespace InspectionAnalysis.Client.ViewModels
{
    public class TopViewModel
    {
        private string _fixedString = "こっちが表示？";

        public void ToggleDisplay()
        {
            this.DisplayString = string.IsNullOrEmpty(this.DisplayString) ? _fixedString : string.Empty;
        }

        public string DisplayString { get; set; } = "表示出来た";


    }
}
