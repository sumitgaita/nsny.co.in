using rg.service.Models;
using System.Collections.Generic;

namespace rg.service.Manager
{
    public interface ICenterManager
    {
        
        bool CreateCenter(Branch branch);
        bool UpdateCenter(Branch branch);
        bool DeleteCenter(Branch per);
        int CurrntCenterId();
        List<Branch> GetBranchCenter(int bid);
    }
}