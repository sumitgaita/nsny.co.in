using Ninject.Modules;
using rg.service.Manager;
using rg.service.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rg.service.NinjectModules
{
    public class DefaultModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IHttpResponseMessage>().To<BasicHttpResponseMessage>();
            // Bind<IProductManager>().To<ProductManager>();
            //Bind<IUserManager>().To<UserManager>();
            //Bind<IProjectManager>().To<ProjectManager>();
            //Bind<IPermissionsManager>().To<PermissionsManager>();
            //Bind<IResourceManager>().To<ResourceManager>();
            //Bind<ICostCodeManager>().To<CostCodeManager>();
            //Bind<ICostsVsBudgetManager>().To<CostsVsBudgetManager>();
            //Bind<ICostCalculationManager>().To<CostCalculationManager>();
            //Bind<IUserTypeManager>().To<UserTypeManager>();
            //Bind<IProjectNoteManager>().To<ProjectNoteManager>();
            Bind<IAdminLoginManager>().To<AdminLoginManager>();
            Bind<IDashboardManager>().To<DashboardManager>();
            Bind<ICourseManager>().To<CourseManager>();
            Bind<IBranchManager>().To<BranchManager>();
            Bind<IStudentManager>().To<StudentManager>();
            Bind<IBranchStudentBindManager>().To<BranchStudentBindManager>();
            Bind<ICommissionPayManager>().To<CommissionPayManager>();
            Bind<IWalletManager>().To<WalletManager>();

        }
    }
}