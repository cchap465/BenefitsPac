using System.Collections.Generic;

namespace BenefitsPac.Core.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasDiscount { get; set; }
        public decimal Discount { get; set; }
        public IEnumerable<DependentModel> Dependents { get; set; }
        public SalaryModel SalaryData { get; set; }
    }
}
