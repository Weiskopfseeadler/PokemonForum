using System;

namespace ForumPokemon.Models
{
    public class Article
    {
        public long ArticleID {get; set;}
        public string Text {get; set;}
        public ApplicationsUser ApplicationUser {get; set;}
        public Thread Thread {get; set;}
        public DateTime Date {get; set;}
        public Image Image {get; set;}
    }
}