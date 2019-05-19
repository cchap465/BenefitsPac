﻿using BenefitsPac.Core.Models.ApiModel;

namespace BenefitsPac.Core.Models
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
            EmployeeId = employeeModel.EmployeeId;
            EmployeeName = employeeModel.EmployeeName;
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
