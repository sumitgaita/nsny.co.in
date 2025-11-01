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
import { ConfirmationDialogService } from '../confirmation-dialog/confirmation-dialog.service';

@Component({
  selector: 'noticeto-branch-details',
  templateUrl: './noticetobranchdetails.component.html',
  styleUrls: ['./noticetobranchdetails.component.scss'],
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
export class NoticetobranchdetailsComponent implements OnInit, OnDestroy {
  loading = false;
  public visible = false;
  @ViewChild('editModel') editModel: NgbModal | any;
  @ViewChild('receiptModel') receiptModel: NgbModal | any;
  modalHeaderTitle!: string;
  modalOptions: NgbModalOptions;
  submitted = false;
  editFeesCollectionForm: FormGroup | any;
  closeResult!: string;
  getAllNotification: any[] = [];
  PaymentRecivedList: any[] = [];
  columnDefs: ColDef[] = [];
  recivedColumnDefs: ColDef[] = [];
  currentUser: any;
  pageSize: number = 20;
  private subscription: Subscription[] = [];
  selectedData: any;
  constructor(
    private branchstudentbindService: BranchstudentbindService,
    private modalService: NgbModal,
    private formBuilder: FormBuilder,
    private zone: NgZone,
    private datePipe: DatePipe,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private authenticationService: AuthenticationService,
    private confirmationDialogService: ConfirmationDialogService
  ) {

    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    this.columnDefs = [
      {
        headerName: '',
    checkboxSelection: true,
    filter: false,
    field: 'id',
    sortable: false,
    width:50,
    headerCheckboxSelection: true,
    headerCheckboxSelectionFilteredOnly: true,
    cellRendererParams:(params:any) => {
                console.log(params);
                //if (this.checkValue) {
                 params.node.selected = true;
               // }
            }
  },
      
      { headerName: 'Title', width: 200, field: 'title', sortable: true },
      { headerName: 'Branch Name', field: 'bname', width: 200, sortable: true, filter: true },
      { headerName: 'Content Details', width: 500, field: 'content_details', tooltipField: 'content_details', tooltipComponentParams: { color: '#ececec' }, sortable: true, filter: true }

    ];

    this.modalOptions = {
      backdrop: 'static',
      backdropClass: 'customBackdrop'
    }
  }

  ngOnInit() {
    this.loading = true;

    this.getAllNotificationDetails();
    this.setupSubscription();
  }
  ngOnDestroy() {
    this.subscription.forEach(sub => {
      sub.unsubscribe();
    });
    this.subscription = [];
  }

  onSelectionChanged(event: any) {
    this.selectedData = null;
    this.selectedData = event.api.getSelectedRows();
   
  }
  deleteNotice() {
    if (this.selectedData && this.selectedData.length > 0) {
      this.NotificationDelete();
    }
    else {
      this.toastr.warning('Please click on CheckBox', 'CheckBox');
    }

  }
  private getAllNotificationDetails() {
    this.spinner.show();
    this.getAllNotification = [];
    this.branchstudentbindService.getAllNotification().subscribe((res: any) => {
      if (res && res.length > 0) {
        this.getAllNotification = res;
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }

  setupSubscription() {
    if (this.subscription.length === 0) {
      this.subscription.push(BranchstudentbindService.onDeleteNotice.subscribe((item: any) => {
        this.zone.run(() => {
          //this.NotificationDelete(item.data.id);
        });
      }));
    }

  }

  NotificationDelete() {
    this.confirmationDialogService.confirm('Delete', 'Do you want to delete Notification ?')
      .then((confirmed) => {
        if (confirmed) {
          this.spinner.show();
          for (let index in this.selectedData) {
            this.branchstudentbindService.deleteNotification(this.selectedData[index].id).subscribe((res: any) => {
            
            });
          }
          this.spinner.hide();
          this.toastr.success('Successfully', 'Delete');
          this.getAllNotificationDetails();
         
        }
      })
      .catch(() => console.log('User dismissed the dialog '));
  }



}
