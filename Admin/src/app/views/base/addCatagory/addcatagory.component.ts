import { Component } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common'
import { DocsExampleComponent } from '@docs-components/public-api';
import { CatagoryService } from '../../../services/catagory.service';
import { RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent, CardBodyComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, DropdownDividerDirective, FormSelectDirective } from '@coreui/angular';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'add-catagory',
  templateUrl: './addcatagory.component.html',
  styleUrls: ['./addcatagory.component.scss'],
  standalone: true,
  imports: [RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent,
    CardBodyComponent, DocsExampleComponent, InputGroupComponent, InputGroupTextDirective,
    FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective,
    ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective,
    DropdownItemDirective, RouterLink, DropdownDividerDirective, FormSelectDirective,
    ReactiveFormsModule, CommonModule]
})
export class AddCatagoryComponent {
  submitted = false;
  addCatagoryForm: FormGroup | any;
  constructor(private catagoryService: CatagoryService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.addCatagoryForm = this.formBuilder.group({
      name: ['', Validators.required],
      active: ['', Validators.required]
    });
  }
  get f() { return this.addCatagoryForm.controls; }
  

  onAddCatagorySubmit() {
    this.submitted = true;
   
    if (this.addCatagoryForm.invalid) {
      return;
    }
    this.spinner.show();
    const addbranch = {
      name: this.f.name.value,
      active: this.f.active.value
    }
    this.catagoryService.createCatagory(addbranch).subscribe((res: any) => {
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
    this.addCatagoryForm.reset();
  }

}
