using rg.service.Data;
using rg.service.Models;
using System.Collections.Generic;

namespace rg.service.Manager
{
    public class CenterManager : ICenterManager
    {
       
        public bool CreateCenter(Branch branch)
        {
            CenterData data = new CenterData();
            return data.CreateCenter(branch);
        }

        public bool UpdateCenter(Branch branch)
        {
            CenterData data = new CenterData();
            return data.UpdateCenter(branch);

        }

        public bool DeleteCenter(Branch branch)
        {
            CenterData data = new CenterData();
            return data.DeleteCenter(branch);

        }

        public int CurrntCenterId()
        {
            CenterData data = new CenterData();
            return data.CurrntCenterId();
        }
        
        public List<Branch> GetBranchCenter(int bid)
        {
            CenterData data = new CenterData();
            return data.GetBranchCenter(bid);

        }
       
    }
}