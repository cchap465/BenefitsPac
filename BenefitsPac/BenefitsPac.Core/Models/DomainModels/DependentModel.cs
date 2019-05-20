using BenefitsPac.Core.Models.DataModels;

namespace BenefitsPac.Core.Models.DomainModels
{
    public class DependentModel
    {
        public int DependentId { get; set; }
        public string DependentName { get; set; }
        public int EmployeeId { get; set; }

        public DependentModel() { }

        public DependentModel(DependentDataModel dependent)
        {
            EmployeeId = dependent?.EmployeeId ?? 0;
            DependentId = dependent?.DependentId ?? 0;
            DependentName = dependent?.DependentName ?? string.Empty;
        }
    }
}
