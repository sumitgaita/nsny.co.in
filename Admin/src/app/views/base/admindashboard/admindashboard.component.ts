import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { DashBoardService } from '../../../services/dash-board.service';
import { Dashboard } from '../../../model/Dashboard';
import { NgxSpinnerService } from "ngx-spinner";
import { NgxSpinnerModule } from "ngx-spinner";
import { CommonModule } from '@angular/common';
//import { ImageCropperComponent, ImageCroppedEvent } from 'ngx-image-cropper';
import { BranchService } from '../../../services/branch.service';
import { environment } from '../../../environments/environment';
@Component({
  selector: 'app-admindashboard',
  standalone: true,
  templateUrl: './admindashboard.component.html',
  styleUrl: './admindashboard.component.scss',
  imports: [NgxSpinnerModule, CommonModule, ReactiveFormsModule, FormsModule]
})
export class AdmindashboardComponent implements OnInit {
  dashboard?: Dashboard;
  name?: string | null;
  nssycode?: string | null;
  centercode?: string | null = '0';
  images: any[] = [];
  branchList: any[] = [];
  constructor(private spinner: NgxSpinnerService, private dashBoardService: DashBoardService, private branchService: BranchService) {
  }

  ngOnInit() {
    this.getAllCount();
    this.getAllBranch();
  }
  private getAllBranch() {
    this.spinner.show();
    this.branchList = [];
    this.branchService.getAllBranch().subscribe((res: any) => {
      if (res && res.length > 0) {
        this.branchList = res;
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }
  getAllCount() {
    this.spinner.show();
    this.dashBoardService.getAllCount().subscribe((res: any) => {
      this.dashboard = res;
      this.spinner.hide();
    });
  }
  getAllImage() {
    this.spinner.show();
    this.dashBoardService.getAllImages(this.name ?? undefined,
      this.nssycode ?? undefined,
      this.centercode ?? undefined).subscribe((res: any) => {
        this.images = res;
        this.spinner.hide();
      });
  }

  editImage(url: string, scode: string) {
    this.downloadImage(url, scode);
  }
  async downloadImage(url: string, scode: string): Promise<void> {
    try {
      const response = await fetch(url, { mode: 'cors' });
      const blob = await response.blob();
      const blobUrl = window.URL.createObjectURL(blob);

      const link = document.createElement('a');
      link.href = blobUrl;
      link.download = scode; // Example: "myImage.jpg"
      document.body.appendChild(link);
      link.click();
      document.body.removeChild(link);
      window.URL.revokeObjectURL(blobUrl);
    } catch (error) {
      console.error('Download failed:', error);
    }
  }

}
