namespace Love.Models.Abstracts
{
    public abstract class TokenModel
    {
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
    }
}