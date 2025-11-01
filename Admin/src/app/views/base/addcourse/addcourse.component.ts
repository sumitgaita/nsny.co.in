import { Component } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { DocsExampleComponent } from '@docs-components/public-api';
import { NgxSpinnerService } from "ngx-spinner";
import { CourseService } from '../../../services/course.service';
import { RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent, CardBodyComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, DropdownDividerDirective, FormSelectDirective } from '@coreui/angular';
import { ToastrService } from "ngx-toastr";

@Component({
  selector: 'add-course',
  templateUrl: './addcourse.component.html',
  styleUrls: ['./addcourse.component.scss'],
  standalone: true,
  imports: [RowComponent, ColComponent, TextColorDirective, CardComponent,
    CardHeaderComponent, CardBodyComponent, DocsExampleComponent,
    InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective,
    FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent,
    DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective,
    RouterLink, DropdownDividerDirective,
    FormSelectDirective, ReactiveFormsModule]
})
export class AddCourseComponent {
  submitted = false;
  errorMessage = '';
  addCourseForm: FormGroup | any;
  constructor(private formBuilder: FormBuilder, private spinner: NgxSpinnerService,
    private courseService: CourseService, private toastr: ToastrService) { }
  ngOnInit() {
    this.addCourseForm = this.formBuilder.group({
      cname: ['', Validators.required],
      cinspay_f: ['', Validators.required],
      cabb: ['', Validators.required],
      cr3: ['', Validators.required],
      cmodules: [''],
      cinspay_m: ['', Validators.required],
      cduration: [''],
      cinspay_xm: [0],
      cfullpay: [0],
      hqamount: [''],
      c1: [''],
      c2: ['']
    });
  }
  get f() { return this.addCourseForm?.controls; }

  onAddCourseSubmit() {
    this.submitted = true;
    this.spinner.show();
    const addcourse = {
      cname: this.f.cname.value,
      cinspay_f: this.f.cinspay_f.value,
      cabb: this.f.cabb.value,
      cr3: this.f.cr3.value,
      cmodules: this.f.cmodules.value,
      cinspay_m: this.f.cinspay_m.value,
      cduration: this.f.cduration.value,
      cinspay_xm: this.f.cinspay_xm.value,
      cfullpay: this.f.cfullpay.value,
      hqamount: this.f.hqamount.value,
      c1: this.f.c1.value,
      c2: this.f.c2.value
    }
    this.courseService.createCourse(addcourse).subscribe((res: any) => {
      if (res) {
        this.reset();
        this.toastr.success('Successfully', 'Inserted');
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });

  }
  private reset() {
    this.addCourseForm?.reset();
    this.addCourseForm?.get('cfullpay')?.setValue(0);
    this.addCourseForm?.get('cinspay_xm')?.setValue(0);
  }
}
