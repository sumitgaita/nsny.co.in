import { Component, ElementRef, OnDestroy, OnInit, ViewChild, NgZone } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormsModule, FormGroup, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { NgbModalModule, NgbAlertModule, NgbDatepickerModule, NgbModal, ModalDismissReasons, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule, DatePipe } from '@angular/common'
import { DocsExampleComponent } from '@docs-components/public-api';
import { NgxSpinnerService } from "ngx-spinner";
import { PermissionService } from '../../../services/permission.service';
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
  selector: 'edit-permission',
  templateUrl: './editpermission.component.html',
  styleUrls: ['./editpermission.component.scss'],
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
export class EditpermissionComponent implements OnInit, OnDestroy {
  loading = false;
  public visible = false;
  @ViewChild('editModel') editModel: NgbModal | any;
  modalHeaderTitle!: string;
  modalOptions: NgbModalOptions;
  submitted = false;
  editPermissionForm: FormGroup | any;
  closeResult!: string;
  permissionList: any[] = [];
  columnDefs: ColDef[] = [];
  currentUser: any;
  pageSize: number = 20;
  userpermissionid: number | undefined;
  private subscription: Subscription[] = [];
  constructor(
    private permissionService: PermissionService,
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
        headerName: 'Edit',
        field: '',
        width: 100,
        tooltipField: 'id',
        cellRenderer: function (param: any): any {
          if (param.data.stid !== '') {
            const eDiv = document.createElement('div');
            let cellDef = '';
            cellDef += `<a class='payment-cell'><img border="0" width="25" height="23" src=\"${environment.apiUrl}/common/theme/images/icoWrkEdit.gif\"></a>`;
            eDiv.innerHTML = cellDef;
            if (eDiv.querySelector('.payment-cell')) {
              eDiv.querySelector('.payment-cell')!.addEventListener('click', (ev: any) => {
                PermissionService.onEditPermissionRow.emit({ data: param.data });
              })
            }
            return eDiv;
          }
        },
        sortable: false
      },
      // { headerName: 'ID', width: 150, field: 'id', sortable: true },
      { headerName: 'User Name', width: 135, field: 'username', tooltipField: 'username', sortable: true, filter: true },
      { headerName: 'Password', width: 135, field: 'pass', tooltipField: 'Pass', sortable: true, filter: true },
      { headerName: 'Name', width: 150, field: 'name', tooltipField: 'name', tooltipComponentParams: { color: '#ececec' }, sortable: true, filter: true },//, cellRenderer: 'dateTimeRenderer', cellRendererParams: 'yyyy-MM-dd'
      { headerName: 'Add Catagory', width: 150, field: 'addcatagory', sortable: true, filter: true },
      { headerName: 'Edit Catagory', width: 135, field: 'editcatagory', sortable: true, filter: true },
      { headerName: 'Add Course', width: 135, field: 'addcourse', sortable: true, filter: true },
      { headerName: 'Edit Course', width: 135, field: 'editcourse', sortable: true, filter: true },
      { headerName: 'Add Branch', width: 135, field: 'addbranch', sortable: true, filter: true },
      { headerName: 'Edit Branch', width: 135, field: 'editbranch', sortable: true, filter: true },//, cellRenderer: 'dateTimeRenderer', cellRendererParams: 'yyyy-MM-dd'
      { headerName: 'Edit Student', width: 135, field: 'editstudent', sortable: true, filter: true },
      { headerName: 'Edit Branch Student Bind', width: 220, field: 'editbranchstudentbind', sortable: true, filter: true },
      { headerName: 'Notice to branch', width: 170, field: 'noticetobranch', sortable: true, filter: true },
      { headerName: 'All Notice to branch', width: 200, field: 'allnoticetobranch', sortable: true, filter: true },
      { headerName: 'Student Registration', width: 200, field: 'studentregistration', sortable: true, filter: true },
      { headerName: 'Student icard', width: 135, field: 'studenticard', sortable: true, filter: true },
      { headerName: 'Status', width: 135, field: 'active', sortable: true, filter: true }
    ];

    this.modalOptions = {
      backdrop: 'static',
      backdropClass: 'customBackdrop'
    }
  }

  ngOnInit() {
    this.loading = true;
    this.editPermissionForm = this.formBuilder.group({
      username: ['', Validators.required],
      pass: ['', Validators.required],
      name: [''],
      addcatagory: false,
      editcatagory: false,
      addcourse: false,
      editcourse: false,
      addbranch: false,
      editbranch: false,
      editstudent: false,
      editbranchstudentbind: false,
      noticetobranch: false,
      allnoticetobranch: false,
      studentregistration: false,
      studenticard: false,
      active: false
    });
    this.getPermissionList();
    this.setupSubscription();
  }
  ngOnDestroy() {
    this.subscription.forEach(sub => {
      sub.unsubscribe();
    });
    this.subscription = [];
  }

  get f() { return this.editPermissionForm.controls; }
  private getPermissionList() {
    this.spinner.show();
    this.permissionList = [];
    this.permissionService.getAllPermission().subscribe((res: any) => {
      if (res && res.length > 0) {
        this.permissionList = res;
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }

  setupSubscription() {
    if (this.subscription.length === 0) {
      this.subscription.push(PermissionService.onEditPermissionRow.subscribe((item: any) => {
        this.spinner.show();
        if (item) {
          this.openPermissionPopup(this.editModel, item.data);
        }
        else {
          this.zone.run(() => {
            this.spinner.hide();
            this.toastr.info('User', 'Not Exit');
          });

        }
      }));

    }

  }

  openPermissionPopup(content: any, item: any) {
    this.userpermissionid = item.id;
    this.editPermissionForm.get('username').setValue(item.username);
    this.editPermissionForm.get('pass').setValue(item.pass);
    this.editPermissionForm.get('name').setValue(item.name);
    this.editPermissionForm.get('addcatagory').setValue(item.addcatagory);
    this.editPermissionForm.get('editcatagory').setValue(item.editcatagory);
    this.editPermissionForm.get('addcourse').setValue(item.addcourse);
    this.editPermissionForm.get('editcourse').setValue(item.editcourse);
    this.editPermissionForm.get('addbranch').setValue(item.addbranch);
    this.editPermissionForm.get('editbranch').setValue(item.editbranch);
    this.editPermissionForm.get('editstudent').setValue(item.editstudent);
    this.editPermissionForm.get('editbranchstudentbind').setValue(item.editbranchstudentbind);
    this.editPermissionForm.get('noticetobranch').setValue(item.noticetobranch);
    this.editPermissionForm.get('allnoticetobranch').setValue(item.allnoticetobranch);
    this.editPermissionForm.get('studentregistration').setValue(item.studentregistration);
    this.editPermissionForm.get('studenticard').setValue(item.studenticard);
    this.editPermissionForm.get('active').setValue(item.active);
    this.openModel(content);
    this.spinner.hide();
  }

  openReceiptPopup(content: any) {
    this.openModel(content);
  }
  onEditUserPermissionSubmit() {
    this.submitted = true;
    if (this.editPermissionForm.invalid) {
      return;
    }

    this.spinner.show();
    const editpermission = {
      username: this.f.username.value,
      pass: this.f.pass.value,
      name: this.f.name.value,
      addcatagory: this.f.addcatagory.value,
      editcatagory: this.f.editcatagory.value,
      addcourse: this.f.addcourse.value,
      editcourse: this.f.editcourse.value,
      addbranch: this.f.addbranch.value,
      editbranch: this.f.editbranch.value,
      editstudent: this.f.editstudent.value,
      editbranchstudentbind: this.f.editbranchstudentbind.value,
      noticetobranch: this.f.noticetobranch.value,
      allnoticetobranch: this.f.allnoticetobranch.value,
      studentregistration: this.f.studentregistration.value,
      studenticard: this.f.studenticard.value,
      active: this.f.active.value,
      id: this.userpermissionid
    }
    this.permissionService.updatePermission(editpermission).subscribe((res: any) => {
      if (!res) {
        this.toastr.success('Successfully', 'Updated');
        this.getPermissionList();
        this.modalService.dismissAll();
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
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

}
