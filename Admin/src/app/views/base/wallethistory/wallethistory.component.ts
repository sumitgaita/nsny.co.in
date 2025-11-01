import { Component} from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { NgbModalModule, NgbAlertModule, NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule, DatePipe } from '@angular/common'
import { DocsExampleComponent } from '@docs-components/public-api';
import { NgxSpinnerService } from "ngx-spinner";
import { AuthenticationService } from '../../../services/authentication.service';
import { WalletService } from '../../../services/wallet.service';
import {
  RowComponent, ColComponent, TextColorDirective, CardComponent,
  CardHeaderComponent, CardBodyComponent, InputGroupComponent, InputGroupTextDirective,
  FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective,
  ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective,
  DropdownItemDirective, DropdownDividerDirective, FormSelectDirective
} from '@coreui/angular';
import { ToastrService } from "ngx-toastr";
import { AgGridAngular } from 'ag-grid-angular'; // Angular Data Grid Component
import { ColDef } from 'ag-grid-community'; // Column Definition Type Interface

@Component({
  selector: 'wallet-history',
  templateUrl: './wallethistory.component.html',
  styleUrls: ['./wallethistory.component.scss'],
  standalone: true,
  imports: [RowComponent, ColComponent, TextColorDirective, CardComponent,
    CardHeaderComponent, CardBodyComponent, DocsExampleComponent,
    InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective,
    FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent,
    DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective,
    RouterLink, DropdownDividerDirective,
    FormSelectDirective, ReactiveFormsModule, NgbModalModule,
    NgbAlertModule, NgbDatepickerModule,
    CommonModule, FormsModule, AgGridAngular],

})
export class WallethistoryComponent {

  columnDefs: ColDef[] = [];
  loading = false;
  currentUser: any;
  wallethistoryDetailsList: any[] = [];
  pageSize: number = 50;
  branchList: any[] = [];
  branchId: number = 0;
  paymentNote!: string;
  paymentNoteList: string[] = ['Add Billing', 'Spend by center', 'extracharge + fine'];
  constructor(
    private authenticationService: AuthenticationService,
    private walletService: WalletService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    this.columnDefs = [
      { headerName: 'Branch', field: 'bname', tooltipField: 'bname', sortable: true, filter: true },
      { headerName: 'Student ID', field: 'stid', sortable: true, filter: true },
      { headerName: 'Course', field: 'cname', tooltipField: 'cname', sortable: true, filter: true },
      { headerName: 'Comment', field: 'comment', sortable: true, filter: true },
      { headerName: 'Wallet Amount', field: 'walletamount', sortable: true, filter: true },
      { headerName: 'Extra Offer', field: 'extraoffer', sortable: true },
      { headerName: 'Total Amount', field: 'totalamount', sortable: true, filter: true },//, cellRenderer: 'dateTimeRenderer', cellRendererParams: 'yyyy-MM-dd'
      { headerName: 'Existing Amount', field: 'existingamount', sortable: true },
      { headerName: 'Extra Charges + Fine', field: 'extrachargesfine', sortable: true },
      { headerName: 'Payment Note', field: 'paymentnote', sortable: true },
      { headerName: 'Created Date', field: 'createddate', sortable: true }
    ];
  }
  private getAllBranch() {
    this.spinner.show();
    this.branchList = [];
    this.walletService.getAllWalletBranch().subscribe((res: any) => {
      if (res && res.length > 0) {
        this.branchList = res;
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }

  getWalletHistory() {
    this.spinner.show();
    if (this.branchId > 0 && this.paymentNote != '') {
      this.walletService.getWalletHistoryDetails(this.branchId, this.paymentNote).subscribe((res: any) => {
        this.wallethistoryDetailsList = res;
        this.spinner.hide();
      });
    }
    else {
      this.toastr.warning('Select', 'Branch & Wallet Note');
      this.spinner.hide();
    }
  }

  ngOnInit() {
    this.loading = true;
    this.getAllBranch();
    this.branchId = 0;
  }
  excelFileData() {
    let strhtml = "";
    strhtml += " <table class=\"table table-hover table-bordered table-striped\" border=\"1\">";
    strhtml += "  <thead>";
    strhtml += "       <tr>";
    strhtml += "        <th>Branch</th>";
    strhtml += "         <th>Student ID</th>";
    strhtml += "         <th>Course</th>";
    strhtml += "         <th>Comment</th>";
    strhtml += "         <th>Wallet Amount</th>";
    strhtml += "         <th>Extra Offer</th>";
    strhtml += "         <th>Total Amount</th>";
    strhtml += "         <th>Existing Amount</th>";
    strhtml += "         <th>Extra Charges + Fine</th>";
    strhtml += "         <th>Payment Note</th>";
    strhtml += "         <th>Created Date</th>";
    strhtml += "                   </tr>";
    strhtml += "               </thead>";
    strhtml += "              <tbody>";
    for (const key in this.wallethistoryDetailsList) {
      strhtml += "        <tr>";
      strhtml += "          <td>" + this.wallethistoryDetailsList[key].bname + "</td>";
      strhtml += "          <td>" + this.wallethistoryDetailsList[key].stid + "</td>";
      strhtml += "          <td>" + this.wallethistoryDetailsList[key].cname + "</td>";
      strhtml += "          <td>" + this.wallethistoryDetailsList[key].comment + "</td>";
      strhtml += "          <td>" + this.wallethistoryDetailsList[key].walletamount + "</td>";
      strhtml += "          <td>" + this.wallethistoryDetailsList[key].extraoffer + "</td>";
      strhtml += "          <td>" + this.wallethistoryDetailsList[key].totalamount + "</td>";
      strhtml += "          <td>" + this.wallethistoryDetailsList[key].existingamount + "</td>";
      strhtml += "          <td>" + this.wallethistoryDetailsList[key].extrachargesfine + "</td>";
      strhtml += "          <td>" + this.wallethistoryDetailsList[key].paymentnote + "</td>";
      strhtml += "          <td>" + this.wallethistoryDetailsList[key].createddate + "</td>";
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
    strhtml += "        <th>Branch</th>";
    strhtml += "         <th>Student ID</th>";
    strhtml += "         <th>Course</th>";
    strhtml += "         <th>Comment</th>";
    strhtml += "         <th>Wallet Amount</th>";
    strhtml += "         <th>Extra Offer</th>";
    strhtml += "         <th>Total Amount</th>";
    strhtml += "         <th>Existing Amount</th>";
    strhtml += "         <th>Extra Charges + Fine</th>";
    strhtml += "         <th>Payment Note</th>";
    strhtml += "         <th>Created Date</th>";
    strhtml += "                </tr>";
    strhtml += "               </thead>";
    strhtml += "              <tbody>";
    for (const key in this.wallethistoryDetailsList) {
      strhtml += "        <tr>";
      strhtml += "          <td>" + this.wallethistoryDetailsList[key].bname + "</td>";
      strhtml += "          <td>" + this.wallethistoryDetailsList[key].stid + "</td>";
      strhtml += "          <td>" + this.wallethistoryDetailsList[key].cname + "</td>";
      strhtml += "          <td>" + this.wallethistoryDetailsList[key].comment + "</td>";
      strhtml += "          <td>" + this.wallethistoryDetailsList[key].walletamount + "</td>";
      strhtml += "          <td>" + this.wallethistoryDetailsList[key].extraoffer + "</td>";
      strhtml += "          <td>" + this.wallethistoryDetailsList[key].totalamount + "</td>";
      strhtml += "          <td>" + this.wallethistoryDetailsList[key].existingamount + "</td>";
      strhtml += "          <td>" + this.wallethistoryDetailsList[key].extrachargesfine + "</td>";
      strhtml += "          <td>" + this.wallethistoryDetailsList[key].paymentnote + "</td>";
      strhtml += "          <td>" + this.wallethistoryDetailsList[key].createddate + "</td>";
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
