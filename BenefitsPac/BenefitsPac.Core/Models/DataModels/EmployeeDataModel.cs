using BenefitsPac.Core.Models.DomainModels;

namespace BenefitsPac.Core.Models.DataModels
{
    public class EmployeeDataModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public BenefitCostDataModel BenefitCost { get; set; }
        public EmployeeSalaryDataModel EmployeeSalaryData { get; set; }

        public EmployeeDataModel() {}

        public EmployeeDataModel(EmployeeModel employeeModel, decimal discountAmount)
        {
            EmployeeId = employeeModel?.EmployeeId ?? 0;
            EmployeeName = employeeModel?.EmployeeName ?? string.Empty;
            BenefitCost = new BenefitCostDataModel()
            {
                IsEmployee = true,
                DiscountAmount = discountAmount,
                BaseDeductionCost = 1000,
            };
            EmployeeSalaryData = new EmployeeSalaryDataModel(); 
        }
    }
}
