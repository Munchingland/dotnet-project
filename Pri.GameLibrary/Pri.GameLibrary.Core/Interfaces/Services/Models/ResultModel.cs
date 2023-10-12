using Pri.GameLibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.GameLibrary.Core.Interfaces.Services.Models
{
    public class ResultModel<T> where T : BaseEntity
    {
        public bool IsSuccess { get; set; }
        public IEnumerable<T> Items { get; set; }
        public List<string> Errors { get; set; }
    }
}
