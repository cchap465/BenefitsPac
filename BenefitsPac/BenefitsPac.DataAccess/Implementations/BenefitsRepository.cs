using BenefitsPac.Core.Models;
using BenefitsPac.Core.Models.DataModels;
using BenefitsPac.DataAccess.Abstractions;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BenefitsPac.DataAccess.Implementations
{
    public class BenefitsRepository : IBenefitsRepository
    {
        private ConnectionStrings connectionStrings;

        public BenefitsRepository(IOptions<ConnectionStrings> settings)
        {
            connectionStrings = settings.Value;
        }

        public async Task<IEnumerable<BenefitCostDataModel>> GetBenefitsCostsByEmployeeId(int employeeId)
        {
            using (IDbConnection db = new SqlConnection(connectionStrings.ConnBenefitsPac))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", employeeId);
                return await db.QueryAsync<BenefitCostDataModel>("GetBenefitCostsByEmployeeId", 
                    parameters, 
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
