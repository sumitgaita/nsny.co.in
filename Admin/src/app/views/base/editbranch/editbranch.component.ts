import { Component } from '@angular/core';
import { ReactiveFormsModule, FormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common'
import { DocsExampleComponent } from '@docs-components/public-api';
import { RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent, CardBodyComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, DropdownDividerDirective, FormSelectDirective } from '@coreui/angular';
import { Branch } from '../../../model/Branch';
import { BranchService } from '../../../services/branch.service';
import { ToastrService } from 'ngx-toastr';
import { ConfirmedValidator } from './confirmed.validator'
import { ConfirmationDialogService } from '../confirmation-dialog/confirmation-dialog.service';
import { NgxSpinnerService } from "ngx-spinner";
@Component({
  selector: 'edit-branch',
  templateUrl: './editbranch.component.html',
  styleUrls: ['./editbranch.component.scss'],
  standalone: true,
  imports: [RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent,
    CardBodyComponent, DocsExampleComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective,
    FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent,
    DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, RouterLink,
    DropdownDividerDirective, FormSelectDirective, ReactiveFormsModule, FormsModule, CommonModule]
})
export class EditBranchComponent {
  loading = false;
  submitted = false;
  editBranchForm: FormGroup | any;
  selectedBranchId: number = 0;
  branchList: Branch[] = [];
  paymentModeList: string[] = ['Wallet', 'General'];
  constructor(private branchService: BranchService,
    private confirmationDialogService: ConfirmationDialogService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.loading = true;
    this.editBranchForm = this.formBuilder.group({
      bname: ['', Validators.required],
      bcontact: ['', Validators.required],
      bemail: ['', Validators.required],
      bpass: [''],
      paymentmode: [''],
      cbpass: ['', Validators.required],
      bcommission: ['', Validators.required]
    }, {
      validator: ConfirmedValidator('bpass', 'cbpass')
    });
    this.getAllBranch();
  }
  get f() { return this.editBranchForm.controls; }
  private getAllBranch() {
    this.spinner.show();
    this.branchList = [];
    this.branchService.getAllBranch().subscribe((res: any) => {
      if (res && res.length > 0) {
        this.branchList = res;
        this.editBranchForm.get('bname').setValue(res[0].bname);
        this.editBranchForm.get('bcontact').setValue(res[0].bcontact);
        this.editBranchForm.get('bemail').setValue(res[0].bemail);
        this.editBranchForm.get('bpass').setValue(res[0].bpass);
        this.editBranchForm.get('cbpass').setValue(res[0].bpass);
        this.editBranchForm.get('bcommission').setValue(res[0].bcommission);
        this.editBranchForm.get('paymentmode').setValue(res[0].paymentmode);
        this.selectedBranchId = res[0].id;
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }
  getBranchDetails() {
    for (const key in this.branchList) {
      if (this.branchList[key].id === Number(this.selectedBranchId)) {
        this.editBranchForm.get('bname').setValue(this.branchList[key].bname);
        this.editBranchForm.get('bcontact').setValue(this.branchList[key].bcontact);
        this.editBranchForm.get('bemail').setValue(this.branchList[key].bemail);
        this.editBranchForm.get('bpass').setValue(this.branchList[key].bpass);
        this.editBranchForm.get('cbpass').setValue(this.branchList[key].bpass);
        this.editBranchForm.get('bcommission').setValue(this.branchList[key].bcommission);
        this.editBranchForm.get('paymentmode').setValue(this.branchList[key].paymentmode);
        break;
      }
    }
  }
  onEditBranchSubmit() {
    this.submitted = true;
    if (this.f.bpass.value !== this.f.cbpass.value) {
      this.toastr.warning('Password & Confirm Password not match', 'Password');
      return;
    }
    if (this.editBranchForm.invalid) {
      return;
    }
    this.spinner.show();
    const editbranch = {
      bname: this.f.bname.value,
      bcontact: this.f.bcontact.value,
      bemail: this.f.bemail.value,
      bpass: this.f.bpass.value,
      bcommission: this.f.bcommission.value,
      id: this.selectedBranchId,
      paymentmode: this.f.paymentmode.value
    }
    this.branchService.updateBranch(editbranch).subscribe((res: any) => {
      this.toastr.success('Successfully', 'Updated');
      this.getBranchUpdate();
      this.spinner.hide();
    });
  }
  getBranchUpdate() {
    for (const key in this.branchList) {
      if (this.branchList[key].id === Number(this.selectedBranchId)) {
        this.branchList[key].bname = this.f.bname.value;
        this.branchList[key].bcontact = this.f.bcontact.value;
        this.branchList[key].bemail = this.f.bemail.value;
        this.branchList[key].bpass = this.f.bpass.value;
        this.branchList[key].bcommission = this.f.bcommission.value;
        this.branchList[key].paymentmode = this.f.paymentmode.value;
        break;
      }
    }
  }
  branchDelete() {
    this.confirmationDialogService.confirm('Delete', 'Do you want to delete branch ?')
      .then((confirmed) => {
        if (confirmed) {
          this.spinner.show();
          this.branchService.deleteBranch(this.selectedBranchId).subscribe((res: any) => {
            if (res) {
              this.toastr.success('Successfully', 'Delete');
              this.getAllBranch();
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

}
