using BenefitsPac.Core.Models;
using BenefitsPac.DataAccess.Abstractions;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BenefitsPac.DataAccess.Implementations
{
    public class LoggerRepository : ILoggerRepository
    {
        private ConnectionStrings connectionStrings;

        public LoggerRepository(IOptions<ConnectionStrings> settings)
        {
            connectionStrings = settings.Value;
        }

        public async Task Log(Exception exception)
        {
            using (IDbConnection db = new SqlConnection(connectionStrings.ConnBenefitsPac))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ExceptionDateTime", DateTime.UtcNow);
                parameters.Add("@PageOfOrigin", exception.Source);
                parameters.Add("@CallStack", exception.StackTrace);
                parameters.Add("@ExceptionMessage", exception.Message);

                await db.ExecuteAsync("CreateExceptionLog",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
