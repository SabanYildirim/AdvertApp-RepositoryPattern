using Adverts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Adverts.Infrastructure.Interfaces
{
    public interface IAdvertsRepository : IGenericRepository<Core.Entities.Adverts>
    {
        Task<IReadOnlyList<Core.Entities.Adverts>> GetAllAsync(FilteringModel filteringModel, SortingModel sortingModel);
    }
}
