namespace BenefitsPac.Core.Models.ApiModel
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public EmployeeModel() {}

        public EmployeeModel(EmployeeDataModel employee)
        {
            EmployeeId = employee.EmployeeId;
            EmployeeName = employee.EmployeeName;
        }
    }
}
