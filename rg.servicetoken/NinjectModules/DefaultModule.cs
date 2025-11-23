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
            Bind<IAdminLoginManager>().To<AdminLoginManager>();
            Bind<IDashboardManager>().To<DashboardManager>();
            Bind<ICourseManager>().To<CourseManager>();
            Bind<IBranchManager>().To<BranchManager>();
            Bind<IStudentManager>().To<StudentManager>();
            Bind<IBranchStudentBindManager>().To<BranchStudentBindManager>();
            Bind<ICommissionPayManager>().To<CommissionPayManager>();
            Bind<IWalletManager>().To<WalletManager>();
            Bind<ICatagoryManager>().To<CatagoryManager>();
            Bind<IUserPermissionManager>().To<UserPermissionManager>();

        }
    }
}