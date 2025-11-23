import { Component } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common'
import { DocsExampleComponent } from '@docs-components/public-api';
import { PermissionService } from '../../../services/permission.service';
import { RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent, CardBodyComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, DropdownDividerDirective, FormSelectDirective } from '@coreui/angular';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'add-permission',
  templateUrl: './addpermission.component.html',
  styleUrls: ['./addpermission.component.scss'],
  standalone: true,
  imports: [RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent,
    CardBodyComponent, DocsExampleComponent, InputGroupComponent, InputGroupTextDirective,
    FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective,
    ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective,
    DropdownItemDirective, RouterLink, DropdownDividerDirective, FormSelectDirective,
    ReactiveFormsModule, CommonModule]
})
export class addpermissionComponent {
  submitted = false;
  addPermissionForm: FormGroup | any;
  constructor(private permissionService: PermissionService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.addPermissionForm = this.formBuilder.group({
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
  }
  get f() { return this.addPermissionForm.controls; }
  

  onAddPermissionSubmit() {
    this.submitted = true;
   
    if (this.addPermissionForm.invalid) {
      return;
    }
    this.spinner.show();
    const addpermission = {
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
      active: this.f.active.value
    }
    this.permissionService.createPermission(addpermission).subscribe((res: any) => {
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
    this.addPermissionForm.reset();
  }

}
