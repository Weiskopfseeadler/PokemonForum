using System;
using System.Collections.Generic;
using ForumPokemon.Models;

namespace PokemonForum.Models
{
    public class ForumThreadViewModel{
      public  string thredID {get; set;}
      public string text{get; set;}

      public List<Article> articlesList {get; set;}

    }
    }