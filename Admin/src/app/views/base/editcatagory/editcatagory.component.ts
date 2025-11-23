import { Component } from '@angular/core';
import { ReactiveFormsModule, FormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common'
import { DocsExampleComponent } from '@docs-components/public-api';
import { RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent, CardBodyComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, DropdownDividerDirective, FormSelectDirective } from '@coreui/angular';
import { Catagory } from '../../../model/Catagory';
import { CatagoryService } from '../../../services/catagory.service';
import { ToastrService } from 'ngx-toastr';
//import { ConfirmedValidator } from './confirmed.validator'
import { ConfirmationDialogService } from '../confirmation-dialog/confirmation-dialog.service';
import { NgxSpinnerService } from "ngx-spinner";
@Component({
  selector: 'edit-catagory',
  templateUrl: './editcatagory.component.html',
  styleUrls: ['./editcatagory.component.scss'],
  standalone: true,
  imports: [RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent,
    CardBodyComponent, DocsExampleComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective,
    FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent,
    DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, RouterLink,
    DropdownDividerDirective, FormSelectDirective, ReactiveFormsModule, FormsModule, CommonModule]
})
export class EditCatagoryComponent {
  loading = false;
  submitted = false;
  editCatagoryForm: FormGroup | any;
  selectedCaragoryId: number = 0;
  catagoryList: Catagory[] = [];
  paymentModeList: string[] = ['Wallet', 'General'];
  constructor(private catagoryService: CatagoryService,
    private confirmationDialogService: ConfirmationDialogService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.loading = true;
    this.editCatagoryForm = this.formBuilder.group({
      name: ['', Validators.required],
      active: ['', Validators.required]
    });
    this.getAllCatagory();
  }
  get f() { return this.editCatagoryForm.controls; }
  private getAllCatagory() {
    this.spinner.show();
    this.catagoryList = [];
    this.catagoryService.getAllCatagory().subscribe((res: any) => {
      if (res && res.length > 0) {
        this.catagoryList = res;
        this.editCatagoryForm.get('name').setValue(res[0].name);
        this.editCatagoryForm.get('active').setValue(res[0].active === 'True' ? 1 : 0);
        this.selectedCaragoryId = res[0].id;
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }
  getCatagoryDetails() {
    for (const key in this.catagoryList) {
      if (this.catagoryList[key].id === Number(this.selectedCaragoryId)) {
        this.editCatagoryForm.get('name').setValue(this.catagoryList[key].name);
        this.editCatagoryForm.get('active').setValue(this.catagoryList[key].active === 'True' ? 1 : 0);
        break;
      }
    }
  }
  onEditCatagorySubmit() {
    this.submitted = true;
    if (this.editCatagoryForm.invalid) {
      return;
    }
    this.spinner.show();
    const editcatagory = {
      id: this.selectedCaragoryId,
      name: this.f.name.value,
      active: this.f.active.value

    }
    this.catagoryService.updateCatagory(editcatagory).subscribe((res: any) => {
      this.toastr.success('Successfully', 'Updated');
      this.getCatagoryUpdate();
      this.spinner.hide();
    });
  }
  getCatagoryUpdate() {
    for (const key in this.catagoryList) {
      if (this.catagoryList[key].id === Number(this.selectedCaragoryId)) {
        this.catagoryList[key].name = this.f.name.value;
        this.catagoryList[key].active = this.f.active.value === '0' ? 'False' : 'True';

        break;
      }
    }
  }
  branchDelete() {
    this.confirmationDialogService.confirm('Delete', 'Do you want to delete branch ?')
      .then((confirmed) => {
        if (confirmed) {
          this.spinner.show();
          this.catagoryService.deleteCatagory(this.selectedCaragoryId).subscribe((res: any) => {
            if (res) {
              this.toastr.success('Successfully', 'Delete');
              this.getAllCatagory();
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
