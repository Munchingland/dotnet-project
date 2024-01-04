using Pri.GameLibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.GameLibrary.Core.Interfaces.Services.Models
{
    public class LibraryResultModel
    {
        public bool IsSuccess { get; set; }
        public IEnumerable<GameUser> Items { get; set; }
        public List<string> Errors { get; set; }
    }
}
