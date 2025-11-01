import { Component } from '@angular/core';
import { ReactiveFormsModule, FormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { NgbAlertModule, NgbDatepickerModule, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule, DatePipe } from '@angular/common'
import { DocsExampleComponent } from '@docs-components/public-api';
import { RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent, CardBodyComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, DropdownDividerDirective, FormSelectDirective } from '@coreui/angular';
import { ToastrService } from "ngx-toastr";
import { StudentService } from '../../../services/student.service';
import { environment } from '../../../environments/environment';
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'edit-student',
  templateUrl: './editstudent.component.html',
  styleUrls: ['./editstudent.component.scss'],
  standalone: true,
  imports: [RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent,
    CardBodyComponent, DocsExampleComponent, InputGroupComponent, InputGroupTextDirective,
    FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective,
    DropdownComponent, DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, RouterLink,
    DropdownDividerDirective, FormSelectDirective, ReactiveFormsModule, FormsModule, CommonModule,
    NgbDatepickerModule, NgbAlertModule]
})
export class EditStudentComponent {
  loading = false;
  submitted = false;
  selectedStudentId!: number;
  nSSYcode: string = '';
  editStudentForm: FormGroup | any;
  sexList: string[] = ['Male', 'Female', 'Transgender'];
  religiousList: string[] = ['Hinduism', 'Islam', 'Christianity', 'Sikhism', 'Buddhism', 'Jainism'];
  castRList: string[] = ['SC', 'ST', 'OBC', 'Minority', 'General'];
  courseStatusList: string[] = ['Course Complete', 'Couse Ongoing'];
  previewUrl: any = null;
  imageURL!: string;

  constructor(private formBuilder: FormBuilder,
    private studentService: StudentService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private datePipe: DatePipe) { }

  ngOnInit() {
    this.loading = true;
    this.editStudentForm = this.formBuilder.group({
      stu_name: ['', Validators.required],
      paddress: ['', Validators.required],
      peraddress: [''],
      nationality: [''],
      mobile: ['', Validators.required],
      guardian: ['', Validators.required],
      emaiid: [''],
      religion: ['Hinduism'],
      casts: ['SC'],
      dob: [''],
      sex: ['Male'],
      exam: [''],
      duration: [''],
      university: [''],
      regno: [''],
      percentage: [''],
      class_per: [''],
      fileup_ins: [''],
      center_code: [''],
      center_name: [''],
      nssY_code: [''],
      r1: [''],
      r2: [''],
      r3: [''],
      r4: [''],
      r5: [''],
      act: [''],
      name: ['']
    });
  }
  get f() { return this.editStudentForm.controls; }

  public getStudentDetails() {
    this.spinner.show();
    this.selectedStudentId = 0;
    this.studentService.getStudent(this.nSSYcode).subscribe((res: any) => {
      if (res && res.length > 0) {
        this.editStudentForm.patchValue(res[0])
        this.selectedStudentId = res[0].id;
        this.imageURL = `${environment.apiUrl}/Files/` + '' + res[0].fileup_ins; //res[0].fileup_ins;
        this.editStudentForm.get('name').setValue(res[0].fileup_ins);
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }

    });
  }

  onEditStudentSubmit() {
    this.submitted = true;
    this.spinner.show();
    if (this.editStudentForm.invalid) {
      this.spinner.hide();
      return;
    }
    const editstudent = {
      id: this.selectedStudentId,
      stu_name: this.f.stu_name.value,
      paddress: this.f.paddress.value,
      peraddress: this.f.peraddress.value,
      nationality: this.f.nationality.value,
      mobile: this.f.mobile.value,
      guardian: this.f.guardian.value,
      emaiid: this.f.emaiid.value,
      religion: this.f.religion.value,
      dob: this.f.dob.value,//this.datePipe.transform(new Date(this.f.dob.value.month - 1, this.f.dob.value.day, this.f.dob.value.year), 'MM-dd-yyyy'),//this.f.dob.value,
      casts: this.f.casts.value,
      sex: this.f.sex.value,
      exam: this.f.exam.value,
      university: this.f.university.value,
      percentage: this.f.percentage.value,
      fileup_ins: this.f.fileup_ins.value,
      center_code: this.f.center_code.value,
      center_name: this.f.center_name.value,
      nssY_code: this.f.nssY_code.value,
      r1: this.f.r1.value,
      r2: this.f.r2.value,
      r3: this.f.r3.value,
      r4: this.f.r4.value
    }
    this.studentService.updateStudent(editstudent).subscribe((res: any) => {
      this.toastr.success('Successfully', 'Updated');
      this.spinner.hide();
    });
  }

}
