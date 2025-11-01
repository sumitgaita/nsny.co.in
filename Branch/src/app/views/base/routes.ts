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
        path: 'addstudent',
        loadComponent: () => import('./addstudent/addstudent.component').then(m => m.AddStudentComponent),
        data: {
          title: 'Addstudent'
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
        path: 'branchdashboard',
        loadComponent: () => import('./branchdashboard/branchdashboard.component').then(m => m.BranchDashboardComponent),
        data: {
          title: 'branch dashboard'
        },
        canActivate: [AuthGuard] 
      }

    ]
  }
];


