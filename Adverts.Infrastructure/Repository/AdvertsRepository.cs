using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Adverts.Infrastructure.Interfaces;
using System.Linq;
using Adverts.Core.Models;
using Adverts.Common.Helper;

namespace Adverts.Infrastructure.Repository
{
    public class AdvertsRepository : IAdvertsRepository
    {
        private readonly IConfiguration configuration;

        public AdvertsRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(Core.Entities.Adverts entity)
        {
            var sql = "Insert into Products (Name,Description,Barcode,Rate,AddedOn) VALUES (@Name,@Description,@Barcode,@Rate,@AddedOn)";
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

        public async Task<IReadOnlyList<Core.Entities.Adverts>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Core.Entities.Adverts>> GetAllAsync(FilteringModel filteringModel, SortingModel sortingModel)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("select *,COUNT(*) OVER () as totalCount from [dbo].[Adverts](nolock)");
            sqlQuery.Append(SqlQueryHelper.WhereConditions(filteringModel));
            sqlQuery.Append(SqlQueryHelper.SortingConditions(sortingModel));
            sqlQuery.Append(" OFFSET @Offset ROWS FETCH NEXT @Next ROWS ONLY");

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                Pageable pager = new Pageable(filteringModel.page);

                var result = connection.Query<Core.Entities.Adverts>(sqlQuery.ToString(), pager).ToList();
                return result;
            }
        }

        public async Task<Core.Entities.Adverts> GetByIdAsync(int id)
        {
            string sqlQuery = $"select * from [dbo].[Adverts](nolock) WHERE id = {id}";         

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                var result = connection.QuerySingle<Core.Entities.Adverts>(sqlQuery.ToString());
                return result;
            }
        }

        public Task<int> UpdateAsync(Core.Entities.Adverts entity)
        {
            throw new NotImplementedException();
        }
    }
}
