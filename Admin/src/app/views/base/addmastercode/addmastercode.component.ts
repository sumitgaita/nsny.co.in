import { Component } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common'
import { DocsExampleComponent } from '@docs-components/public-api';
import { MasterCodeService } from '../../../services/mastercode.service';
import { RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent, CardBodyComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, DropdownDividerDirective, FormSelectDirective } from '@coreui/angular';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'add-mastercode',
  templateUrl: './addmastercode.component.html',
  styleUrls: ['./addmastercode.component.scss'],
  standalone: true,
  imports: [RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent,
    CardBodyComponent, DocsExampleComponent, InputGroupComponent, InputGroupTextDirective,
    FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective,
    ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective,
    DropdownItemDirective, RouterLink, DropdownDividerDirective, FormSelectDirective,
    ReactiveFormsModule, CommonModule]
})
export class AddMastercodeComponent {
  submitted = false;
  addmastercodeForm: FormGroup | any;
  constructor(private masterCodeService: MasterCodeService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.addmastercodeForm = this.formBuilder.group({
      mastercode: ['', Validators.required],
      active: ['', Validators.required]
    });
  }
  get f() { return this.addmastercodeForm.controls; }
  

  onAddMasterCodeSubmit() {
    this.submitted = true;
   
    if (this.addmastercodeForm.invalid) {
      return;
    }
    this.spinner.show();
    const addmastercode = {
      mastercode: this.f.mastercode.value,
      active: this.f.active.value
    }
    this.masterCodeService.createMasterCode(addmastercode).subscribe((res: any) => {
      if (res) {
        this.reset();
        this.toastr.success('Successfully', 'Inserted');
        this.spinner.hide();
      }
      else {
        this.toastr.success('Successfully', 'Inserted');
        this.spinner.hide();
      }
    });
  }
  private reset() {
    this.addmastercodeForm.reset();
  }

}
