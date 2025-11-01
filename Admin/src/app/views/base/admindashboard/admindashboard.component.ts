import { Component } from '@angular/core';
import { DashBoardService } from '../../../services/dash-board.service';
import { Dashboard } from '../../../model/Dashboard';
import { NgxSpinnerService } from "ngx-spinner";
import { NgxSpinnerModule } from "ngx-spinner";

@Component({
  selector: 'app-admindashboard',
  standalone: true,
  templateUrl: './admindashboard.component.html',
  styleUrl: './admindashboard.component.scss',
  imports: [NgxSpinnerModule]
})
export class AdmindashboardComponent {
  dashboard?: Dashboard;
  constructor(private spinner: NgxSpinnerService,private dashBoardService: DashBoardService) {
  }

   ngOnInit() {
      this.getAllCount();
    }

  getAllCount() {
    this.spinner.show();
    this.dashBoardService.getAllCount().subscribe((res: any) => {
      this.dashboard = res;
      this.spinner.hide();
    });
  }
}
