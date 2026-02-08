using rg.service.Models;
using System.Collections.Generic;

namespace rg.service.Manager
{
    public interface IMasterCodeManager
    {

        bool CreateMasterCode(Master_Code masterCode);
        bool UpdateMasterCode(Master_Code masterCode);
        bool DeleteMasterCode(Master_Code masterCode);
        List<Master_Code> GetAllMasterCode();


    }
}