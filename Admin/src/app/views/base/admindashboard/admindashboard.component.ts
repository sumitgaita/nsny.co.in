import { Component, ElementRef, NgZone, OnInit, ViewChild } from '@angular/core';
import { ReactiveFormsModule, FormsModule, FormGroup } from '@angular/forms';
import { DashBoardService } from '../../../services/dash-board.service';
import { Dashboard } from '../../../model/Dashboard';
import { NgxSpinnerService } from "ngx-spinner";
import { NgxSpinnerModule } from "ngx-spinner";
import { CommonModule } from '@angular/common';
import { ToastrService } from "ngx-toastr";
//import { ImageCropperComponent, ImageCroppedEvent } from 'ngx-image-cropper';
import { BranchService } from '../../../services/branch.service';
import { environment } from '../../../environments/environment';
import { NgbModalModule, NgbAlertModule, NgbDatepickerModule, NgbModal, ModalDismissReasons, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-admindashboard',
  standalone: true,
  templateUrl: './admindashboard.component.html',
  styleUrl: './admindashboard.component.scss',
  imports: [NgxSpinnerModule, CommonModule, ReactiveFormsModule, FormsModule, NgbModalModule]
})
export class AdmindashboardComponent implements OnInit {
  @ViewChild('imageUploadModel') imageUploadModel: NgbModal | any;
  @ViewChild('inputFile') myInputVariable!: ElementRef;
  modalHeaderTitle!: string;
  modalOptions: NgbModalOptions | undefined;
  formData = new FormData();
  imageURL!: string;
  fileData!: File | string;
  selectedFile: File | undefined;
  //imageUploadForm: FormGroup | any;
  dashboard?: Dashboard;
  name: string | undefined;
  nssycode: string | undefined;
  centercode?: string | null = '0';
  images: any[] = [];
  branchList: any[] = [];
  closeResult!: string;
  imagename: string | undefined;
  uploadnssycode: string | undefined;
  constructor(private spinner: NgxSpinnerService,
    private dashBoardService: DashBoardService,
    private modalService: NgbModal,
    private zone: NgZone,
    private toastr: ToastrService,
    private branchService: BranchService) {
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
  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }


  private openModel(content: any) {
    this.zone.run(() => {
      this.modalService.open(content, { centered: true, backdrop: "static", size: "lg" }).result.then((result) => {
        this.closeResult = `Closed with: ${result}`;

      }, (reason) => {
        this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
      });
    });
  }
  // Image Preview  bjgjd
  showPreview(event: any) {
    //this.ifchanchepic = true;
    this.selectedFile = <File>event.target.files[0];
    const file = (event.target as HTMLInputElement | any).files[0];
    if (file.size > 256000) {
      this.toastr.warning('Image', "Upload student picture (50kb to 250kb)");
      this.myInputVariable.nativeElement.value = '';
      this.imageURL = '';
      return;
    }
    this.fileData = file;
    // File Preview
    const reader = new FileReader();
    reader.onload = (e) => {
      this.imageURL = reader.result as string;
    }
    reader.readAsDataURL(file);

  }
  UploadImageClick(imagename: string, nssycode: string) {
    this.uploadnssycode = nssycode;
    this.imagename = imagename;
    this.imageURL = imagename;
    this.openModel(this.imageUploadModel);

  }
  private uploadImage(nssycode: string) {
    if (!this.fileData || this.fileData === '') {
      this.toastr.warning('Warning', "Pic Upload");
      this.spinner.hide();
      return;
    }
    this.formData = new FormData();
    this.formData.append('images', this.fileData);
    this.formData.append('nssycode', nssycode);
    this.dashBoardService.uploadStudentImage(this.formData).subscribe((res: any) => {
      if (res && res.status === 200) {
        this.spinner.hide();
        this.images = [];
        setTimeout(() => {
          this.getAllImage();
          this.toastr.success('Success', "Image Updated Successfully");
          this.modalService.dismissAll();
        }, 500);
      }
      else {
        this.spinner.hide();
      }
    });
  }

  SaveImage() {
    const nsscode = this.uploadnssycode;
    if (nsscode) {
      this.uploadImage(nsscode);
    }
  }
}
