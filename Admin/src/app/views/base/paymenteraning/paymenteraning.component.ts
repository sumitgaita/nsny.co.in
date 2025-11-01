import { Component } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { NgbAlertModule, NgbDatepickerModule, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule, DatePipe } from '@angular/common'
import { DocsExampleComponent } from '@docs-components/public-api';
import { NgxSpinnerModule } from "ngx-spinner";
import { NgxSpinnerService } from "ngx-spinner";
import { BranchstudentbindService } from '../../../services/branchstudentbind.service';
import { AuthenticationService } from '../../../services/authentication.service';
import { RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent, CardBodyComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, DropdownDividerDirective, FormSelectDirective } from '@coreui/angular';
import { ToastrService } from "ngx-toastr";
import { AgGridAngular } from 'ag-grid-angular';
import { ColDef, GridOptions } from 'ag-grid-community';

@Component({
  selector: 'payment-eraning',
  templateUrl: './paymenteraning.component.html',
  styleUrls: ['./paymenteraning.component.scss'],
  standalone: true,
  imports: [RowComponent, ColComponent, TextColorDirective, CardComponent,
    CardHeaderComponent, CardBodyComponent, DocsExampleComponent,
    InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective,
    FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent,
    DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective,
    RouterLink, DropdownDividerDirective,
    FormSelectDirective, ReactiveFormsModule, NgxSpinnerModule, NgbAlertModule, NgbDatepickerModule,
    CommonModule, FormsModule, AgGridAngular],

})
export class PaymenteraningComponent {
  searchFromDate!: NgbDateStruct;
  searchToDate!: NgbDateStruct;
  columnDefs: ColDef[] = [];
  currentUser: any;
  paymenteraningList: any[] = [];
  pageSize: number = 20;

  constructor(private branchstudentbindService: BranchstudentbindService,
    private authenticationService: AuthenticationService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private datePipe: DatePipe) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    this.columnDefs = [
      { headerName: 'Student ID', field: 'stid', sortable: true, filter: true },
      { headerName: 'Course Fees', field: 'ctotal', sortable: true, filter: true },
      { headerName: 'Paid Amount', field: 'cpaid', sortable: true, filter: true },
      { headerName: 'Discount Given', field: 'cdiscount', sortable: true, filter: true },
      { headerName: 'Pay Date', field: 'dateofpayment', sortable: true },//, cellRenderer: 'dateTimeRenderer', cellRendererParams: 'yyyy-MM-dd', filter: true 
      { headerName: 'Balance Remaining', field: 'stbalance', sortable: true },
      { headerName: 'Course Installment', field: 'stinstall', sortable: true },
      { headerName: 'Installment Remains', field: 'stinstallremain', sortable: true }
    ];
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
      this.branchstudentbindService.getBranchPaymenteraning(this.currentUser.id, searchFromDate, searchToDate).subscribe((res: any) => {
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
  }

}
