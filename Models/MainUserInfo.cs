using Love.Models.Abstracts;

namespace Love.Models
{
    public class MainUserInfo: BaseEntity
    {
        public string? userName { get; set; }
        public string? userEmail { get; set; }
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
    }
}