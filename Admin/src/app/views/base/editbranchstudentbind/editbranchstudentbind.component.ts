import { Component } from '@angular/core';
import { ReactiveFormsModule, FormsModule, FormBuilder, FormGroup } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { CommonModule, DatePipe } from '@angular/common'
import { DocsExampleComponent } from '@docs-components/public-api';
import { RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent, CardBodyComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, DropdownDividerDirective, FormSelectDirective } from '@coreui/angular';
import { ToastrService } from "ngx-toastr";
import { CourseService } from '../../../services/course.service';
import { CatagoryService } from '../../../services/catagory.service';
import { CommissionPayService } from '../../../services/commissionpay.service';
import { BranchstudentbindService } from '../../../services/branchstudentbind.service';
import { NgxSpinnerService } from "ngx-spinner";
import { Catagory } from '../../../model/Catagory';

@Component({
  selector: 'edit-branchs-tudent-bind',
  templateUrl: './editbranchstudentbind.component.html',
  styleUrls: ['./editbranchstudentbind.component.scss'],
  standalone: true,
  imports: [RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent,
    CardBodyComponent, DocsExampleComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective,
    FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent,
    DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, RouterLink,
    DropdownDividerDirective, FormSelectDirective, ReactiveFormsModule, CommonModule, FormsModule]
})
export class EditBranchStudentBindComponent {
  loading = false;
  submitted = false;
  currentUser: any;
  nSSYcode!: string;
  coursebindDetails: any = [];
  courseList: any = [];
  editCourseStudentForm: FormGroup | any;
  studentname!: string;
  catagoryList: Catagory[] = [];
  paymentModeList: string[] = ['Full Payment', 'Installment Payment'];
  constructor(private courseService: CourseService,
    private commissionPayService: CommissionPayService,
    private catagoryService: CatagoryService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private branchstudentbindService: BranchstudentbindService,
    // private authenticationService: AuthenticationService,   
    private formBuilder: FormBuilder) {
    //this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  ngOnInit() {
    this.loading = true;
    this.editCourseStudentForm = this.formBuilder.group({
      bid: [''],
      bname: [''],
      scstid: [''],
      scsjoin: [''],
      amount_crpay: [''],
      scamountremaing: [''],
      sccid: [''],
      sclastamountpay: [0],
      scctype: ['Full Payment'],
      sctotalInstallment: [''],
      scctotal: [''],
      scremainginstallment: [''],
      sccdiscount: [0],
      scpaymentclear: [''],
      cname: [''],
      changesccid: [''],
      changescname: [''],
      id: [''],
      paymentId: [''],
      binddateofpayment: [''],
      theory: [0.00],
      practical: [0.00],
      courseCatagory:[]
    });
    this.getAllCatagory();
    this.getActiveCourseList();

  }
  get f() { return this.editCourseStudentForm.controls; }
  private getAllCatagory() {
    this.spinner.show();
    this.catagoryList = [];
    this.catagoryService.getAllCatagory().subscribe((res: any) => {
      if (res && res.length > 0) {
        this.catagoryList = res;
        this.editCourseStudentForm.get('courseCatagory').setValue(res[0].id);
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }
  getStudentCourseBindDetails() {
    this.spinner.show();
    this.editCourseStudentForm.get('changesccid').setValue(0);
    this.branchstudentbindService.getCourseBindList(this.nSSYcode).subscribe((res: any) => {
      if (res) {
        this.coursebindDetails = res;
        this.studentname = res[0].stname;
        this.editCourseStudentForm.get('bid').setValue(res[0].bid);
        this.editCourseStudentForm.get('bname').setValue(res[0].bname);
        this.editCourseStudentForm.get('id').setValue(res[0].id);
        this.editCourseStudentForm.get('paymentId').setValue(res[0].paymentId);
        this.editCourseStudentForm.get('sccid').setValue(res[0].cid);
        this.editCourseStudentForm.get('cname').setValue(res[0].cname);
        this.editCourseStudentForm.get('scsjoin').setValue(res[0].sjoin);
        this.editCourseStudentForm.get('amount_crpay').setValue(res[0].amount_crpay);
        this.editCourseStudentForm.get('scamountremaing').setValue(res[0].amountremaing);
        this.editCourseStudentForm.get('sclastamountpay').setValue(res[0].lastamountpay);
        this.editCourseStudentForm.get('scctype').setValue(res[0].ctype);
        this.editCourseStudentForm.get('sctotalInstallment').setValue(res[0].totalInstallment);
        this.editCourseStudentForm.get('scremainginstallment').setValue(res[0].remainginstallment);
        this.editCourseStudentForm.get('sccdiscount').setValue(res[0].cdiscount);
        this.editCourseStudentForm.get('scpaymentclear').setValue(res[0].paymentclear);
        this.editCourseStudentForm.get('theory').setValue(res[0].theory);
        this.editCourseStudentForm.get('practical').setValue(res[0].practical);
        this.editCourseStudentForm.get('courseCatagory').setValue(res[0].courseCatagory);
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }

  private getActiveCourseList() {
    this.spinner.show();
    this.courseService.GetAllActiveCourse().subscribe((res: any) => {
      if (res) {
        this.courseList = res;
        this.editCourseStudentForm.get('changesccid').setValue(0);
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }

    });
  }
  getSelectedChangeCourse() {
    this.spinner.show();
    if (this.f.changesccid.value > 0) {
      this.courseService.GetByIdCourse(this.f.changesccid.value).subscribe((res: any) => {
        if (res && res.length > 0) {
          this.getPaymentStaus(res[0]);
          this.spinner.hide();
        }
        else {
          this.spinner.hide();
        }
      });
    }

  }
  getSelectedCourse() {
    for (const key in this.coursebindDetails) {
      if (this.coursebindDetails[key].cid === Number(this.f.sccid.value)) {
        this.editCourseStudentForm.get('bid').setValue(this.coursebindDetails[key].bid);
        this.editCourseStudentForm.get('bname').setValue(this.coursebindDetails[key].bname);
        this.editCourseStudentForm.get('id').setValue(this.coursebindDetails[key].id);
        this.editCourseStudentForm.get('paymentId').setValue(this.coursebindDetails[key].paymentId);
        this.editCourseStudentForm.get('cname').setValue(this.coursebindDetails[key].cname);
        this.editCourseStudentForm.get('scsjoin').setValue(this.coursebindDetails[key].sjoin);
        this.editCourseStudentForm.get('amount_crpay').setValue(this.coursebindDetails[key].amount_crpay);
        this.editCourseStudentForm.get('scamountremaing').setValue(this.coursebindDetails[key].amountremaing);
        this.editCourseStudentForm.get('sclastamountpay').setValue(this.coursebindDetails[key].lastamountpay);
        this.editCourseStudentForm.get('scctype').setValue(this.coursebindDetails[key].ctype);
        this.editCourseStudentForm.get('sctotalInstallment').setValue(this.coursebindDetails[key].totalInstallment);
        this.editCourseStudentForm.get('scremainginstallment').setValue(this.coursebindDetails[key].remainginstallment);
        this.editCourseStudentForm.get('sccdiscount').setValue(this.coursebindDetails[key].cdiscount);
        this.editCourseStudentForm.get('scpaymentclear').setValue(this.coursebindDetails[key].paymentclear);
        this.editCourseStudentForm.get('theory').setValue(this.coursebindDetails[key].theory);
        this.editCourseStudentForm.get('practical').setValue(this.coursebindDetails[key].practical);
        this.editCourseStudentForm.get('changesccid').setValue(0);
        break;
      }
    }

  }
  getSelectedPaymentMode() {
    this.spinner.show();
    this.courseService.GetByIdCourse(this.f.changesccid.value).subscribe((res: any) => {
      if (res && res.length > 0) {
        this.getPaymentStaus(res[0]);
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }

  amountRemaingCalculation() {
    let amount = 0;
    amount = (this.f.scctotal.value - this.f.sccdiscount.value);
    this.editCourseStudentForm.get('scamountremaing').setValue(amount);
  }
  private getPaymentStaus(res: any) {
    if (this.f.scctype.value === 'Full Payment') {
      this.editCourseStudentForm.get('scctotal').setValue(res.cfullpay);
      this.editCourseStudentForm.get('scamountremaing').setValue(res.cfullpay);
      this.editCourseStudentForm.get('sctotalInstallment').setValue(0);
      this.editCourseStudentForm.get('scremainginstallment').setValue(0);
    }
    else if (this.f.scctype.value === 'Installment Payment') {
      this.editCourseStudentForm.get('scctotal').setValue(res.cinspay_f);
      this.editCourseStudentForm.get('scamountremaing').setValue(res.cinspay_f);
      this.editCourseStudentForm.get('sctotalInstallment').setValue(res.cinspay_xm);
      this.editCourseStudentForm.get('scremainginstallment').setValue(res.cinspay_xm);
    }
    this.editCourseStudentForm.get('amount_crpay').setValue(res.hqamount);
    this.editCourseStudentForm.get('scpaymentclear').setValue('Payment Not Clear');
  }
  onEditCourseStudentSubmit() {
    this.submitted = true;
    this.spinner.show();
    if (this.editCourseStudentForm.invalid) {
      this.spinner.hide();
      return;
    }
    if (this.f.id.value == "") {
      return;
    }


    const addBranchStudentBind = {
      id: this.f.id.value,
      //scbid: this.currentUser.id,
      //scbname: this.currentUser.bname,
      //scstid: this.f.scstid.value,
      scsjoin: this.f.scsjoin.value,
      scamountremaing: this.f.scamountremaing.value,
      sccid: Number(this.f.changesccid.value) > 0 ? this.f.changesccid.value : this.f.sccid.value,
      sclastamountpay: this.f.sclastamountpay.value === '' ? 0 : this.f.sclastamountpay.value,
      scctype: this.f.scctype.value,
      sctotalInstallment: this.f.sctotalInstallment.value,
      scctotal: (this.f.scctotal.value === null || this.f.scctotal.value === '') ? 0 : this.f.scctotal.value,
      sccdiscount: this.f.sccdiscount.value === '' ? 0 : this.f.sccdiscount.value,
      scremainginstallment: this.f.scremainginstallment.value === '' ? 0 : this.f.scremainginstallment.value,
      scpaymentclear: this.f.scpaymentclear.value,
      scdateofpayment: this.f.scsjoin.value,
      theory: this.f.theory.value,
      practical: this.f.practical.value,
      courseCatagory: this.f.courseCatagory.value
    }
    this.branchstudentbindService.studentCourseBindUpdate(addBranchStudentBind).subscribe((res: any) => {
      this.toastr.success('Successfully', 'Updated');
      if ((this.f.paymentId.value !== '' || this.f.paymentId.value !== null) && Number(this.f.paymentId.value) > 0) {
        this.commissionPayUpdated();
      }
      else {
        this.commissionPayInsert();
      }
      this.spinner.hide();

    });
  }
  private commissionPayUpdated() {
    this.spinner.show();
    if (Number(this.f.changesccid.value) > 0) {
      this.getCourseName();
    }
    const editBranchcommission = {
      id: this.f.paymentId.value,
      //bidpay: this.currentUser.id,
      //bnamepay: this.currentUser.bname,
      //stidpay: this.f.scstid.value,
      cnamepay: Number(this.f.changesccid.value) > 0 ? this.f.changescname.value : this.f.cname.value,
      amount_crpay: this.f.amount_crpay.value === '' ? 0 : this.f.amount_crpay.value
      //amount_repay: 0,
      //payment_stauspay: 0,
      //payment_modepay: '',
      //payment_datepay: '',
      //payment_re: '',
      //payment_onl: ''
    }
    this.commissionPayService.updateCourseBindPayment(editBranchcommission).subscribe((res: any) => {
      this.toastr.success('Successfully', 'Updated');
      this.spinner.hide();
      this.reset();
    });
  }
  private commissionPayInsert() {
    this.spinner.show();
    this.getCourseName();
    const addBranchcommission = {
      bidpay: this.f.bid.value,
      bnamepay: this.f.bname.value,
      stidpay: this.nSSYcode,
      cnamepay: Number(this.f.changesccid.value) > 0 ? this.f.changescname.value : this.f.cname.value,
      amount_crpay: this.f.amount_crpay.value === '' ? 0 : this.f.amount_crpay.value,
      amount_repay: 0,
      payment_stauspay: 0,
      payment_modepay: '',
      payment_datepay: '',
      payment_re: '',
      payment_onl: ''
    }
    this.commissionPayService.createCommissionPay(addBranchcommission).subscribe((res: any) => {
      if (res) {
        this.toastr.success('Successfully', 'Inserted');
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }
  private reset() {
    this.editCourseStudentForm.reset();
    this.getActiveCourseList();
  }
  getCourseName() {
    for (const key in this.courseList) {
      if (this.courseList[key].id === Number(this.f.changesccid.value)) {
        this.editCourseStudentForm.get('changescname').setValue(this.courseList[key].cname);
        break;
      }
    }
  }

}
