using Adverts.Core.Entities;
using Adverts.Infrastructure.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Adverts.Infrastructure.Repository
{
    public class AdvertVisitRepository : IAdvertVisitRepository
    {
        private readonly IConfiguration configuration;

        public AdvertVisitRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(AdvertVisits entity)
        {
            var sql = $"Insert into AdvertVisits (advertId,iPAdress,visitDate) VALUES ({entity.advertId},'{entity.ipAdress}','{ entity.visitDate.ToString("yyyy-MM-dd HH:mm:ss")}')";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<AdvertVisits>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AdvertVisits> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(AdvertVisits entity)
        {
            throw new NotImplementedException();
        }
    }
}
