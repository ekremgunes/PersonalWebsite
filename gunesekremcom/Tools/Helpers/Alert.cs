namespace gunesekremcom.Tools
{
    public enum AlertType
    {
        Success = 1,
        Warning = 2,
        Error = 3,
        Info = 4
    }
    public static class Alert
    {

        public static string ViewAlert(AlertType alert = AlertType.Info, string alertMessage = "Info")
        {
            if (alert == AlertType.Success)
            {
                return $"<span class='successAlert'>{alertMessage}</span>";
            }
            else if (alert == AlertType.Warning)
            {
                return $"<span class='warningAlert'>{alertMessage}</span>";
            }
            else if (alert == AlertType.Error)
            {
                return $"<span class='errorAlert'>{alertMessage}</span>";
            }
            else
            {
                return $"<span class='infoAlert'>{alertMessage}</span>";
            }
        }

    }
}
