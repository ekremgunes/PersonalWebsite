using System.Text.RegularExpressions;

namespace gunesekremcom.Tools
{
    public static class SlugMaker
    {
        public async static Task<string> Make(string title)
        {
            // Türkçe karakterleri temizle
            title = title.Replace("ı", "i")
                         .Replace("ü", "u")
                         .Replace("ö", "o")
                         .Replace("ç", "c")
                         .Replace("ş", "s")
                         .Replace("ğ", "g");

            // Boşlukları tire ile değiştir
            title = Regex.Replace(title, @"\s", "-");

            // Gereksiz karakterleri kaldır
            title = Regex.Replace(title, @"[^a-zA-Z0-9\-]", "");

            // Birden fazla tireyi tek tireye indirge
            title = Regex.Replace(title, @"\-+", "-");

            // Başta ve sonda kalan tireleri kaldır
            title = title.Trim('-');

            // Küçük harflere çevir
            title = title.ToLower();

            //benzersiz bir guid değer ile slug üreterek dönüş yap
            return $"{title}_{Guid.NewGuid()}";
        }
    }
}
