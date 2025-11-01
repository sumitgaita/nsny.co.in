import { Component } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common'
import { DocsExampleComponent } from '@docs-components/public-api';
import { BranchService } from '../../../services/branch.service';
import { ConfirmedValidator } from './confirmed.validator'
import { RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent, CardBodyComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, DropdownDividerDirective, FormSelectDirective } from '@coreui/angular';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'add-branch',
  templateUrl: './addbranch.component.html',
  styleUrls: ['./addbranch.component.scss'],
  standalone: true,
  imports: [RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent,
    CardBodyComponent, DocsExampleComponent, InputGroupComponent, InputGroupTextDirective,
    FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective,
    ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective,
    DropdownItemDirective, RouterLink, DropdownDividerDirective, FormSelectDirective,
    ReactiveFormsModule, CommonModule]
})
export class AddBranchComponent {
  submitted = false;
  addBranchForm: FormGroup | any;
  crrentBranchId: number = 0;
  paymentModeList: string[] = ['Wallet', 'General'];
  constructor(private branchService: BranchService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.addBranchForm = this.formBuilder.group({
      bname: ['', Validators.required],
      bcontact: ['', Validators.required],
      bemail: ['', Validators.required],
      bpass: [''],
      paymentmode: ['Wallet', Validators.required],
      cbpass: ['', Validators.required],
      bcommission: ['', Validators.required]
    }, {
      validator: ConfirmedValidator('bpass', 'cbpass')
    });
    this.getCurrentBranchId();
  }
  get f() { return this.addBranchForm.controls; }
  getCurrentBranchId() {
    this.spinner.show();
    this.branchService.currntBranchId().subscribe((res: any) => {
      if (res) {
        this.crrentBranchId = (res + 1);
        this.spinner.hide();
      }
      else {
        this.crrentBranchId = 0;
        this.spinner.hide();
      }
    });
  }

  onAddBranchSubmit() {
    this.submitted = true;
    if (this.f.bpass.value !== this.f.cbpass.value) {
      this.toastr.warning('Password & Confirm Password not match', 'Password');
      return;
    }
    if (this.addBranchForm.invalid) {
      return;
    }
    this.spinner.show();
    const addbranch = {
      bname: this.f.bname.value,
      bcontact: this.f.bcontact.value,
      bemail: this.f.bemail.value,
      bpass: this.f.bpass.value,
      bcommission: this.f.bcommission.value,
      paymentmode: this.f.paymentmode.value
    }
    this.branchService.createBranch(addbranch).subscribe((res: any) => {
      if (res) {
        this.reset();
        this.toastr.success('Successfully', 'Inserted');
        this.getCurrentBranchId();
        this.addBranchForm.get('paymentmode').setValue('Wallet');
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }
  private reset() {
    this.addBranchForm.reset();
  }

}
