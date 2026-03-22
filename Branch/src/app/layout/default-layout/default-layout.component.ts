import { Component } from '@angular/core';
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
  currentUser: any;
  public title = environment.websitetitle;
  navItemsRemove: any;
  onScrollbarUpdate($event: any) {
    // if ($event.verticalUsed) {
    // console.log('verticalUsed', $event.verticalUsed);
    // }
  }
  constructor(private authenticationService: AuthenticationService) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }
  ngOnInit() {
    if (this.currentUser.isBranch === 'True') {
      // this.navItems = navItems;
      this.navItemsRemove = navItems?.find((x: any) => x.name === 'Base');
      this.navItems = [...this.navItemsRemove.children];
      this.navItems = this.navItems.filter((x: { name: string; }) => x.name !== 'Add student');
    }
    else {
      setTimeout(() => {
        this.navItemsRemove = navItems?.find((x: any) => x.name === 'Base');
        this.navItems = [...this.navItemsRemove.children]; // start with full list        
        //this.navItems = this.navItems.filter((x: { name: string; }) => x.name !== 'Add student');
       // this.navItems = this.navItems.filter((x: { name: string; }) => x.name !== 'Course Binding');
        //this.navItems = this.navItems.filter((x: { name: string; }) => x.name !== 'Payment Collection');
        //this.navItems = this.navItems.filter((x: { name: string; }) => x.name !== 'Payment Eraning');
      }, 500);
    }
  }
}
