using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rg.service.Models;

namespace rg.service.Manager
{
    public interface ICostCodeManager
    {
        List<CostCode> CostCodeDetails(CostCode costcodes);
        List<CostCode> CountCostCode(CostCode costcodes);
        CostCode CostCodeEditDetails(CostCode codeDetails);
        bool CreateCostCodeActivity(CostCode code);
        bool CreateCostCode(CostCode cc);
        bool UpdateCostCode(CostCode cc);
        bool DeleteCostCode(CostCode cc);

    }
}