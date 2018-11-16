using System;
using System.Collections.Generic;


namespace ForumPokemon.Models
{
    public class Thread
    {
        public long ThreadID {get; set;}
        public string Title{get; set;}
        public string ImagePath {get; set;}
        public ICollection<Article> Articles {get; set;}
    }
}