using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.GameLibrary.Api.Services.Models
{
    public class AuthenticationResultModel
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
        public List<string> Errors { get; set; }
    }
}
