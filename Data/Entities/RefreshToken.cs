using System.ComponentModel.DataAnnotations;

namespace MyProject.API.Data.Entities
{
    public class RefreshToken : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string JwtTokenId { get; set; }
        public string Refresh_Token { get; set; }
        public bool IsValid { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
