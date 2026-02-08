using rg.service.Data;
using rg.service.Models;
using System.Collections.Generic;

namespace rg.service.Manager
{
    public class MasterCodeManager : IMasterCodeManager
    {
        public List<Master_Code> GetAllMasterCode()
        {
            MasterCodeData data = new MasterCodeData();
            return data.GetAllMasterCode();
        }

        public bool CreateMasterCode(Master_Code masterCode)
        {
            MasterCodeData data = new MasterCodeData();
            return data.CreateMasterCode(masterCode);
        }

        public bool UpdateMasterCode(Master_Code masterCode)
        {
            MasterCodeData data = new MasterCodeData();
            return data.UpdateMasterCode(masterCode);

        }

        public bool DeleteMasterCode(Master_Code masterCode)
        {
            MasterCodeData data = new MasterCodeData();
            return data.DeleteMasterCode(masterCode);

        }

        
    }
}