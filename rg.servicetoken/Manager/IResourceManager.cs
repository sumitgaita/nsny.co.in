using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rg.service.Models;

namespace rg.service.Manager
{
    public interface IResourceManager
    {
        List<Resource> ResourceDetails(Resource resources);

        List<Resource> ResourceDetails(Resource resources, int startIndex, out int totalRecords, out decimal totalCost);
        List<Resource> CostCalclationCostCoderpt(Resource resources);
        List<Resource> CostCodeWiseResource(Resource resources);
        Resource GetResourceDetails(Resource resourceId);
        bool CreateResource(Resource res);
        bool UpdateResource(Resource res);
        bool DeleteResource(Resource res);
        bool DeleteAllResource(Resource res);
        Resource GetTotalCost(Resource resourceId);
        bool UpdateViewCostStatus(Resource res);
        List<ResourceNameArray> GetResourceName(ResourceNameArray resources);
    }
}