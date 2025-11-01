using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rg.service.Models;

namespace rg.service.Manager
{
    public interface ICostsVsBudgetManager
    {
        List<CostsVsBudget> CostsVsBudgetDataDetails(CostsVsBudget costcodes);
    }
}