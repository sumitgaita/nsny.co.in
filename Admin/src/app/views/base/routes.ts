import { Routes } from '@angular/router';
import { AuthGuard } from '../../services/auth.guard';

export const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Base'
    },
    children: [
      {
        path: 'addcourse',
        loadComponent: () => import('./addcourse/addcourse.component').then(m => m.AddCourseComponent),
        data: {
          title: 'Addcourse'
        },
        canActivate: [AuthGuard]
      },
      {
        path: 'editcourse',
        loadComponent: () => import('./editcourse/editcourse.component').then(m => m.EditcourseComponent),
        data: {
          title: 'Editcourse'
        },
        canActivate: [AuthGuard]
      },
      {
        path: 'addbranch',
        loadComponent: () => import('./addbranch/addbranch.component').then(m => m.AddBranchComponent),
        data: {
          title: 'Addbranch'
        },
        canActivate: [AuthGuard]
      },
      {
        path: 'editbranch',
        loadComponent: () => import('./editbranch/editbranch.component').then(m => m.EditBranchComponent),
        data: {
          title: 'Editbranch'
        },
        canActivate: [AuthGuard]
      },
      {
        path: 'addstudent',
        loadComponent: () => import('./addstudent/addstudent.component').then(m => m.AddStudentComponent),
        data: {
          title: 'Addstudent'
        },
        canActivate: [AuthGuard]
      },
      {
        path: 'editstudent',
        loadComponent: () => import('./editstudent/editstudent.component').then(m => m.EditStudentComponent),
        data: {
          title: 'Editstudent'
        },
        canActivate: [AuthGuard]
      },
      {
        path: 'editbranchstudentbind',
        loadComponent: () => import('./editbranchstudentbind/editbranchstudentbind.component').then(m => m.EditBranchStudentBindComponent),
        data: {
          title: 'Editbranchstudentbind'
        },
        canActivate: [AuthGuard]
      },
      {
        path: 'noticetobranch',
        loadComponent: () => import('./noticetobranch/noticetobranch.component').then(m => m.NoticetoBranchComponent),
        data: {
          title: 'Noticetobranch'
        },
        canActivate: [AuthGuard] 
      },
      {
        path: 'allnoticetobranch',
        loadComponent: () => import('./noticetobranchdetails/noticetobranchdetails.component').then(m => m.NoticetobranchdetailsComponent),
        data: {
          title: 'AllNoticetobranch'
        },
        canActivate: [AuthGuard]
      },
      {
        path: 'studentregistration',
        loadComponent: () => import('./studentregistration/studentregistration.component').then(m => m.StudentRegistrationComponent),
        data: {
          title: 'StudentRegistration'
        },
        canActivate: [AuthGuard] 
      },
      {
        path: 'studenticard',
        loadComponent: () => import('./studenticard/studenticard.component').then(m => m.StudentIcardComponent),
        data: {
          title: 'student id card'
        },
        canActivate: [AuthGuard] 
      },
      {
        path: 'changeadminpass',
        loadComponent: () => import('./changeadminpass/changeadminpass.component').then(m => m.ChangeAdminPassComponent),
        data: {
          title: 'change admin pass'
        },
        canActivate: [AuthGuard] 
      },
      {
        path: 'branchviewstudent',
        loadComponent: () => import('./branchviewstudent/branchviewstudent.component').then(m => m.BranchViewStudentComponent),
        data: {
          title: 'branch view student'
        },
        canActivate: [AuthGuard] 
      },
      {
        path: 'branchstudentbind',
        loadComponent: () => import('./branchstudentbind/branchstudentbind.component').then(m => m.BranchStudentBindComponent),
        data: {
          title: 'branch student bind'
        },
        canActivate: [AuthGuard] 
      },
      {
        path: 'paymentcollection',
        loadComponent: () => import('./paymentcollection/paymentcollection.component').then(m => m.PaymentCollectionComponent),
        data: {
          title: 'payment collection'
        },
        canActivate: [AuthGuard] 
      },
      {
        path: 'paymenteraning',
        loadComponent: () => import('./paymenteraning/paymenteraning.component').then(m => m.PaymenteraningComponent),
        data: {
          title: 'payment eraning'
        },
        canActivate: [AuthGuard] 
      },
      {
        path: 'changebranchpassword',
        loadComponent: () => import('./changebranchpassword/changebranchpassword.component').then(m => m.ChangeBranchPasswordComponent),
        data: {
          title: 'change branch password'
        },
        canActivate: [AuthGuard] 
      },
      {
        path: 'dashboard',
        loadComponent: () => import('./admindashboard/admindashboard.component').then(m => m.AdmindashboardComponent),
        data: {
          title: 'Admin Dashboard'
        },
        canActivate: [AuthGuard] 
      },
      {
        path: 'branchdashboard',
        loadComponent: () => import('./branchdashboard/branchdashboard.component').then(m => m.BranchDashboardComponent),
        data: {
          title: 'branch dashboard'
        },
        canActivate: [AuthGuard] 
      },
      {
        path: 'wallet',
        loadComponent: () => import('./wallet/wallet.component').then(m => m.WalletComponent),
        data: {
          title: 'wallet'
        },
        canActivate: [AuthGuard] 
      },
      {
        path: 'wallethistory',
        loadComponent: () => import('./wallethistory/wallethistory.component').then(m => m.WallethistoryComponent),
        data: {
          title: 'wallethistory'
        },
        canActivate: [AuthGuard] 
      }

    ]
  }
];


