import { Component } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators, FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common'
import { DocsExampleComponent } from '@docs-components/public-api';
import { CenterService } from '../../../services/center.service';
import { CatagoryService } from '../../../services/catagory.service';
import { ConfirmedValidator } from './confirmed.validator'
import { RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent, CardBodyComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, DropdownDividerDirective, FormSelectDirective } from '@coreui/angular';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from "ngx-spinner";
import { environment } from '../../../environments/environment';
import { Catagory } from '../../../model/Catagory';
import { AuthenticationService } from '../../../services/authentication.service';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { IDropdownSettings } from 'ng-multiselect-dropdown';

@Component({
  selector: 'add-center',
  templateUrl: './addcenter.component.html',
  styleUrls: ['./addcenter.component.scss'],
  standalone: true,
  imports: [RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent,
    CardBodyComponent, DocsExampleComponent, InputGroupComponent, InputGroupTextDirective,
    FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective,
    ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective,
    DropdownItemDirective, RouterLink, DropdownDividerDirective, FormSelectDirective,
    ReactiveFormsModule, CommonModule, FormsModule, NgMultiSelectDropDownModule]
})
export class AddCenterComponent {
  submitted = false;
  addCenterForm: FormGroup | any;
  crrentCenterId: number = 0;
  catagoryList: Catagory[] = [];
  paymentModeList: string[] = ['Wallet', 'General'];
  currentUser: any;
  selectedItems: any[] = [];
  dropdownSettings: IDropdownSettings = {};
  constructor(private centerService: CenterService,
    private catagoryService: CatagoryService,
    private spinner: NgxSpinnerService,
    private authenticationService: AuthenticationService,
    private toastr: ToastrService,
    private formBuilder: FormBuilder) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  ngOnInit() {
    this.addCenterForm = this.formBuilder.group({
      bname: ['', Validators.required],
      branchId: [this.currentUser.id],
      bcontact: ['', Validators.required],
      bemail: ['', Validators.required],
      address: ['', Validators.required],
      bpass: [''],
      paymentmode: ['Wallet', Validators.required],
      cbpass: ['', Validators.required],
      bcommission: ['', Validators.required],
      code: ['', Validators.required],
      mastercode: [this.currentUser.mastercode]
     
    }, {
      validator: ConfirmedValidator('bpass', 'cbpass')
    });
    this.addCenterForm.get('code')?.disable();
    this.addCenterForm.get('mastercode')?.disable();
    this.getCurrentCenterId();
    this.getAllCatagory();
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
  get f() { return this.addCenterForm.controls; }
  getCurrentCenterId() {
    this.spinner.show();
    this.centerService.currntCenterId().subscribe((res: any) => {
      if (res) {
        this.crrentCenterId = (res + 1);
        this.Idnumber();
        this.spinner.hide();
      }
      else {
        this.crrentCenterId = 0;
        this.spinner.hide();
      }
    });
  }

  private getAllCatagory() {
    this.spinner.show();
    this.catagoryList = [];
    this.catagoryService.getAllCatagory().subscribe((res: any) => {
      if (res && res.length > 0) {
        const idSet = new Set(
          this.currentUser.coursecatagory.split(",").map(Number).map((obj: any) => obj)
        );
        this.catagoryList = res.filter((item: any) =>
          idSet.has(item.id)
        );
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }

  onAddCenterSubmit() {
    this.submitted = true;
    if (this.f.bpass.value !== this.f.cbpass.value) {
      this.toastr.warning('Password & Confirm Password not match', 'Password');
      this.spinner.hide();
      return;
    }
    if (this.addCenterForm.invalid || this.selectedItems.length === 0) {
      this.toastr.info('Enter required filed.', 'Required');
      this.spinner.hide();
      return;
    }
    this.spinner.show();
    const addcenetr = {
      bname: this.f.bname.value,
      bcontact: this.f.bcontact.value,
      bemail: this.f.bemail.value,
      bpass: this.f.bpass.value,
      bcommission: this.f.bcommission.value,
      paymentmode: this.f.paymentmode.value,
      code: this.f.code.value,
      address: this.f.address.value,
      courseCatagory: this.selectedItems.map(item => item.id).join(','), //this.f.courseCatagory.value,
      branchId: this.currentUser.id,
      mastercode: this.currentUser.mastercode
    }
    this.centerService.createCenter(addcenetr).subscribe((res: any) => {
      if (res) {
        this.reset();
        this.toastr.success('Successfully', 'Inserted');
        this.addCenterForm.get('mastercode').setValue(this.currentUser.mastercode);
        this.getCurrentCenterId();
        this.addCenterForm.get('paymentmode').setValue('Wallet');
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }
  public Idnumber() {
    let st1 = this.crrentCenterId;
    let count = 0;
    let likestr = `${environment.centercode}` + ("000" + st1).slice(-3);
    this.addCenterForm.get('code').setValue(likestr);

  }
  private reset() {
    this.addCenterForm.reset();
    this.selectedItems = [];
  }
  onItemSelect(item: any) {
    console.log('onItemSelect', item);
  }
  onSelectAll(items: any) {
    console.log('onSelectAll', items);
  }
}
