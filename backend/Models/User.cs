using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace backend.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        public long Id { get; set; }

        public string? Name { get; set; }

        public string Email { get; set; } = null!;

        [JsonIgnore]
        public string PasswordHash { get; private set; } = null!;

        public void SetPassword(string password)
        {
            var hasher = new PasswordHasher<User>();
            PasswordHash = hasher.HashPassword(this, password);
        }
    }

}
