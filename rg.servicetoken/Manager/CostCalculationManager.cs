using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rg.service.Data;
using rg.service.Models;

namespace rg.service.Manager
{
    public class CostCalculationManager: ICostCalculationManager
    {
        public CostCalculation ProjectMonthWiseDetails(CostCalculation costCalculations)
        {
            var data = new CostCalculationData();
            return data.ProjectMonthWiseDetails(costCalculations);
        }

        public List<CostCalculation> MonthInBeteenDetails(CostCalculation monthBetween)
        {
            var data = new CostCalculationData();
            return data.MonthInBeteenDetails(monthBetween);
        }

        public List<CostCalculation> PojectwiseDetails(CostCalculation projectwise)
        {
            var data = new CostCalculationData();
            return data.PojectwiseDetails(projectwise);
        }

        public List<CostCalculation> GetAllProjects()
        {
            var data = new CostCalculationData();
            return data.GetAllProjects();
        }

        public List<CostCalculation> PojectwiseCostCodeDetails(CostCalculation costCodes)
        {
            var data = new CostCalculationData();
            return data.PojectwiseCostCodeDetails(costCodes);
        }
    }
}