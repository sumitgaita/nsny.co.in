import { Component, NgZone } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { NgScrollbar } from 'ngx-scrollbar';
import { NgxSpinnerModule } from 'ngx-spinner';
import { IconDirective } from '@coreui/icons-angular';
import {
  ContainerComponent,
  ShadowOnScrollDirective,
  SidebarBrandComponent,
  SidebarComponent,
  SidebarFooterComponent,
  SidebarHeaderComponent,
  SidebarNavComponent,
  SidebarToggleDirective,
  SidebarTogglerDirective
} from '@coreui/angular';

import { DefaultFooterComponent, DefaultHeaderComponent } from './';
import { navItems } from './_nav';
import { AuthenticationService } from '../../services/authentication.service';
import { CommonModule } from '@angular/common'
import { environment } from '../../environments/environment';

function isOverflown(element: HTMLElement) {
  return (
    element.scrollHeight > element.clientHeight ||
    element.scrollWidth > element.clientWidth
  );
}

@Component({
  selector: 'app-dashboard',
  templateUrl: './default-layout.component.html',
  styleUrls: ['./default-layout.component.scss'],
  standalone: true,
  imports: [
    SidebarComponent,
    SidebarHeaderComponent,
    SidebarBrandComponent,
    RouterLink,
    IconDirective,
    NgScrollbar,
    SidebarNavComponent,
    SidebarFooterComponent,
    SidebarToggleDirective,
    SidebarTogglerDirective,
    DefaultHeaderComponent,
    ShadowOnScrollDirective,
    ContainerComponent,
    RouterOutlet,
    DefaultFooterComponent,
    CommonModule,
    NgxSpinnerModule
  ]
})
export class DefaultLayoutComponent {
  public navItems: any;
  public title = environment.websitetitle;
  currentUser: any;
  navItemsRemove: any;
  onScrollbarUpdate($event: any) {
    // if ($event.verticalUsed) {
    // console.log('verticalUsed', $event.verticalUsed);
    // }
  }
  constructor(private authenticationService: AuthenticationService) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }
  //ngOnInit() {

  //  if (this.currentUser.isAdmin === 'True') {
  //    this.navItems = navItems;
  //  }
  //  else {
  //   // setTimeout(() => {
  //      this.navItemsRemove = navItems?.find((x: any) => x.name === 'Base');

  //      this.navItems = [...this.navItemsRemove.children]; // start with full list

  //      if (this.currentUser.addcatagory === 'False') {
  //        this.navItems = this.navItems.filter((x: { name: string; }) => x.name !== 'Add catagory');
  //      }

  //    if (this.currentUser.addbranch === 'False') {
  //        this.navItems = this.navItems.filter((x: { name: string; }) => x.name !== 'Add branch');
  //      }

  //      if (this.currentUser.addcourse === 'False') {
  //        this.navItems = this.navItems.filter((x: { name: string; }) => x.name !== 'Add course');
  //      }

  //      if (this.currentUser.allnoticetobranch === 'False') {
  //        this.navItems = this.navItems.filter((x: { name: string; }) => x.name !== 'All Notice To Branch');
  //      }

  //    if (this.currentUser.editbranch === 'False') {
  //        this.navItems = this.navItems.filter((x: { name: string; }) => x.name !== 'Edit branch');
  //      }

  //      if (this.currentUser.editbranchstudentbind === 'False') {
  //        this.navItems = this.navItems.filter((x: { name: string; }) => x.name !== 'Edit Course Binding');
  //      }

  //      if (this.currentUser.editcatagory === 'False') {
  //        this.navItems = this.navItems.filter((x: { name: string; }) => x.name !== 'Edit catagory');
  //      }

  //      if (this.currentUser.editcourse === 'False') {
  //        this.navItems = this.navItems.filter((x: { name: string; }) => x.name !== 'Edit course');
  //      }

  //      if (this.currentUser.editstudent === 'False') {
  //        this.navItems = this.navItems.filter((x: { name: string; }) => x.name !== 'Edit student');
  //      }

  //      if (this.currentUser.noticetobranch === 'False') {
  //        this.navItems = this.navItems.filter((x: { name: string; }) => x.name !== 'Notice To Branch');
  //      }

  //      if (this.currentUser.studenticard === 'False') {
  //        this.navItems = this.navItems.filter((x: { name: string; }) => x.name !== 'Student ICard');
  //      }

  //      if (this.currentUser.studentregistration === 'False') {
  //        this.navItems = this.navItems.filter((x: { name: string; }) => x.name !== 'Student Registration');
  //      }
  //      this.navItems = this.navItems.filter((x: { name: string; }) => x.name !== 'Add Permission');
  //      this.navItems = this.navItems.filter((x: { name: string; }) => x.name !== 'Edit Permission');
  //      this.navItems = this.navItems.filter((x: { name: string; }) => x.name !== 'Change Admin Pass.');
  //      this.navItems = this.navItems.filter((x: { name: string; }) => x.name !== 'Wallet');
  //      this.navItems = this.navItems.filter((x: { name: string; }) => x.name !== 'Wallet History');
  //   // }, 500);
  //  }

  //}
  ngOnInit() {
    if (this.currentUser.isAdmin === 'True') {
      this.navItems = navItems;
      return;
    }
   
    const baseChildren = navItems?.find((x: any) => x.name === 'Base')?.children || [];

    const permissionMap: Record<string, string> = {
      addcatagory: 'Add catagory',
      addbranch: 'Add Branch',
      addcourse: 'Add course',
      allnoticetobranch: 'All Notice To Branch',
      editbranch: 'Edit Branch',
      editbranchstudentbind: 'Edit Course Binding',
      editcatagory: 'Edit catagory',
      editcourse: 'Edit course',
      editstudent: 'Edit student',
      noticetobranch: 'Notice To Branch',
      studenticard: 'Student ICard',
      studentregistration: 'Student Registration'
    };

    const alwaysRemove = new Set([
      'Add Permission',
      'Edit Permission',
      'Change Admin Pass.',
      'Wallet',
      'Wallet History',
      'Add Master code/Branch',
      'Edit Master code/Branch'
    ]);

    this.navItems = baseChildren.filter((item: any) => {
      // Remove always restricted items
      if (alwaysRemove.has(item.name)) return false;

      // Check permission-based removal
      const permissionKey = Object.keys(permissionMap)
        .find(key => permissionMap[key] === item.name);

      if (permissionKey && this.currentUser[permissionKey] === 'False') {
        return false;
      }

      return true;
    });
  }
}
