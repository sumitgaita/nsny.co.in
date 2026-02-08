import { Component } from '@angular/core';
import { ReactiveFormsModule, FormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common'
import { DocsExampleComponent } from '@docs-components/public-api';
import { RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent, CardBodyComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, DropdownDividerDirective, FormSelectDirective } from '@coreui/angular';
import { MasterCode } from '../../../model/MasterCode';
import { MasterCodeService } from '../../../services/mastercode.service';
import { ToastrService } from 'ngx-toastr';
//import { ConfirmedValidator } from './confirmed.validator'
import { ConfirmationDialogService } from '../confirmation-dialog/confirmation-dialog.service';
import { NgxSpinnerService } from "ngx-spinner";
@Component({
  selector: 'edit-mastercode',
  templateUrl: './editmastercode.component.html',
  styleUrls: ['./editmastercode.component.scss'],
  standalone: true,
  imports: [RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent,
    CardBodyComponent, DocsExampleComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective,
    FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent,
    DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, RouterLink,
    DropdownDividerDirective, FormSelectDirective, ReactiveFormsModule, FormsModule, CommonModule]
})
export class EditMasterCodeComponent {
  loading = false;
  submitted = false;
  editmastercodeForm: FormGroup | any;
  selectedmastercodeId: number = 0;
  masterCodeList: MasterCode[] = [];
  //paymentModeList: string[] = ['Wallet', 'General'];
  constructor(private masterCodeService: MasterCodeService,
    private confirmationDialogService: ConfirmationDialogService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.loading = true;
    this.editmastercodeForm = this.formBuilder.group({
      mastercode: ['', Validators.required],
      active: ['', Validators.required]
    });
    this.getAllMasterCode();
  }
  get f() { return this.editmastercodeForm.controls; }
  private getAllMasterCode() {
    this.spinner.show();
    this.masterCodeList = [];
    this.masterCodeService.getAllMasterCode().subscribe((res: any) => {
      if (res && res.length > 0) {
        this.masterCodeList = res;
        this.editmastercodeForm.get('mastercode').setValue(res[0].mastercode);
        this.editmastercodeForm.get('active').setValue(res[0].active === 'True' ? 1 : 0);
        this.selectedmastercodeId = res[0].id;
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }
  getMasterCodeDetails() {
    for (const key in this.masterCodeList) {
      if (this.masterCodeList[key].id === Number(this.selectedmastercodeId)) {
        this.editmastercodeForm.get('mastercode').setValue(this.masterCodeList[key].mastercode);
        this.editmastercodeForm.get('active').setValue(this.masterCodeList[key].active === 'True' ? 1 : 0);
        break;
      }
    }
  }
  onEditMasterCodeSubmit() {
    this.submitted = true;
    if (this.editmastercodeForm.invalid) {
      return;
    }
    this.spinner.show();
    const editcatagory = {
      id: this.selectedmastercodeId,
      mastercode: this.f.mastercode.value,
      active: this.f.active.value
    }
    this.masterCodeService.updateMasterCode(editcatagory).subscribe((res: any) => {
      this.toastr.success('Successfully', 'Updated');
      this.getCatagoryUpdate();
      this.spinner.hide();
    });
  }
  getCatagoryUpdate() {
    for (const key in this.masterCodeList) {
      if (this.masterCodeList[key].id === Number(this.selectedmastercodeId)) {
        this.masterCodeList[key].mastercode = this.f.mastercode.value;
        this.masterCodeList[key].active = this.f.active.value === '0' ? 'False' : 'True';

        break;
      }
    }
  }
  masterCodeDelete() {
    this.confirmationDialogService.confirm('Delete', 'Do you want to delete master Code ?')
      .then((confirmed) => {
        if (confirmed) {
          this.spinner.show();
          this.masterCodeService.deleteMasterCode(this.selectedmastercodeId).subscribe((res: any) => {
            if (res) {
              this.toastr.success('Successfully', 'Delete');
              this.getAllMasterCode();
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
