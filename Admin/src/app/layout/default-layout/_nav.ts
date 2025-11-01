import { INavData } from '@coreui/angular';

export const navItems: INavData[] = [
    {
      name: 'Dashboard',
      url: '/base/dashboard',
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
        name: 'Add course',
        url: '/base/addcourse',
        icon: 'nav-icon-bullet'
      },
      {
        name: 'Edit course',
        url: '/base/editcourse',
        icon: 'nav-icon-bullet'
      },
      {
        name: 'Add branch',
        url: '/base/addbranch',
        icon: 'nav-icon-bullet'
      },
      {
        name: 'Edit branch',
        url: '/base/editbranch',
        icon: 'nav-icon-bullet'
      },
      {
        name: 'Edit student',
        url: '/base/editstudent',
        icon: 'nav-icon-bullet'
      },
      {
        name: 'Edit Course Binding',
        url: '/base/editbranchstudentbind',
        icon: 'nav-icon-bullet'
      },
      {
        name: 'Notice To Branch',
        url: '/base/noticetobranch',
        icon: 'nav-icon-bullet'
      },
      {
        name: 'All Notice To Branch',
        url: '/base/allnoticetobranch',
        icon: 'nav-icon-bullet'
      },
      {
        name: 'Student Registration',
        url: '/base/studentregistration',
        icon: 'nav-icon-bullet'
      },
      {
        name: 'Student ICard',
        url: '/base/studenticard',
        icon: 'nav-icon-bullet'
      },
      {
        name: 'Change Admin Pass.',
        url: '/base/changeadminpass',
        icon: 'nav-icon-bullet'
      },
      //{
      //  name: 'Student Details',
      //  url: '/base/branchviewstudent',
      //  icon: 'nav-icon-bullet'
      //},
      //{
      //  name: 'Course Binding',
      //  url: '/base/branchstudentbind',
      //  icon: 'nav-icon-bullet'
      //},
      {
        name: 'Wallet',
        url: '/base/wallet',
        icon: 'nav-icon-bullet'
      },
      {
        name: 'Wallet History',
        url: '/base/wallethistory',
        icon: 'nav-icon-bullet'
      }

    ]
  }

  ];

