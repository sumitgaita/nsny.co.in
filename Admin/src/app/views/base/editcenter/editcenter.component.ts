import { Component } from '@angular/core';
import { ReactiveFormsModule, FormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common'
import { DocsExampleComponent } from '@docs-components/public-api';
import { RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent, CardBodyComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, DropdownDividerDirective, FormSelectDirective } from '@coreui/angular';
import { Branch } from '../../../model/Branch';
import { CenterService } from '../../../services/center.service';
import { ToastrService } from 'ngx-toastr';
import { ConfirmedValidator } from './confirmed.validator'
import { ConfirmationDialogService } from '../confirmation-dialog/confirmation-dialog.service';
import { NgxSpinnerService } from "ngx-spinner";
import { CatagoryService } from '../../../services/catagory.service';
import { Catagory } from '../../../model/Catagory';
import { AuthenticationService } from '../../../services/authentication.service';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { BranchService } from '../../../services/branch.service';
@Component({
  selector: 'edit-center',
  templateUrl: './editcenter.component.html',
  styleUrls: ['./editcenter.component.scss'],
  standalone: true,
  imports: [RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent,
    CardBodyComponent, DocsExampleComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective,
    FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent,
    DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, RouterLink,
    DropdownDividerDirective, FormSelectDirective, ReactiveFormsModule, FormsModule, CommonModule, NgMultiSelectDropDownModule]
})
export class EditCenterComponent {
  loading = false;
  submitted = false;
  editCenterForm: FormGroup | any;
  selectedCenterId: number = 0;
  branchList: Branch[] = [];
  masterbranchList: Branch[] = [];
  catagoryList: Catagory[] = [];
  oldcatagoryList: Catagory[] = [];
  paymentModeList: string[] = ['Wallet', 'General'];
  currentUser: any;
  selectedItems: any[] = [];
  dropdownSettings: IDropdownSettings = {};
  selectedBranchId: number = 0;
  selectedMasterBranchId: number = 0;
  branchCode: any = '';
  branchid: any;
  branchcatagory: any;
  constructor(private centerService: CenterService,
    private confirmationDialogService: ConfirmationDialogService,
    private catagoryService: CatagoryService,
    private authenticationService: AuthenticationService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private branchService: BranchService,
    private formBuilder: FormBuilder) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  ngOnInit() {
    this.loading = true;
    this.editCenterForm = this.formBuilder.group({
      bname: ['', Validators.required],
      bcontact: ['', Validators.required],
      bemail: ['', Validators.required],
      bpass: [''],
      paymentmode: [''],
      cbpass: ['', Validators.required],
      bcommission: ['', Validators.required],
      code: ['', Validators.required],
      address: ['', Validators.required],
      //courseCatagory: ['', Validators.required],
      branchId: [],
      mastercode: ['', Validators.required]
    }, {
      validator: ConfirmedValidator('bpass', 'cbpass')
    });
    this.getAllMasterBranch();
    this.getAllCatagory();
   // this.getAllCenter();
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'id',
      textField: 'name',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 10,
      allowSearchFilter: true
    };
  }
  get f() { return this.editCenterForm.controls; }
  private getAllMasterBranch() {
    this.spinner.show();
    this.masterbranchList = [];
    this.branchService.getAllBranch().subscribe((res: any) => {
      if (res && res.length > 0) {
        this.masterbranchList = res;
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }
  getBranchDetails() {
    for (const key in this.masterbranchList) {
      if (this.masterbranchList[key].id === Number(this.selectedMasterBranchId)) {
        this.branchCode = this.masterbranchList[key].code;
        this.branchid = this.masterbranchList[key].id;
        this.branchcatagory = this.masterbranchList[key].courseCatagory;
        const idSet = new Set(
          this.branchcatagory.split(",").map(Number).map((obj: any) => obj)
        );
        const cat = this.oldcatagoryList;
        this.catagoryList = cat.filter((item: any) =>
          idSet.has(item.id)
        );
        if (this.branchcatagory === '') {
          this.toastr.info('Go to master branch edit menu and update catagory.');
        }
        this.getAllCenter();
        break;
      }
    }
  }
  private getAllCenter() {
    this.spinner.show();
    this.branchList = [];
    this.centerService.getBranchCenter(this.branchid).subscribe((res: any) => {
      if (res && res.length > 0) {
        this.branchList = res;
        this.editCenterForm.get('bname').setValue(res[0].bname);
        this.editCenterForm.get('branchId').setValue(res[0].branchId);
        this.editCenterForm.get('bcontact').setValue(res[0].bcontact);
        this.editCenterForm.get('bemail').setValue(res[0].bemail);
        this.editCenterForm.get('bpass').setValue(res[0].bpass);
        this.editCenterForm.get('cbpass').setValue(res[0].bpass);
        this.editCenterForm.get('bcommission').setValue(res[0].bcommission);
        this.editCenterForm.get('paymentmode').setValue(res[0].paymentmode);
        this.editCenterForm.get('address').setValue(res[0].address);
        this.editCenterForm.get('code').setValue(res[0].code);
        //this.editCenterForm.get('courseCatagory').setValue(res[0].courseCatagory);
        const selectedIds = res[0].courseCatagory.split(',').map(Number);
        this.selectedItems = this.catagoryList.filter(item => selectedIds.includes(item.id));
        this.editCenterForm.get('mastercode').setValue(res[0].mastercode);
        this.selectedCenterId = res[0].id;
        this.editCenterForm.get('code')?.disable();
        this.editCenterForm.get('mastercode')?.disable();
        this.spinner.hide();
      }
      else {
        this.toastr.warning('No branch available under this master branch.');
        this.clearFrom();
        this.spinner.hide();
      }
    });
  }

  private getAllCatagory() {
    this.spinner.show();
    this.catagoryList = [];
    this.catagoryService.getAllCatagory().subscribe((res: any) => {
      if (res && res.length > 0) {
        this.oldcatagoryList = res;
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }

  getCenterDetails() {
    for (const key in this.branchList) {
      if (this.branchList[key].id === Number(this.selectedCenterId)) {
        this.editCenterForm.get('bname').setValue(this.branchList[key].bname);
        this.editCenterForm.get('bcontact').setValue(this.branchList[key].bcontact);
        this.editCenterForm.get('bemail').setValue(this.branchList[key].bemail);
        this.editCenterForm.get('bpass').setValue(this.branchList[key].bpass);
        this.editCenterForm.get('cbpass').setValue(this.branchList[key].bpass);
        this.editCenterForm.get('bcommission').setValue(this.branchList[key].bcommission);
        this.editCenterForm.get('paymentmode').setValue(this.branchList[key].paymentmode);
        this.editCenterForm.get('address').setValue(this.branchList[key].address);
        this.editCenterForm.get('code').setValue(this.branchList[key].code);
        // this.editCenterForm.get('courseCatagory').setValue(this.branchList[key].courseCatagory);
        const selectedIds = (this.branchList[key]?.courseCatagory?.split(',').map(Number)) as any;
        this.selectedItems = this.catagoryList.filter(item => selectedIds.includes(item.id));
        break;
      }
    }
  }
  onEditCenterSubmit() {
    this.submitted = true;
    if (this.f.bpass.value !== this.f.cbpass.value) {
      this.toastr.warning('Password & Confirm Password not match', 'Password');
      this.spinner.hide();
      return;
    }
    if (this.editCenterForm.invalid) {
      this.toastr.info('Enter required filed.', 'Required');
      this.spinner.hide();
      return;
    }
    this.spinner.show();
    const editbranch = {
      bname: this.f.bname.value,
      bcontact: this.f.bcontact.value,
      bemail: this.f.bemail.value,
      bpass: this.f.bpass.value,
      bcommission: this.f.bcommission.value,
      id: this.selectedCenterId,
      paymentmode: this.f.paymentmode.value,
      address: this.f.address.value,
      courseCatagory: this.selectedItems.map(item => item.id).join(',') //this.f.courseCatagory.value
    }
    this.centerService.updateCenter(editbranch).subscribe((res: any) => {
      this.toastr.success('Successfully', 'Updated');
      this.getBranchUpdate();
      this.spinner.hide();
    });
  }
  getBranchUpdate() {
    for (const key in this.branchList) {
      if (this.branchList[key].id === Number(this.selectedCenterId)) {
        this.branchList[key].bname = this.f.bname.value;
        this.branchList[key].bcontact = this.f.bcontact.value;
        this.branchList[key].bemail = this.f.bemail.value;
        this.branchList[key].bpass = this.f.bpass.value;
        this.branchList[key].bcommission = this.f.bcommission.value;
        this.branchList[key].paymentmode = this.f.paymentmode.value;
        this.branchList[key].address = this.f.address.value;
        //this.branchList[key].courseCatagory = this.f.courseCatagory.value;
        this.branchList[key].courseCatagory = this.selectedItems.map(item => item.id).join(',');
        break;
      }
    }
  }
  centerDelete() {
    this.confirmationDialogService.confirm('Delete', 'Do you want to delete Center ?')
      .then((confirmed) => {
        if (confirmed) {
          this.spinner.show();
          this.centerService.deleteCenter(this.selectedCenterId).subscribe((res: any) => {
            if (res) {
              this.toastr.success('Successfully', 'Delete');
              this.getAllCenter();
              this.spinner.hide();
            }
            else {
              this.spinner.hide();
            }
          });
        }
      })
      .catch(() => console.log('User dismissed the dialog '));
  }
  onItemSelect(item: any) {
    console.log('onItemSelect', item);
  }
  onSelectAll(items: any) {
    console.log('onSelectAll', items);
  }
  clearFrom() {
    this.editCenterForm.get('bname').setValue('');
    this.editCenterForm.get('bcontact').setValue('');
    this.editCenterForm.get('bemail').setValue('');
    this.editCenterForm.get('bpass').setValue('');
    this.editCenterForm.get('cbpass').setValue('');
    this.editCenterForm.get('bcommission').setValue('');
    this.editCenterForm.get('paymentmode').setValue('');
    this.editCenterForm.get('address').setValue('');
    this.editCenterForm.get('code').setValue('');
    this.selectedItems = [];
    this.catagoryList = [];
    this.editCenterForm.get('mastercode').setValue('');
    this.selectedCenterId = 0;
    this.editCenterForm.get('code')?.disable();
    this.editCenterForm.get('mastercode')?.disable();
  }
}
