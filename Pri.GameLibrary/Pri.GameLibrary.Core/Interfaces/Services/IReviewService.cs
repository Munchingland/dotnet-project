using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.GameLibrary.Core.Interfaces.Services
{
    public interface IReviewService
    {
        public Task<double> GetAverageScoreAsync(int id);
    }
}
