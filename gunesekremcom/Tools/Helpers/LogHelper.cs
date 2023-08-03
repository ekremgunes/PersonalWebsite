using Microsoft.AspNetCore.Diagnostics;

namespace gunesekremcom.Tools.Helpers
{
    public static class LogHelper
    {
        public static void Log(string? message, IExceptionHandlerPathFeature? errorInfo, int? code)
        {

            var strPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\ErrorLogs\\Error_Log.text");
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }

            if (message == null)
            {
                using (StreamWriter sw = File.AppendText(strPath))
                {
                    sw.WriteLine("========= Error Logging =======");
                    sw.WriteLine("=========== Start ============= ");
                    sw.WriteLine("Error Message: " + errorInfo?.Error.Message);
                    sw.WriteLine("Error Source: " + errorInfo?.Error.Source);
                    sw.WriteLine("Error Code: " + code.ToString());
                    sw.WriteLine("Stack Trace: " + errorInfo?.Path);
                    sw.WriteLine("Date : " + DateTime.Now.ToString());
                    sw.WriteLine("=========== End =============");

                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(strPath))
                {
                    sw.WriteLine("========= Error Logging =======");
                    sw.WriteLine("=========== Start ============= ");
                    sw.WriteLine("Error Message: " + message);
                    sw.WriteLine("Date : " + DateTime.Now.ToString());
                    sw.WriteLine("=========== End =============");

                }
            }
        }
    }
}
