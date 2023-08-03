namespace gunesekremcom.Tools
{
    public static class TimeHelper
    {
        public static string Invoke(DateTime oldDate)
        {
            DateTime newDate = DateTime.Now;

            TimeSpan timeSpan = newDate.Subtract(oldDate);

            if (timeSpan.Days / 365 > 0)
            {
                return $"{timeSpan.Days / 365} yıl önce";
            }
            else if (timeSpan.Days / 30 > 0)
            {
                return $"{timeSpan.Days / 30} ay önce";

            }
            else if (timeSpan.Days / 7 > 0)
            {
                return $"{timeSpan.Days / 7} hafta önce";

            }
            else if (timeSpan.Days > 0)
            {
                return $"{timeSpan.Days} gün önce";

            }
            else if (timeSpan.Hours > 0)
            {
                return $"{timeSpan.Hours} saat önce";

            }
            else if (timeSpan.Minutes > 0)
            {
                return $"{timeSpan.Minutes} dakika önce";

            }
            else
            {
                return $"{timeSpan.Seconds} sn önce";

            }
        }
    }
}
