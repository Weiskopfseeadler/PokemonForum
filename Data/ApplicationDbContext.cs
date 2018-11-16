using System;
using System.Collections.Generic;
using System.Text;
using ForumPokemon.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PokemonForum.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //Pro model 1 getter und setter
        public DbSet<Article> Articles {get; set;} 
        public DbSet<Image> Images {get; set;}
        public DbSet<Thread> Threads {get; set;}
        public DbSet<ApplicationsUser> ApplicationsUsers {get; set;}
    }
}
