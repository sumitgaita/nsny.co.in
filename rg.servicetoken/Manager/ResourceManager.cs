using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rg.service.Data;
using rg.service.Models;

namespace rg.service.Manager
{
    public class ResourceManager: IResourceManager
    {
        public List<Resource> ResourceDetails(Resource resources)
        {
            var data = new ResourceData();

            return data.ResourceDetails(resources);
        }
        public List<Resource> ResourceDetails(Resource resources, int startIndex, out int totalRecords, out decimal totalCost)
        {
            var data = new ResourceData();

            return data.ResourceDetails(resources, startIndex, out totalRecords, out totalCost);
        }


        public List<Resource> CostCalclationCostCoderpt(Resource resources)
        {
            var data = new ResourceData();

            return data.CostCalclationCostCoderpt(resources);
        }

        public List<Resource> CostCodeWiseResource(Resource resources)
        {
            var data = new ResourceData();

            return data.CostCodeWiseResource(resources);
        }

        public Resource GetResourceDetails(Resource resourceId)
        {
            var data = new ResourceData();

            return data.GetResourceDetails(resourceId);
        }

        public bool CreateResource(Resource res)
        {
            var result=false;
            var obj =new Resource();
            var data = new ResourceData();
            int i;
            for (i = 0; i < res.CostCodeList.Count; i++)
            {
                if (res.CostCodeList[i].CostCodeIds > 0)
                {
                    obj.ProjectId = res.ProjectId;
                    obj.ResourceName = res.ResourceName;
                    obj.ItemName = res.ItemName;
                    obj.Supplier = res.Supplier;
                    obj.Unit = res.Unit;
                    obj.Qty = res.CostCodeList[i].Qty;
                    obj.Rate = res.Rate;
                    obj.Cost = res.CostCodeList[i].Cost;
                    obj.Comments = res.Comments;
                    obj.CostCode = res.CostCodeList[i].CostCodeIds;
                    obj.CreateDate = res.CreateDate;
                    result = data.CreateResource(obj);
                }
            }
            return result;
        }

        public bool UpdateResource(Resource res)
        {
            var data = new ResourceData();

            return data.UpdateResource(res);
        }

        public bool DeleteResource(Resource res)
        {
            var data = new ResourceData();

            return data.DeleteResource(res);
        }

        public Resource GetTotalCost(Resource resourceId)
        {
            var data = new ResourceData();

            return data.GetTotalCost(resourceId);
        }

        public bool DeleteAllResource(Resource res)
        {
            var data = new ResourceData();

            return data.DeleteAllResource(res);
        }

        public bool UpdateViewCostStatus(Resource res)
        {
            var data = new ResourceData();

            return data.UpdateViewCostStatus(res);
        }

        public List<ResourceNameArray> GetResourceName(ResourceNameArray resources)
        {
            var data = new ResourceData();

            return data.GetResourceName(resources);
        }
    }
}