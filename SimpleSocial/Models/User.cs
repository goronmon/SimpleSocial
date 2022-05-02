using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SimpleSocial.Models
{
    public class User : IdentityUser
    {
        public List<Post> Posts { get;set; }
    }
}