using rg.service.Data;
using rg.service.Models;
using System.Collections.Generic;

namespace rg.service.Manager
{
    public class CatagoryManager : ICatagoryManager
    {
        public List<Catagory> GetAllCatagory()
        {
            CatagoryData data = new CatagoryData();
            return data.GetAllCatagory();
        }

        public bool CreateCatagory(Catagory catagory)
        {
            CatagoryData data = new CatagoryData();
            return data.CreateCatagory(catagory);
        }

        public bool UpdateCatagory(Catagory catagory)
        {
            CatagoryData data = new CatagoryData();
            return data.UpdateCatagory(catagory);

        }

        public bool DeleteCatagory(Catagory per)
        {
            CatagoryData data = new CatagoryData();
            return data.DeleteCatagory(per);

        }

        
    }
}