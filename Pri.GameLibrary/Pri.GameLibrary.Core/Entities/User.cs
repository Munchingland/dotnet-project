

using Microsoft.AspNetCore.Identity;

namespace Pri.GameLibrary.Core.Entities
{
    public class User : IdentityUser
    {
        public DateTime BirthDay { get; set; }
        public ICollection<GameUser> Games { get; set; }
        public bool? HasApprovedTermsAndConditions { get; set; }
    }
}