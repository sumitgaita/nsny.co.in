import { Component } from '@angular/core';
import { CommonModule,NgStyle,NgFor  } from '@angular/common';
import { DashBoardService } from '../../../services/dash-board.service';
import { BranchService } from '../../../services/branch.service';
import { AuthenticationService } from '../../../services/authentication.service';
import { Dashboard } from '../../../model/Dashboard';
import { NgxSpinnerService } from "ngx-spinner"
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-branchdashboard',
  standalone: true,
  templateUrl: './branchdashboard.component.html',
  styleUrl: './branchdashboard.component.scss',
  imports: [CommonModule]
})
export class BranchDashboardComponent {
  dashboard?: Dashboard;
  currentUser: any;
  noticeList: any[] = [];
  show = false;
  constructor(private dashBoardService: DashBoardService,
    private spinner: NgxSpinnerService,
    private branchService: BranchService,
    private authenticationService: AuthenticationService) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  ngOnInit() {
    this.getAllCount();
    this.getNotification();
   
  }
  getAllCount() {
    this.spinner.show(); //---NSWB(nsny.org) SNYWB(Youth) NYCE1(computer)
    this.dashBoardService.getAllBranchCount(this.currentUser.id, `${environment.branchcode}` + ("000" + this.currentUser.id).slice(-3)).subscribe((res: any) => {
      this.dashboard = res;
      this.spinner.hide();
    });
  }
  getNotification() {
    this.spinner.show();
    this.branchService.getBranchNotification(this.currentUser.id).subscribe((res: any) => {
      this.noticeList = res;
      this.spinner.hide();
    });
  }
}


