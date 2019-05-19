using BenefitsPac.Core.DataAccessAbstractions;
using BenefitsPac.Core.Models;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsPac.DataAccess
{
    public class DependentsRepository : IDependentsRepository
    {
        private ConnectionStrings connectionStrings;

        public DependentsRepository(IOptions<ConnectionStrings> settings)
        {
            connectionStrings = settings.Value;
        }

        public async Task<int> Create(DependentDataModel dependent)
        {
            using (IDbConnection db = new SqlConnection(connectionStrings.ConnBenefitsPac))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DependentName", dependent.DependentName);
                parameters.Add("@DiscountAmount", dependent.BenefitCost.DiscountAmount);
                parameters.Add("@BaseDeductionCost", dependent.BenefitCost.BaseDeductionCost);
                parameters.Add("@EmployeeId", dependent.EmployeeId);
                parameters.Add("@RESULT", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                await db.ExecuteAsync("CreateDependent",
                    parameters,
                    commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("@RESULT");
            }
        }

        public async Task<IEnumerable<DependentDataModel>> GetByEmployeeId(int employeeId)
        {
            using (IDbConnection db = new SqlConnection(connectionStrings.ConnBenefitsPac))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", employeeId);
                return await db.QueryAsync<DependentDataModel>("GetDependentsByEmployeeId",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionStrings.ConnBenefitsPac))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DependentId", id);
                await db.ExecuteAsync("DeleteDependentById",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return id;
            }
        }
    }
}
