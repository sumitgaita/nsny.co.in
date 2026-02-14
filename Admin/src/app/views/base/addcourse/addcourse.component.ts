import { Component } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators, FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { DocsExampleComponent } from '@docs-components/public-api';
import { NgxSpinnerService } from "ngx-spinner";
import { CourseService } from '../../../services/course.service';
import { RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent, CardBodyComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, DropdownDividerDirective, FormSelectDirective } from '@coreui/angular';
import { ToastrService } from "ngx-toastr";
import { CatagoryService } from '../../../services/catagory.service';
import { Catagory } from '../../../model/Catagory';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { IDropdownSettings } from 'ng-multiselect-dropdown';

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
    FormSelectDirective, ReactiveFormsModule, NgMultiSelectDropDownModule, FormsModule]
})
export class AddCourseComponent {
  submitted = false;
  errorMessage = '';
  addCourseForm: FormGroup | any;
  catagoryList: Catagory[] = [];
  selectedItems: any[] = [];
  dropdownSettings: IDropdownSettings = {};
  constructor(private formBuilder: FormBuilder, private spinner: NgxSpinnerService,
    private courseService: CourseService, private toastr: ToastrService, private catagoryService: CatagoryService) { }
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
  private getAllCatagory() {
    this.spinner.show();
    this.catagoryList = [];
    this.catagoryService.getAllCatagory().subscribe((res: any) => {
      if (res && res.length > 0) {
        this.catagoryList = res;
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }
  get f() { return this.addCourseForm?.controls; }

  onAddCourseSubmit() {
    this.submitted = true;
    this.spinner.show();
    if (this.addCourseForm.invalid || this.selectedItems.length === 0) {
      this.toastr.info('Enter required filed.', 'Required');
      this.spinner.hide();
      return;
    }
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
      c2: this.f.c2.value,
      courseCatagory: this.selectedItems.map(item => item.id).join(',')
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
    this.selectedItems = [];
  }
  onItemSelect(item: any) {
    console.log('onItemSelect', item);
  }
  onSelectAll(items: any) {
    console.log('onSelectAll', items);
  }
}
