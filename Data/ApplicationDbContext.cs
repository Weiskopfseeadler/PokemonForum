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
                .RuleFor(art => art.Text, f => f.Lorem.Slug(100))
                .RuleFor(art => art.Time, f => f.Date.Past());

            var userIds = 1;
            var testUser = new Faker<ApplicationsUser>()
                .RuleFor(usr => usr.ApplicationsUserID, () => userIds++)
                .RuleFor(usr => usr.Id, f => f.Internet.UserName())
                .RuleFor(usr => usr.NickName, f => f.Name.FirstName())
                .RuleFor(usr => usr.Email, f=> f.Internet.Email())
                .RuleFor(usr => usr.AccessFailedCount, () => 0)
                .RuleFor(usr => usr.EmailConfirmed, () => true)
                .RuleFor(usr => usr.LockoutEnabled, () => false);


            var imageIds = 1;
            var TestImage = new Faker<Image>()
                .RuleFor(imag => imag.ImageID, () => imageIds++)
                .RuleFor(imag => imag.Name,f => f.Name.LastName())
                .RuleFor(imag => imag.Path, @"C:\Users\vmadmin\Desktop\PokemonForum\nothing")
                .RuleFor(imag => imag.isAvatar,f => f.Random.Bool());

            var images = new List<dynamic>();
            var threads = new List<dynamic>();
            var articles = new List<dynamic>();
            var applicationsUsers = new List<dynamic>();

            var rnd = new Random();

            foreach(var imag in TestImage.Generate(5)){
                images.Add(new{
                Name =  imag.Name,
                ImageID = imag.ImageID,
                Path = imag.Path,
                isAvatar = imag.isAvatar
                });
              
            }

            foreach(var thread in testThread.Generate(5)) // thread, thema, Team
            {
                threads.Add(new
                {
                    ThreadID = thread.ThreadID, // genau auf die Schreibweise achten! -> kein Intellisense
                    Title = thread.Title
                    
                });
            }

            foreach(var article in testArticle.Generate(5)) // thread, thema, Team
            {
                articles.Add(new
                {
                    ArticleID = article.ArticleID, // genau auf die Schreibweise achten! -> kein Intellisense
                    ThreadId =rnd.Next(1, threadIds),
                    Text = article.Text,
                    Time = article.Time  
                });
            }

            foreach(var user in testUser.Generate(10))
            {
                applicationsUsers.Add(new
                {
                    ApplicationsUserID =  user.ApplicationsUserID,
                    Id = user.Id,                
                    NickName = user.NickName,
                    Email = user.Email,
                    AccessFailedCount = user.AccessFailedCount,
                    EmailConfirmed = user.EmailConfirmed,
                    LockoutEnabled = user.LockoutEnabled,
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                });
                
  
                
            }

/*
            modelBuilder.Entity<Thread>().HasData(thread.ToArray())
            modelBuilder.Entity<Article>().HasData(articles.ToArray());
            modelBuilder.Entity<Image>().HasData(images.ToArray());
            
            
            modelBuilder.Entity<ApplicationsUser>().HasData(applicationsUsers.ToArray());*/
             modelBuilder.Entity<ApplicationsUser>().HasData(applicationsUsers.ToArray());

            // add todoitem
            modelBuilder.Entity<Image>().HasData(images.ToArray());

            // add role
            modelBuilder.Entity<Thread>().HasData(threads.ToArray());

            // add user
            modelBuilder.Entity<Article>().HasData(articles.ToArray());

            // add assignment
           
           base.OnModelCreating(modelBuilder);
        }
    }
}
