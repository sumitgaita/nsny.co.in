import { Component } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { NgbAlertModule, NgbDatepickerModule, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule, DatePipe } from '@angular/common'
import { DocsExampleComponent } from '@docs-components/public-api';
import { NgxSpinnerModule } from "ngx-spinner";
import { NgxSpinnerService } from "ngx-spinner";
import { BranchstudentbindService } from '../../../services/branchstudentbind.service';
import { BranchService } from '../../../services/branch.service';
import { RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent, CardBodyComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, DropdownDividerDirective, FormSelectDirective } from '@coreui/angular';
import { ToastrService } from "ngx-toastr";

import { AgGridAngular } from 'ag-grid-angular'; // Angular Data Grid Component
import { ColDef } from 'ag-grid-community'; // Column Definition Type Interface

@Component({
  selector: 'student-registration',
  templateUrl: './studentregistration.component.html',
  styleUrls: ['./studentregistration.component.scss'],
  standalone: true,
  imports: [RowComponent, ColComponent, TextColorDirective, CardComponent,
    CardHeaderComponent, CardBodyComponent, DocsExampleComponent,
    InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective,
    FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent,
    DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective,
    RouterLink, DropdownDividerDirective,
    FormSelectDirective, ReactiveFormsModule, NgxSpinnerModule, NgbAlertModule, NgbDatepickerModule,
    CommonModule, FormsModule, AgGridAngular]
})
export class StudentRegistrationComponent {
  searchFromDate!: NgbDateStruct;
  searchToDate!: NgbDateStruct;
  columnDefs: ColDef[] = [];
  loading = false;
  currentUser: any;
  paymenteraningList: any[] = [];
  pageSize: number = 50;
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
    //this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    this.columnDefs = [
      { headerName: 'Branch', field: 'bname', tooltipField: 'bname', sortable: true, filter: true },
      { headerName: 'Student ID', field: 'stid', sortable: true, filter: true },
      { headerName: 'Course', field: 'cname', tooltipField: 'cname', sortable: true, filter: true },
      { headerName: 'Course Fees', field: 'ctotal', sortable: true, filter: true },
      { headerName: 'Payment Mode', field: 'ctype', sortable: true, filter: true },
      { headerName: 'Discount', field: 'cdiscount', sortable: true },
      { headerName: 'Payment Mode', field: 'sjoin', sortable: true, filter: true },//, cellRenderer: 'dateTimeRenderer', cellRendererParams: 'yyyy-MM-dd'
      { headerName: 'Status', field: 'paymentclear', sortable: true }
    ];
  }

  onGridReady(params: any) {
    this.gridApi = params.api;
    this.gridColumnApi = params.columnApi;
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
    if (this.searchFromDate && this.searchToDate) {
      const searchFromDate = this.datePipe.transform(new Date(this.searchFromDate.year, this.searchFromDate.month - 1, this.searchFromDate.day), 'yyyy-MM-dd')!;
      const searchToDate = this.datePipe.transform(new Date(this.searchToDate.year, this.searchToDate.month - 1, this.searchToDate.day), 'yyyy-MM-dd')!;
      this.branchstudentbindService.getStuRegistrationList(this.branchId, searchFromDate, searchToDate).subscribe((res: any) => {
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
    this.loading = true;
    this.getAllBranch();
    this.branchId = 0;
  }
}
