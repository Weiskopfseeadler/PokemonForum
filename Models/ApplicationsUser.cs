using System;
using Microsoft.AspNetCore.Identity;

namespace ForumPokemon.Models
{
    public class ApplicationsUser : IdentityUser
    {
        public long UserID {get; set;}
        public string Username {get; set;}
        public string Password {get; set;}
        public string Email {get; set;}
        public string Avatar {get; set;}
        
    }
}