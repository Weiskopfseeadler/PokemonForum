using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
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
        //public DbSet<ApplicationsUser> ApplicationsUsers {get; set;}
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            var threadIds = 1;
            var testThread = new Faker<Thread>()
                .RuleFor(a => a.ThreadID, () => threadIds++)
                .RuleFor(a => a.Title, f => f.Lorem.Slug(8));
                

            var artIds = 1;
            var testArticle = new Faker<Article>()
                .RuleFor(art => art.ArticleID, () => artIds++)
                .RuleFor(art => art.Text, f => f.Lorem.Slug(100));

            var threads = new List<dynamic>();
            var articles = new List<dynamic>();

            var rnd = new Random();


            foreach(var thread in testThread.Generate(5)) // thread, thema, Team
            {
                threads.Add(new
                {
                    ThreadID = thread.ThreadID, // genau auf die Schreibweise achten! -> kein Intellisense
                    Name = thread.Title
                });
            }

            foreach(var article in testArticle.Generate(5)) // thread, thema, Team
            {
                threads.Add(new
                {
                    ArticleID = article.ArticleID, // genau auf die Schreibweise achten! -> kein Intellisense
                    Text = article.Text
                });
            }
            
            modelBuilder.Entity<Thread>().HasData(testThread.Generate(6));
        }
    }
}
