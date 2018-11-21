using System;
using Microsoft.AspNetCore.Identity;

namespace ForumPokemon.Models
{
    public class ApplicationsUser : IdentityUser
    {
        public long ApplicationsUserID {get; set;}
        public string NickName {get; set;}
        public string Password {get; set;}
        
        //public string Email {get; set;}
        public Image Avatar {get; set;}


    }
}