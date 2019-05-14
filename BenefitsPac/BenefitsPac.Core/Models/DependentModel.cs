using System.Collections.Generic;

namespace BenefitsPac.Core.Models
{
    public class DependentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public bool HasDiscount { get; set; }
        public decimal Discount { get; set; }
    }
}
