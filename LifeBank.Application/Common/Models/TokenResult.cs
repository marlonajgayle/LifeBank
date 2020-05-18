namespace LifeBank.Application.Common.Models
{
    public class TokenResult
    {
        public bool Succeeded { get; set; }
        public string Error { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
