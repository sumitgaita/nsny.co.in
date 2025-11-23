import { Component } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { NgbAlertModule, NgbDatepickerModule, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule, DatePipe } from '@angular/common'
import { DocsExampleComponent } from '@docs-components/public-api';
import { NgxSpinnerService } from "ngx-spinner";
import { BranchstudentbindService } from '../../../services/branchstudentbind.service';
import { BranchService } from '../../../services/branch.service';
import { RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent, CardBodyComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, DropdownDividerDirective, FormSelectDirective } from '@coreui/angular';
import { ToastrService } from "ngx-toastr";
import { environment } from '../../../environments/environment';
import { AgGridAngular } from 'ag-grid-angular'; // Angular Data Grid Component
import { ColDef } from 'ag-grid-community'; // Column Definition Type Interface
import { ImageFormatterComponent } from '../../../services/ImageFormatter';

@Component({
  selector: 'student-icard',
  templateUrl: './studenticard.component.html',
  styleUrls: ['./studenticard.component.scss'],
  standalone: true,
  imports: [RowComponent, ColComponent, TextColorDirective, CardComponent,
    CardHeaderComponent, CardBodyComponent, DocsExampleComponent,
    InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective,
    FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent,
    DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective,
    RouterLink, DropdownDividerDirective,
    FormSelectDirective, ReactiveFormsModule, NgbAlertModule, NgbDatepickerModule,
    CommonModule, FormsModule, AgGridAngular]
})
export class StudentIcardComponent {
  searchFromDate!: NgbDateStruct;
  searchToDate!: NgbDateStruct;
  columnDefs: ColDef[] = [];
  loading = false;
  currentUser: any;
  paymenteraningList: any[] = [];
  pageSize: number = 10;
  branchList: any[] = [];
  branchId: number = 0;
  gridColumnApi: any;
  gridApi: any;


  constructor(private branchstudentbindService: BranchstudentbindService,
   // private authenticationService: AuthenticationService,
    private branchService: BranchService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private datePipe: DatePipe) {
   // this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    this.columnDefs = [
      { headerName: 'Student ID', field: 'stid', tooltipField: 'stid', sortable: true, filter: true },
      { headerName: 'Name', field: 'sname', tooltipField: 'sname', sortable: true, filter: true },
      { headerName: 'Father Name', field: 'guardian', tooltipField: 'guardian', sortable: true, filter: true },
      { headerName: 'Address', field: 'address', tooltipField: 'address', resizable: true, sortable: true, filter: true },
      { headerName: 'Mobile', field: 'mobile', sortable: true, filter: true },
      { headerName: 'Branch', field: 'bname', tooltipField: 'address', sortable: true, filter: true },
      { headerName: 'Branch Code', field: 'bid', sortable: true },
      { headerName: 'Branch Address', field: 'bnAddress', sortable: true },
      { headerName: 'Course', field: 'cname', sortable: true },
      { headerName: 'Duration', field: 'duration', sortable: true },
      { headerName: 'C1', field: 'c1', sortable: true },
      { headerName: 'C2', field: 'c2', sortable: true },
      { headerName: 'Date Of Birth', field: 'dob', sortable: true },
      { headerName: 'Date of Joining', field: 'sjoin', sortable: true, filter: true }, //cellRenderer: 'dateTimeRenderer', cellRendererParams: 'yyyy-MM-dd'
      { headerName: 'Pic Name', field: 'removeExtention', sortable: true },
      { headerName: 'PIC', field: 'pic', sortable: true, cellRenderer: ImageFormatterComponent },
      { headerName: 'Theory(M1)', field: 'theory', sortable: true },
      { headerName: 'Practical(M2)', field: 'practical', sortable: true }
    ];
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
  onSelectFromDate(date: NgbDateStruct) {
    this.searchFromDate = date;
  }

  onSelectToDate(date: NgbDateStruct) {
    this.searchToDate = date;
  }
  getPaymentEaning() {
    this.spinner.show();
    this.paymenteraningList = [];
    if (this.searchFromDate && this.searchToDate) {
      const searchFromDate = this.datePipe.transform(new Date(this.searchFromDate.year, this.searchFromDate.month - 1, this.searchFromDate.day), 'yyyy-MM-dd')!;
      const searchToDate = this.datePipe.transform(new Date(this.searchToDate.year, this.searchToDate.month - 1, this.searchToDate.day), 'yyyy-MM-dd')!;
      this.branchstudentbindService.getAdminStudentIcard(this.branchId, searchFromDate, searchToDate).subscribe((res: any) => {
        this.paymenteraningList = res;
        this.spinner.hide();
      });
    }
    else {
      this.toastr.warning('Enter', 'From Date to To Date');
      this.spinner.hide();
    }
  }

  ngOnInit() {
    this.getAllBranch();
    this.branchId = 0;
  }
  excelFileData() {
    let strhtml = "";
    strhtml += " <table class=\"table table-hover table-bordered table-striped\" border=\"1\">";
    strhtml += "  <thead>";
    strhtml += "       <tr>";
    strhtml += "        <th>ID</th>";
    strhtml += "         <th>Name</th>";
    strhtml += "         <th>Father Name</th>";
    strhtml += "         <th>Address</th>";
    strhtml += "         <th>Mobile</th>";
    strhtml += "         <th>Branch</th>";
    strhtml += "         <th>Branch Code</th>";
    strhtml += "         <th>Branch Address</th>";
    strhtml += "         <th>Course</th>";
    strhtml += "         <th>Duration</th>";
    strhtml += "         <th>C1</th>";
    strhtml += "         <th>C2</th>";
    strhtml += "         <th>Date of Birth</th>";
    strhtml += "         <th>Date of Joining</th>";
    strhtml += "         <th>Pic Name</th>";
    strhtml += "         <th width =\"50\" height =\"50\">PIC</th>";
     strhtml += "         <th>Theory(M1)</th>";
    strhtml += "         <th>Practical(M2)</th>";
    strhtml += "                   </tr>";
    strhtml += "               </thead>";
    strhtml += "              <tbody>";
    for (const key in this.paymenteraningList) {
      strhtml += "        <tr>";
      strhtml += "          <td>" + this.paymenteraningList[key].stid + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].sname + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].guardian + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].address + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].mobile + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].bname + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].bid + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].bnAddress + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].cname + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].duration + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].c1 + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].c2 + "</td>";     
      strhtml += "          <td>" + this.paymenteraningList[key].dob + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].sjoin + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].removeExtention + "</td>";
      strhtml += "          <td width =\"50\" height =\"50\"><img width =\"50\" height =\"50\" src =\"" + environment.apiUrl + "/Files/" + this.paymenteraningList[key].pic + "\"></td>";
      strhtml += "          <td>" + this.paymenteraningList[key].theory + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].practical + "</td>";
      //  strhtml += "           <td>" + this.branchviewstudentList[key].stupic + "</td>";
      strhtml += "   </tr>";

    }
    strhtml += "      </tbody>";
    strhtml += "      </table>";
    const blob = new Blob([strhtml], {
      type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
    });
    const link = document.createElement('a');
    link.href = window.URL.createObjectURL(blob);
    link.download = 'StudentIDCardList.xls';
    link.click();
    window.URL.revokeObjectURL(link.href);
  }
  printData() {
    let strhtml = "";
    strhtml += " <table class=\"table table-hover table-bordered table-striped\" border=\"1\">";
    strhtml += "  <thead>";
    strhtml += "       <tr>";
    strhtml += "        <th>ID</th>";
    strhtml += "         <th>Name</th>";
    strhtml += "         <th>Father Name</th>";
    strhtml += "         <th>Address</th>";
    strhtml += "         <th>Mobile</th>";
    strhtml += "         <th>Branch</th>";
    strhtml += "         <th>Branch Code</th>";
    strhtml += "         <th>Branch Address</th>";
    strhtml += "         <th>Course</th>";
    strhtml += "         <th>Duration</th>";
    strhtml += "         <th>C1</th>";
    strhtml += "         <th>C2</th>";
    strhtml += "         <th>Date of Birth</th>";
    strhtml += "         <th>Date of Joining</th>";
    strhtml += "         <th>Pic Name</th>";
    strhtml += "         <th width =\"50\" height =\"50\">PIC</th>";
    strhtml += "         <th>Theory(M1)</th>";
    strhtml += "         <th>Practical(M2)</th>";
    strhtml += "                   </tr>";
    strhtml += "               </thead>";
    strhtml += "              <tbody>";
    for (const key in this.paymenteraningList) {
      strhtml += "        <tr>";
      strhtml += "          <td>" + this.paymenteraningList[key].stid + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].sname + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].guardian + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].address + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].mobile + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].bname + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].bid + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].bnAddress + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].cname + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].duration + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].c1 + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].c2 + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].theory + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].practical + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].dob + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].sjoin + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].removeExtention + "</td>";
      strhtml += "          <td width =\"50\" height =\"50\"><img width =\"50\" height =\"50\" src =\"" + environment.apiUrl + "/Files/" + this.paymenteraningList[key].pic + "\"></td>";
      strhtml += "          <td>" + this.paymenteraningList[key].theory + "</td>";
      strhtml += "          <td>" + this.paymenteraningList[key].practical + "</td>";
      //  strhtml += "           <td>" + this.branchviewstudentList[key].stupic + "</td>";
      strhtml += "   </tr>";

    }
    strhtml += "      </tbody>";
    strhtml += "      </table>";
    const mywindow = window.open('', '_blank', 'height=600,width=700')!;
    mywindow.document.open();
    mywindow.document.write(strhtml);
    setTimeout(() => {
      mywindow.print();
      mywindow.close();
    }, 1000);

  }
}
