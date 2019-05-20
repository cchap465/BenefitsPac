using BenefitsPac.Core.Models.DataModels;

namespace BenefitsPac.Core.Models.DomainModels
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public EmployeeModel() {}

        public EmployeeModel(EmployeeDataModel employee)
        {
            EmployeeId = employee?.EmployeeId ?? 0;
            EmployeeName = employee?.EmployeeName ?? string.Empty;
        }
    }
}
