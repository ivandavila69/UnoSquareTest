using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnoSquareTest.Models
{
    public class BoardGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Players { get; set; }
        public string Category { get; set; }
        public string Ages { get; set; }
        public string Comments { get; set; }

        public BoardGame(int id, string name, int players, string category, string ages, string comments)
        {
            this.Id = id;
            this.Name = name;
            this.Players = players;
            this.Category = category;
            this.Ages = ages;
            this.Comments = comments;
        }
    }
}