using BenefitsPac.Core.DataAccessAbstractions;
using BenefitsPac.Core.Models;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BenefitsPac.DataAccess
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private ConnectionStrings connectionStrings;

        public EmployeeRepository(IOptions<ConnectionStrings> settings)
        {
            connectionStrings = settings.Value;
        }

        public async Task<EmployeeDataModel> GetById(int employeeId)
        {
            using (IDbConnection db = new SqlConnection(connectionStrings.ConnBenefitsPac))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", employeeId);
                return await db.QueryFirstOrDefaultAsync<EmployeeDataModel>("GetEmployeeById",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<EmployeeDataModel>> GetAll()
        {
            using (IDbConnection db = new SqlConnection(connectionStrings.ConnBenefitsPac))
            {
                DynamicParameters parameters = new DynamicParameters();
                return await db.QueryAsync<EmployeeDataModel>("GetEmployees",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> Create(EmployeeDataModel employee)
        {
            using (IDbConnection db = new SqlConnection(connectionStrings.ConnBenefitsPac))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeName", employee.EmployeeName);
                parameters.Add("@DiscountAmount", employee.BenefitCost.DiscountAmount);
                parameters.Add("@BaseDeductionCost", employee.BenefitCost.BaseDeductionCost);
                parameters.Add("@PaymentFrequency", employee.EmployeeSalaryData.PaymentFrequency);
                parameters.Add("@SalaryByPayPeriod", employee.EmployeeSalaryData.SalaryByPayPeriod);
                parameters.Add("@RESULT", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                await db.ExecuteAsync("CreateEmployee",
                    parameters,
                    commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("@RESULT");
            }
        }

        public async Task<int> Update(int employeeId, string employeeName)
        {
            using (IDbConnection db = new SqlConnection(connectionStrings.ConnBenefitsPac))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", employeeId);
                parameters.Add("@EmployeeName", employeeName);

                await db.ExecuteAsync("UpdateEmployeeById",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return employeeId;
            }
        }

        public async Task<int> Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionStrings.ConnBenefitsPac))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", id);
                return await db.ExecuteAsync("DeleteEmployeeById",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<EmployeeSalaryDataModel> GetEmployeeSalaryData(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionStrings.ConnBenefitsPac))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", id);
                return await db.QueryFirstOrDefaultAsync<EmployeeSalaryDataModel>("GetEmployeeSalaryBreakdownByEmployeeId",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
