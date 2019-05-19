namespace BenefitsPac.Core.Models.ApiModel
{
    public class DependentModel
    {
        public int DependentId { get; set; }
        public string DependentName { get; set; }
        public int EmployeeId { get; set; }

        public DependentModel() { }

        public DependentModel(DependentDataModel dependent)
        {
            EmployeeId = dependent.EmployeeId;
            DependentId = dependent.DependentId;
            DependentName = dependent.DependentName;
        }
    }
}
