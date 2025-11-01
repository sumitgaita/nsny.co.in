import { Component, ElementRef, ViewChild } from '@angular/core';
import { IconDirective } from '@coreui/icons-angular';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import {
  ContainerComponent, RowComponent, ColComponent, TextColorDirective, CardComponent,
  CardBodyComponent, FormDirective, InputGroupComponent, InputGroupTextDirective, FormControlDirective,
  ButtonDirective
} from '@coreui/angular';
import {
  NgbDateStruct, NgbCalendar, NgbDatepicker, NgbDateParserFormatter, NgbModal, ModalDismissReasons,
  NgbModalOptions, NgbDate
} from '@ng-bootstrap/ng-bootstrap';
import { CommonModule, DatePipe } from "@angular/common";
import { AgGridAngular } from 'ag-grid-angular'; // Angular Data Grid Component
import { ColDef } from 'ag-grid-community'; // Column Definition Type Interface
import * as jspdf from 'jspdf';
import html2canvas from 'html2canvas';
import { ToastrService } from "ngx-toastr";
import { StudentService } from '../../../services/student.service';
import { CommissionPayService } from '../../../services/commissionpay.service';
import { environment } from '../../../environments/environment';
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'student-verify',
  templateUrl: './studentverify.component.html',
  styleUrls: ['./studentverify.component.scss'],
    standalone: true,
  imports: [ContainerComponent, RowComponent, ColComponent, TextColorDirective, CardComponent,
    CardBodyComponent, FormDirective, InputGroupComponent, InputGroupTextDirective, IconDirective,
    FormControlDirective, ButtonDirective, ReactiveFormsModule, FormsModule, AgGridAngular, CommonModule]
})
export class StudentVerifyComponent {
  loading = false;
  selectdob!: NgbDateStruct;
  setudentCompleteDetails: any;
  environment = environment.apiUrl;
  originalsite = environment.originalsite;
  sname!: string;
  nssycode!: string;
  notissued!: string;
  notstudent!: string;
  isVisibleComp!: boolean;
  isVisibleNotComp!: boolean;
  isVisibleNotStudent!: boolean;
  isVisiblepaymentDetails!: boolean;
  @ViewChild('dd') dd!: NgbDatepicker;
  pageSize: number = 20;
  studentPaymentDetails: any[] = [];
  columnDefs: ColDef[] = [];
  title: string = environment.websitetitle;
  domain: string = environment.apiUrl;
  constructor(private datePipe: DatePipe,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private commissionPayService: CommissionPayService,
    //private route: ActivatedRoute,
    private studentService: StudentService) {
    this.columnDefs = [
      { headerName: 'Course', field: 'cname', tooltipField: 'cname', sortable: true, filter: true },
      { headerName: 'Course Fees', field: 'ctotal', tooltipField: 'ctotal', sortable: true, filter: true },
      { headerName: 'Payment', field: 'cpaid', tooltipField: 'cpaid', sortable: true, filter: true },
      { headerName: 'Discount', field: 'cdiscount', tooltipField: 'cdiscount', resizable: true, sortable: true, filter: true },
      { headerName: 'Payment Date', field: 'Sjoin', sortable: true, filter: true },
      { headerName: 'Balance Remaining', field: 'stbalance', tooltipField: 'stbalance', sortable: true, filter: true },//, cellRenderer: 'dateTimeRenderer', cellRendererParams: 'yyyy-MM-dd'
      { headerName: 'Total Installment', field: 'stinstall', sortable: true },
      { headerName: 'Installment Remains', field: 'stinstallremain', sortable: true },
    ];
  }

  ngOnInit() {
    //this.sname = this.route.snapshot.params['name'];
    //this.nssycode = this.route.snapshot.params['studentid'];
  }
  onSelectDate(date: NgbDateStruct) {
    this.selectdob = date;
  }
  getPaymentEaning(): any {
    this.isVisibleComp = false;
    this.isVisibleNotComp = false;
    this.isVisibleNotStudent = false;
    this.isVisiblepaymentDetails = false;
    if ((this.sname === '' || this.sname === undefined) && (this.nssycode === '' || this.nssycode === undefined)) {
      this.toastr.warning('Enter', 'Name && Student ID');
      return;
    }

    if (this.sname === '' || this.sname === undefined) {
      this.toastr.warning('Enter', 'Name');
      return false;
    }
    //if (!this.selectdob) {
    //  this.toastr.warning('Enter', 'Date of Birth');
    //  return;
    //}
    if (this.nssycode === '' || this.nssycode === undefined) {
      this.toastr.warning('Enter', 'Student ID');
      return;
    }

    this.spinner.show();
    // const dobDate = this.datePipe.transform(new Date(this.selectdob.year, this.selectdob.month - 1, this.selectdob.day), 'MM/dd/yyyy');
    this.studentService.getStudentVerification(this.sname, this.nssycode).subscribe((res: any) => {
      if (res && res.length > 0) {
        if (res[0].r3 === 'Course Complete') {
          this.setudentCompleteDetails = res[0];
          this.isVisibleComp = true;
        }
        else {
          this.notissued = 'Certificate NOT Issued Yet !';
          this.isVisibleNotComp = true;
        }
      }
      else {
        this.notstudent = 'You are NOT a Student of this Institution !';
        this.isVisibleNotStudent = true;
      }
      this.spinner.hide();
    });


  }

  PaymentDetails() {
    this.isVisibleComp = false;
    this.isVisibleNotComp = false;
    this.isVisibleNotStudent = false;
    if (this.sname === '' && this.nssycode === '') {
      this.toastr.warning('Enter', 'Name && Student ID');
      return;
    }
    if (this.sname === '') {
      this.toastr.warning('Enter', 'Name');
      return;
    }
    //if (!this.selectdob) {
    //  this.toastr.warning('Enter', 'Date of Birth');
    //  return;
    //}
    if (this.nssycode === '') {
      this.toastr.warning('Enter', 'Student ID');
      return;
    }

    this.spinner.show();
    // const dobDate = this.datePipe.transform(new Date(this.selectdob.year, this.selectdob.month - 1, this.selectdob.day), 'MM/dd/yyyy');
    this.studentService.getStudentVerification(this.sname, this.nssycode).subscribe((res: any) => {
      if (res && res.length > 0) {
        this.setudentCompleteDetails = res[0];
        this.isVisibleComp = true;
        this.getStudentPaymentDetails();
      }
      else {
        this.notstudent = 'You are NOT a Student of this Institution !';
        this.isVisibleNotStudent = true;
      }
      this.spinner.hide();
    });

  }
  getStudentPaymentDetails() {
    this.commissionPayService.getStudentPaymentDetails(this.nssycode).subscribe((res: any) => {
      if (res && res.length > 0) {
        this.studentPaymentDetails = res;
        this.isVisiblepaymentDetails = true;
      }
    });
  }

  print(): void {
    let printContents, popupWin;
    printContents = document.getElementById('content')!.innerHTML;
    popupWin = window.open('', '_blank', 'top=0,left=0,height=100%,width=auto')!;
    popupWin.document.open();
    popupWin.document.write(`
      <html>
        <head>
          <title>Print Verify Details</title>
        </head>
    <body onload="window.print();">${printContents}</body>
      </html>`
    );
    popupWin.document.close();
  }
  @ViewChild('content') content!: ElementRef;
  public SavePDF(): void {
    var data = document.getElementById('contentToConvert')!;
    html2canvas(data).then(canvas => {
      // Few necessary setting options  
      var imgWidth = 208;
      var pageHeight = 295;
      var imgHeight = canvas.height * imgWidth / canvas.width;
      var heightLeft = imgHeight;

      const contentDataURL = canvas.toDataURL('image/png')
      let pdf = new jspdf.jsPDF('p', 'mm', 'a4'); // A4 size page of PDF  
      var position = 0;
      pdf.addImage(contentDataURL, 'PNG', 0, position, imgWidth, imgHeight)
      pdf.save(this.sname + '.pdf'); // Generated PDF   
    });
  }
}
