using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rg.service.Data;
using rg.service.Models;

namespace rg.service.Manager
{
    public class CostCodeManager : ICostCodeManager
    {
        public List<CostCode> CostCodeDetails(CostCode costcodes)
        {
            var data = new CostCodeData();
            return data.CostCodeDetails(costcodes);
        }

        public List<CostCode> CountCostCode(CostCode costcodes)
        {
            var data = new CostCodeData();
            return data.CountCostCode(costcodes);
        }

        public CostCode CostCodeEditDetails(CostCode codeDetails)
        {
            var data = new CostCodeData();
            return data.CostCodeEditDetails(codeDetails);
        }

        public bool CreateCostCodeActivity(CostCode code)
        {
            var data = new CostCodeData();
            return data.CreateCostCodeActivity(code);
        }

        public bool CreateCostCode(CostCode cc)
        {
            var data = new CostCodeData();
            return data.CreateCostCode(cc);
        }

        public bool UpdateCostCode(CostCode cc)
        {
            var data = new CostCodeData();
            return data.UpdateCostCode(cc);
        }

        public bool DeleteCostCode(CostCode cc)
        {
            var result=false;
            var data = new CostCodeData();
            var count = data.CostCodeCount(cc);
            if (count.CostCodeCount == 0)
                result= data.DeleteCostCode(cc);

            return result;

        }
    }
}