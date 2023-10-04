using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.GameLibrary.Core.Entities
{
    public class Review : BaseEntity
    {
        public string Description { get; set; }
        public int Rating { get; set; }
    }
}
