using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.GameLibrary.Core.Interfaces.Services.Models
{
    public class GameUpdateModel
    {
        public IEnumerable<int> PlatformIds {  get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int DeveloperId { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
