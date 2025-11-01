using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rg.service.Data;
using rg.service.Models;

namespace rg.service.Manager
{
    public class CostsVsBudgetManager : ICostsVsBudgetManager
    {
        public List<CostsVsBudget> CostsVsBudgetDataDetails(CostsVsBudget costcodes)
        {
            var data = new CostsVsBudgetData();
            return data.CostsVsBudgetDataDetails(costcodes);
        }

      
    }
}