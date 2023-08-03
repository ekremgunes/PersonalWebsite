using System.Text.RegularExpressions;

namespace gunesekremcom.Tools.Helpers
{
    public static class ReadingTime
    {
        private const int readingSpeed = 1250; //char count per min
        public static ushort Calculate(string text)
        {
            text = RemoveTags(text);

            var characterCount = text.Length;
            var readingTime = characterCount / readingSpeed;

            if (readingTime < 1)
            {
                return 1;
            }

            return (ushort)readingTime;
        }

        static string RemoveTags(string text)
        {
            text = Regex.Replace(text, "<.*?>", string.Empty);
            return text;
        }
    }

}
