using System;

namespace ForumPokemon.Models
{
    public class Image
    {
        public long ImageID {get; set;}
        public string Name {get; set;}
        public string Path {get; set;}
        public ApplicationsUser ApplicationsUser {get; set;}
    }
}