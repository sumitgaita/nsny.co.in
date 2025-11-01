import { Routes } from '@angular/router';
import { DefaultLayoutComponent } from './layout';


export const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },

  {
    path: '',
    component: DefaultLayoutComponent,
    data: {
      title: 'Home'
    },
    children: [

      {
        path: 'base',
        loadChildren: () => import('./views/base/routes').then((m) => m.routes)
      }

    ]
  },

  {
    path: 'login',
    loadComponent: () => import('./views/pages/login/login.component').then(m => m.LoginComponent),
    data: {
      title: 'Login Page'
    }
  },
  {
    path: 'studentverify',
    loadComponent: () => import('./views/pages/studentverify/studentverify.component').then(m => m.StudentVerifyComponent),
    data: {
      title: 'Student Verify'
    }
  }

];
