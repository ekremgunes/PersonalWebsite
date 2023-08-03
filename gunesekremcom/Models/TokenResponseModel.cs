namespace gunesekremcom.Models
{
    public class TokenResponseModel
    {
        public TokenResponseModel(string token, DateTime expireDate)
        {
            Token = token;
            ExpireDate = expireDate;
        }

        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
