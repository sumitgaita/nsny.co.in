using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rg.service.Models;

namespace rg.service.Manager
{
    public interface ICostCalculationManager
    {
         CostCalculation ProjectMonthWiseDetails(CostCalculation costCalculations);
        List<CostCalculation> MonthInBeteenDetails(CostCalculation monthBetween);
        List<CostCalculation> PojectwiseDetails(CostCalculation projectwise);
        List<CostCalculation> GetAllProjects();
        List<CostCalculation> PojectwiseCostCodeDetails(CostCalculation costCodes);
    }
}