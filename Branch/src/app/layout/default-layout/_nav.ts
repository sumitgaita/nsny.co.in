import { INavData } from '@coreui/angular';

  export const navItems: INavData[] = [
    {
      name: 'Dashboard',
      url: '/base/branchdashboard',
      iconComponent: { name: 'cil-speedometer' },

    },

    {
      name: 'Components',
      title: true
    },
    {
      name: 'Base',
      url: '/base',
      iconComponent: { name: 'cil-puzzle' },
      children: [

        {
          name: 'Add student',
          url: '/base/addstudent',
          icon: 'nav-icon-bullet'
        },

        {
          name: 'Student Details',
          url: '/base/branchviewstudent',
          icon: 'nav-icon-bullet'
        },
        {
          name: 'Course Binding',
          url: '/base/branchstudentbind',
          icon: 'nav-icon-bullet'
        },
        {
          name: 'Payment Collection',
          url: '/base/paymentcollection',
          icon: 'nav-icon-bullet'
        },
        {
          name: 'Payment Eraning',
          url: '/base/paymenteraning',
          icon: 'nav-icon-bullet'
        },
        {
          name: 'Change Branch Password',
          url: '/base/changebranchpassword',
          icon: 'nav-icon-bullet'
        }
      ]
    }

  ];

