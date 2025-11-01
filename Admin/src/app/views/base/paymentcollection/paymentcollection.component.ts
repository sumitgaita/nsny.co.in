import { Component, ElementRef, OnDestroy, OnInit, ViewChild, NgZone } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormsModule, FormGroup, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { NgbModalModule, NgbAlertModule, NgbDatepickerModule, NgbModal, ModalDismissReasons, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule, DatePipe } from '@angular/common'
import { DocsExampleComponent } from '@docs-components/public-api';
import { NgxSpinnerService } from "ngx-spinner";
import { BranchstudentbindService } from '../../../services/branchstudentbind.service';
import { AuthenticationService } from '../../../services/authentication.service';
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
import { Subscription } from 'rxjs';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'payment-collection',
  templateUrl: './paymentcollection.component.html',
  styleUrls: ['./paymentcollection.component.scss'],
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
export class PaymentCollectionComponent implements OnInit, OnDestroy {
  loading = false;
  public visible = false;
  @ViewChild('editModel') editModel: NgbModal | any;
  @ViewChild('receiptModel') receiptModel: NgbModal | any;
  modalHeaderTitle!: string;
  modalOptions: NgbModalOptions;
  submitted = false;
  editFeesCollectionForm: FormGroup | any;
  closeResult!: string;
  PaymentCollectionList: any[] = [];
  PaymentRecivedList: any[] = [];
  columnDefs: ColDef[] = [];
  recivedColumnDefs: ColDef[] = [];
  currentUser: any;
  pageSize: number = 20;
  private subscription: Subscription[] = [];
  constructor(
    private branchstudentbindService: BranchstudentbindService,
    private modalService: NgbModal,
    private formBuilder: FormBuilder,
    private zone: NgZone,
    private datePipe: DatePipe,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private authenticationService: AuthenticationService
  ) {

    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    this.columnDefs = [
      {
        headerName: 'Payment',
        field: '',
        width: 100,
        tooltipField: 'stid',
        cellRenderer: function (param: any): any {
          if (param.data.stid !== '') {
            const eDiv = document.createElement('div');
            let cellDef = '';
            cellDef += `<a class='payment-cell'><img border="0" width="25" height="23" src=\"${environment.apiUrl}/common/theme/images/icoWrkEdit.gif\"></a>`;
            eDiv.innerHTML = cellDef;
            if (eDiv.querySelector('.payment-cell')) {
              eDiv.querySelector('.payment-cell')!.addEventListener('click', (ev: any) => {
                BranchstudentbindService.onEditPaymentRow.emit({ data: param.data });
              })
            }
            return eDiv;
          }
        },
        sortable: false
      },
      {
        headerName: 'Receipt',
        field: '',
        width: 100,
        tooltipField: 'stid',
        cellRenderer: function (param: any): any {
          if (param.data.stid !== '') {
            const eDiv = document.createElement('div');
            let cellDef = '';
            cellDef += `<a class='receipt-cell'><img border="0" width="25" height="23" src=\"${environment.apiUrl}/common/theme/images/download.jpg\"></a>`;
            eDiv.innerHTML = cellDef;
            if (eDiv.querySelector('.receipt-cell')) {
              eDiv.querySelector('.receipt-cell')!.addEventListener('click', (ev: any) => {
                BranchstudentbindService.onEditReceiptRow.emit({ data: param.data });
              })
            }
            return eDiv;

          }
        },
        sortable: false
      },
      { headerName: 'ID', width: 150, field: 'stid', sortable: true },
      { headerName: 'Name', field: 'sname', sortable: true, filter: true },
      { headerName: 'Course', field: 'cname', tooltipField: 'cname', tooltipComponentParams: { color: '#ececec' }, sortable: true, filter: true },
      { headerName: 'Admission', width: 100, field: 'sjoin', sortable: true, filter: true },//, cellRenderer: 'dateTimeRenderer', cellRendererParams: 'yyyy-MM-dd'
      { headerName: 'Fees', width: 100, field: 'ctotal', sortable: true, filter: true },
      { headerName: 'Discount', width: 100, field: 'cdiscount', sortable: true, filter: true },
      { headerName: 'Payment Mode', width: 135, field: 'ctype', sortable: true, filter: true },
      { headerName: 'Remainig Amount', width: 150, field: 'amountremaing', sortable: true, filter: true },
      { headerName: 'Last Amount Paid', width: 150, field: 'lastamountpay', sortable: true, filter: true },
      { headerName: 'Date of Payment', width: 135, field: 'dateofpayment', sortable: true, filter: true },//, cellRenderer: 'dateTimeRenderer', cellRendererParams: 'yyyy-MM-dd'
      { headerName: 'Installment Remaining', width: 170, field: 'remainginstallment', sortable: true, filter: true },
      {
        headerName: 'Status',
        width: 150,
        field: 'paymentclear',
        sortable: true,
        cellStyle: function (params) {
          if (params.value == 'Payment Clear') {
            //mark police cells as red
            return { color: 'green' };
          }
          else {
            return { color: 'red' };
          }
        },
        filter: true
      }
    ];
    this.recivedColumnDefs = [
      {
        headerName: '',
        field: '',
        width: 100,
        tooltipField: 'stid',
        cellRenderer: function (param: any): any {
          if (param.data.stid !== '') {
            const eDiv = document.createElement('div');
            let cellDef = '';
            cellDef += `<a class='viewreceipt-cell' style="font-size:12px; color: green; padding-bottom:10px; font-weight:bolder">View Receipt</a>`;
            eDiv.innerHTML = cellDef;
            if (eDiv.querySelector('.viewreceipt-cell')) {
              eDiv.querySelector('.viewreceipt-cell')!.addEventListener('click', (ev: any) => {
                BranchstudentbindService.onViewReceiptRow.emit({ data: param.data });
              })
            }
            return eDiv;

          }
        },
        sortable: false
      },
      { headerName: 'Student ID', width: 150, field: 'stid', sortable: true },
      { headerName: 'Student Name', width: 150, tooltipField: 'sname', field: 'sname', sortable: true, filter: true },
      { headerName: 'Course', field: 'cname', tooltipField: 'cname', tooltipComponentParams: { color: '#ececec' }, sortable: true, filter: true },
      { headerName: 'Payment Date', width: 150, field: 'dateofpayment', sortable: true }, //cellRenderer: 'dateTimeRenderer', cellRendererParams: 'yyyy-MM-dd', filter: true },
      { headerName: 'Receipt No.', width: 150, tooltipField: 'momono', field: 'momono', sortable: true, filter: true },
      { headerName: 'Amount Paid', width: 150, field: 'cpaid', sortable: true, filter: true },
      { headerName: 'ID', width: 100, field: 'id', sortable: true, filter: true }
    ];
    this.modalOptions = {
      backdrop: 'static',
      backdropClass: 'customBackdrop'
    }
  }

  ngOnInit() {
    this.loading = true;
    this.editFeesCollectionForm = this.formBuilder.group({
      stid: [''],
      stbalance: [''],
      cid: [''],
      dateofpayment: [''],
      ctotal: [''],
      totalInstallment: [''],
      cdiscount: [''],
      remainginstallment: [''],
      amountremaing: [''],
      cpaid: ['', Validators.required],
      momono: [],
      paymentclear: []
    });
    this.getPaymentCollection();
    this.setupSubscription();
  }
  ngOnDestroy() {
    this.subscription.forEach(sub => {
      sub.unsubscribe();
    });
    this.subscription = [];
  }

  get f() { return this.editFeesCollectionForm.controls; }
  private getPaymentCollection() {
    this.spinner.show();
    this.PaymentCollectionList = [];
    this.branchstudentbindService.getPaymentCollection(this.currentUser.id).subscribe((res: any) => {
      if (res && res.length > 0) {
        this.PaymentCollectionList = res;
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }
  private getPaymentRecived(sId: string) {
    this.PaymentRecivedList = [];
    this.spinner.show();
    this.branchstudentbindService.getPaymentPrintDetails(sId).subscribe((res: any) => {
      if (res && res.length > 0) {
        this.PaymentRecivedList = res;
        this.spinner.hide();
        this.openReceiptPopup(this.receiptModel);

      }
      else {
        this.zone.run(() => {
        this.spinner.hide();
          this.toastr.info('Receipt', 'Not avabilable');
        });
      }
    });
  }
  setupSubscription() {
    if (this.subscription.length === 0) {
      this.subscription.push(BranchstudentbindService.onEditPaymentRow.subscribe((item: any) => {
        this.spinner.show();
        if (item && item.data.amountremaing > 0) {
          this.openPaymentPopup(this.editModel, item.data);
        }
        else {
          this.zone.run(() => {
            this.spinner.hide();
            this.toastr.info('Payment', 'Already Clear');
          });
          
        }
      }));
      this.subscription.push(BranchstudentbindService.onEditReceiptRow.subscribe((item: any) => {
        if (item) {
          this.getPaymentRecived(item.data.stid);

        }
      }));
      this.subscription.push(BranchstudentbindService.onViewReceiptRow.subscribe((item: any) => {
        if (item) {
          this.PrintData(item.data);

        }
      }));
    }

  }
  amountRemaingCalculation() {
    let amount = 0;
    amount = (this.f.amountremaing.value - this.f.cpaid.value);
    this.editFeesCollectionForm.get('stbalance').setValue(amount);
    if (this.f.stbalance.value === 0) {
      this.editFeesCollectionForm.get('paymentclear').setValue('Payment Clear');
    }
    else if (this.f.stbalance.value > 0) {
      this.editFeesCollectionForm.get('paymentclear').setValue('Payment Not Clear');
    }
  }
  openPaymentPopup(content: any, item: any) {

    this.MomonoNumber();
    this.editFeesCollectionForm.get('stid').setValue(item.stid);
    this.editFeesCollectionForm.get('stbalance').setValue(item.amountremaing);
    this.editFeesCollectionForm.get('cid').setValue(item.cid);
    this.editFeesCollectionForm.get('dateofpayment').setValue(this.datePipe.transform(new Date(), 'yyyy-MM-dd'));
    this.editFeesCollectionForm.get('ctotal').setValue(item.ctotal);
    this.editFeesCollectionForm.get('totalInstallment').setValue(item.totalInstallment);
    this.editFeesCollectionForm.get('cdiscount').setValue(item.cdiscount);
    this.editFeesCollectionForm.get('amountremaing').setValue(item.amountremaing);
    if (item.lastamountpay === 0) {
      this.editFeesCollectionForm.get('remainginstallment').setValue((item.remainginstallment + 1));
    }
    else {
      this.editFeesCollectionForm.get('remainginstallment').setValue(item.remainginstallment);
    }
    if (item.amountremaing === 0) {
      this.editFeesCollectionForm.get('paymentclear').setValue('Payment Clear');
    }
    else if (item.amountremaing > 0) {
      this.editFeesCollectionForm.get('paymentclear').setValue('Payment Not Clear');
    }
    this.editFeesCollectionForm.get('cpaid').setValue(0);

    this.openModel(content);

    this.spinner.hide();

  }

  openReceiptPopup(content: any) {
    this.openModel(content);
  }
  onEditFeesCollectionSubmit() {
    this.submitted = true;
    if (this.editFeesCollectionForm.invalid) {
      return;
    }
    if (this.f.amountremaing.value === 0) {
      this.toastr.info('Payment', 'Already Clear');
      return;
    }
    if (this.f.cpaid.value === 0) {
      this.toastr.info('Enter', 'Amount Paid');
      return;
    }
    this.spinner.show();
    const paymentCollection = {
      stid: this.f.stid.value,
      bid: this.currentUser.id,
      cid: this.f.cid.value,
      ctotal: this.f.ctotal.value,
      cpaid: this.f.cpaid.value,
      cdiscount: this.f.cdiscount.value,
      dateofpayment: this.f.dateofpayment.value,
      stbalance: this.f.stbalance.value,
      totalInstallment: this.f.totalInstallment.value,
      remainginstallment: (this.f.remainginstallment.value - 1),
      amountremaing: this.f.stbalance.value,
      momono: this.f.momono.value,
      paymentclear: this.f.paymentclear.value
    }
    this.branchstudentbindService.paymentLastUpdate(paymentCollection).subscribe((res: any) => {
      if (res) {
        this.toastr.success('Successfully', 'Updated');
        this.editFeesCollectionForm.get('cpaid').setValue(0);
        this.PaymentCollection(paymentCollection);
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }
  private PaymentCollection(paymentCollection: any) {
    this.spinner.show();
    this.branchstudentbindService.createPaymentCollection(paymentCollection).subscribe((res: any) => {
      if (res) {
        this.toastr.success('Successfully', 'Inserted');
        this.modalService.dismissAll();
        this.getPaymentCollection();
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }
  public MomonoNumber() {
    let count = 0;
    this.branchstudentbindService.getPaymenCount(this.currentUser.id, (new Date().getFullYear() % 100).toString()).subscribe((res: any) => {
      if (res && res > 0) {
        count = res + 1;
      }
      else {
        count = 1;
      }
      this.editFeesCollectionForm.get('momono').setValue((this.currentUser.bname + "/" + new Date().getFullYear() % 100 + "/" + ("0000" + count).slice(-4)));

    });

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
  PrintData(item: any) {
    let strhtml = "";
    strhtml += "<table cellspacing=\"0\" rules =\"all\" border =\"1\"  style =\"border-collapse:collapse;\">";
    strhtml += "  <tr>";
    strhtml += "  <td>";
    strhtml += "  <table width=\"643\" border =\"0\" cellpadding =\"0\" cellspacing =\"0\" style =\"border:#666666 1px solid;font-family:Tahoma\">";
    strhtml += "      <tr>";
    strhtml += "      <td height=\"32\" colspan =\"5\" align =\"center\" valign =\"middle\" bgcolor =\"#333333\" style =\"color: #FFFFFF\"> <strong>MONEY RECEPT </strong></td>";
    strhtml += "        </tr>";
    strhtml += "        <tr>";
    strhtml += "        <td width=\"18\" height =\"9\"> </td>";
    strhtml += "          <td width=\"390\"> </td>";
    strhtml += "            <td width =\"44\"></td>";
    strhtml += "              <td width=\"171\"> </td>";
    strhtml += "                <td width =\"17\"></td>";
    strhtml += "                  <td></td>";
    strhtml += "                  </tr>";
    strhtml += "                  <tr>";
    strhtml += "                  <td height=\"21\" colspan =\"3\" valign =\"bottom\" style =\"font - size: 12px\" >&nbsp;&nbsp;&nbsp;&nbsp; Recept No. : <span> " + item.momono + " </span></td>";
    strhtml += "                    <td valign=\"bottom\" style =\"font - size: 12px\"> Date : <span> " + this.datePipe.transform(new Date(), 'dd-MM-yyyy') + " </span></td>";
    strhtml += "                      <td>&nbsp;</td>";
    strhtml += "                        <td></td>";
    strhtml += "                        </tr>";
    strhtml += "                        <tr>";
    strhtml += "                        <td height=\"21\" >&nbsp;</td>";
    strhtml += "                          <td>&nbsp;</td>";
    strhtml += "                            <td></td>";
    strhtml += "                            <td></td>";
    strhtml += "                            <td></td>";
    strhtml += "                            <td></td>";
    strhtml += "                            </tr>";
    strhtml += "                            <tr>";
    strhtml += "                            <td height=\"11\"> </td>";
    strhtml += "                              <td colspan=\"3\" valign =\"top\"><hr></td>";
    strhtml += "                                <td></td>";
    strhtml += "                                <td></td>";
    strhtml += "                                </tr>";
    strhtml += "                                <tr>";
    strhtml += "                                <td height=\"21\"> </td>";
    strhtml += "                                  <td>&nbsp; </td>";
    strhtml += "                                    <td></td>";
    strhtml += "                                    <td></td>";
    strhtml += "                                    <td></td>";
    strhtml += "                                    <td></td>";
    strhtml += "                                    </tr>";
    strhtml += "                                    <tr>";
    strhtml += "                                    <td height=\"45\">&nbsp;</td>";
    strhtml += "                                      <td colspan =\"3\" valign =\"top\" >"
    strhtml += "                                        Receive with thanks from<u>";
    strhtml += "                                          <span> " + item.sname + " </span>";
    strhtml += "                                            </u> ( Registration No. : <u>";
    strhtml += "                                            <span> " + item.stid + " </span>";
    strhtml += "                                              </u>) a sum of Rs. <u>";
    strhtml += "                                              <span> " + item.cpaid + " </span>";
    strhtml += "                                                </u>/ - for the Course of <u>";
    strhtml += "                                                  <span> " + item.cname + " </span>";
    strhtml += "                                                    </u> . </td>";
    strhtml += "                                                    <td>&nbsp;</td>";
    strhtml += "                                                      <td></td>";
    strhtml += "                                                      </tr>";
    strhtml += "                                                      <tr>";
    strhtml += "                                                      <td height=\"47\">&nbsp;</td>";
    strhtml += "                                                        <td>&nbsp;</td>";
    strhtml += "                                                          <td>&nbsp;</td>";
    strhtml += "                                                            <td>&nbsp;</td>";
    strhtml += "                                                              <td>&nbsp; </td>";
    strhtml += "                                                                <td></td>";
    strhtml += "                                                                </tr>";
    strhtml += "                                                                <tr>";
    strhtml += "                                                                <td height=\"19\"></td>";
    strhtml += "                                                                  <td> </td>";
    strhtml += "                                                                  <td colspan =\"2\" valign=\"top\" >...........................................</td>";
    strhtml += "                                                                    <td></td>";
    strhtml += "                                                                    <td></td>";
    strhtml += "                                                                    </tr>";
    strhtml += "                                                                    <tr>";
    strhtml += "                                                                    <td height=\"31\"> </td>";
    strhtml += "                                                                      <td> </td>";
    strhtml += "                                                                      <td colspan =\"2\" valign =\"top\"><div align=\"center\"> Director </div></td>";
    strhtml += "                                                                        <td></td>";
    strhtml += "                                                                        <td></td>";
    strhtml += "                                                                        </tr>";
    strhtml += "                                                                        <tr>";
    strhtml += "                                                                        <td height=\"15\"></td>";
    strhtml += "                                                                          <td></td>";
    strhtml += "                                                                          <td></td>";
    strhtml += "                                                                          <td></td>";
    strhtml += "                                                                          <td></td>";
    strhtml += "                                                                          <td></td>";
    strhtml += "                                                                          </tr>";
    strhtml += "                                                                          </table>";
    strhtml += "                                                                          </td>";
    strhtml += "                                                                          </tr>";
    strhtml += "                                                                          </table>";
    const mywindow = window.open('', '_blank', 'height=600,width=700')!;
    mywindow.document.open();
    mywindow.document.write(strhtml);
    mywindow.print();
    mywindow.close();
  }
}
