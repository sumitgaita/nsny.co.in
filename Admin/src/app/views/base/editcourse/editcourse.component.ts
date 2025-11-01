import { Component } from '@angular/core';
import { CommonModule } from '@angular/common'
import { ReactiveFormsModule, FormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { DocsExampleComponent } from '@docs-components/public-api';
import { Course } from '../../../model/Course';
import { CourseService } from '../../../services/course.service';
import { RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent, CardBodyComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, DropdownDividerDirective, FormSelectDirective } from '@coreui/angular';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationDialogService } from '../confirmation-dialog/confirmation-dialog.service';
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'edit-course',
  templateUrl: './editcourse.component.html',
  styleUrls: ['./editcourse.component.scss'],
  standalone: true,
  imports: [RowComponent, ColComponent, TextColorDirective, CardComponent,
    CardHeaderComponent, CardBodyComponent, DocsExampleComponent, InputGroupComponent,
    InputGroupTextDirective, FormControlDirective, FormLabelDirective, FormCheckInputDirective,
    ButtonDirective, ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective,
    DropdownItemDirective, RouterLink, DropdownDividerDirective, FormSelectDirective, ReactiveFormsModule,
    FormsModule, CommonModule]
})
export class EditcourseComponent {
  selectedCourseId: number = 0;
  courseList: Course[] = [];
  editCourseForm: FormGroup | any;
  courseId: number | undefined;
  submitted = false;
  constructor(private formBuilder: FormBuilder, private courseService: CourseService, private spinner: NgxSpinnerService,
    private toastr: ToastrService, private confirmationDialogService: ConfirmationDialogService) { }
  ngOnInit() {
    this.editCourseForm = this.formBuilder.group({
      cname: ['', Validators.required],
      cinspay_f: ['', Validators.required],
      cabb: ['', Validators.required],
      cr3: ['', Validators.required],
      cmodules: [''],
      cinspay_m: ['', Validators.required],
      cduration: [''],
      cinspay_xm: [''],
      cfullpay: [''],
      hqamount: [''],
      c1: [''],
      c2: ['']
    });
    this.getAllCourse();
  }
  get f() { return this.editCourseForm.controls; }
  private getAllCourse() {
    this.spinner.show();
    this.courseList = [];
    this.courseService.getAllCourse().subscribe((res: any) => {
      if (res && res.length > 0) {
        this.courseList = res;
        this.editCourseForm.get('cname').setValue(res[0].cname);
        this.editCourseForm.get('cinspay_f').setValue(res[0].cinspay_f);
        this.editCourseForm.get('cabb').setValue(res[0].cabb);
        this.editCourseForm.get('cr3').setValue(res[0].cr3);
        this.editCourseForm.get('cmodules').setValue(res[0].cmodules);
        this.editCourseForm.get('cinspay_m').setValue(res[0].cinspay_m);
        this.editCourseForm.get('cduration').setValue(res[0].cduration);
        this.editCourseForm.get('cinspay_xm').setValue(res[0].cinspay_xm);
        this.editCourseForm.get('cfullpay').setValue(res[0].cfullpay);
        this.editCourseForm.get('hqamount').setValue(res[0].hqamount);
        this.editCourseForm.get('c1').setValue(res[0].c1);
        this.editCourseForm.get('c2').setValue(res[0].c2);
        this.selectedCourseId = res[0].id;
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }
  getCourseDetails() {
    for (const key in this.courseList) {
      if (this.courseList[key].id === Number(this.selectedCourseId)) {
        this.editCourseForm.get('cname').setValue(this.courseList[key].cname);
        this.editCourseForm.get('cinspay_f').setValue(this.courseList[key].cinspay_f);
        this.editCourseForm.get('cabb').setValue(this.courseList[key].cabb);
        this.editCourseForm.get('cr3').setValue(this.courseList[key].cr3);
        this.editCourseForm.get('cmodules').setValue(this.courseList[key].cmodules);
        this.editCourseForm.get('cinspay_m').setValue(this.courseList[key].cinspay_m);
        this.editCourseForm.get('cduration').setValue(this.courseList[key].cduration);
        this.editCourseForm.get('cinspay_xm').setValue(this.courseList[key].cinspay_xm);
        this.editCourseForm.get('cfullpay').setValue(this.courseList[key].cfullpay);
        this.editCourseForm.get('hqamount').setValue(this.courseList[key].hqamount);
        this.editCourseForm.get('c1').setValue(this.courseList[key].c1);
        this.editCourseForm.get('c2').setValue(this.courseList[key].c2);
        break;
      }
    }
  }
  onEditCourseSubmit() {
    this.submitted = true;
    this.spinner.show();
    if (this.editCourseForm.invalid) {
      this.spinner.hide();
      return;
    }

    const editcourse = {
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
      c2: this.f.c2.value,
      id: this.selectedCourseId
    }
    this.courseService.updateCourse(editcourse).subscribe((res: any) => {
      this.toastr.success('Successfully', 'Updated');
      this.updateCourseList();
      this.spinner.hide();
    });
  }
  private updateCourseList() {
    for (const key in this.courseList) {
      if (this.courseList[key].id === Number(this.selectedCourseId)) {
        this.courseList[key].cname = this.f.cname.value;
        this.courseList[key].cinspay_f = this.f.cinspay_f.value;
        this.courseList[key].cabb = this.f.cabb.value;
        this.courseList[key].cr3 = this.f.cr3.value;
        this.courseList[key].cmodules = this.f.cmodules.value;
        this.courseList[key].cinspay_m = this.f.cinspay_m.value;
        this.courseList[key].cduration = this.f.cduration.value;
        this.courseList[key].cinspay_xm = this.f.cinspay_xm.value;
        this.courseList[key].cfullpay = this.f.cfullpay.value;
        this.courseList[key].hqamount = this.f.hqamount.value;
        this.courseList[key].c1 = this.f.c1.value;
        this.courseList[key].c2 = this.f.c2.value;
        break;
      }
    }
  }
  courseDelete() {
    this.confirmationDialogService.confirm('Delete', 'Do you want to delete course ?')
      .then((confirmed) => {
        if (confirmed) {
          this.spinner.show();
          this.courseService.deleteCourse(this.selectedCourseId).subscribe((res: any) => {
            if (res) {
              this.toastr.success('Successfully', 'Delete');
              this.getAllCourse();
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
