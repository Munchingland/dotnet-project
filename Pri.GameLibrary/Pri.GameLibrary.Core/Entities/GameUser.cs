using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.GameLibrary.Core.Entities
{
    public class GameUser
    {
        public int GameId { get; set; }
        public int UserId { get; set; }
        public Game Game { get; set; }
        public User User { get; set; }
        public int ReviewId { get; set; }
        public Review Review { get; set; }

    }
}
