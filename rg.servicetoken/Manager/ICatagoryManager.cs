using rg.service.Models;
using System.Collections.Generic;

namespace rg.service.Manager
{
    public interface ICatagoryManager
    {

        bool CreateCatagory(Catagory catagory);
        bool UpdateCatagory(Catagory catagory);
        bool DeleteCatagory(Catagory per);
        List<Catagory> GetAllCatagory();


    }
}