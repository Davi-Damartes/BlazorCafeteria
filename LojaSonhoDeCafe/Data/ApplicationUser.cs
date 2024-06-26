using Microsoft.AspNetCore.Identity;

namespace LojaSonhoDeCafe.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string? Nome { get; set; }
        public DateOnly? DataNascimento { get; set; }

    }

}
