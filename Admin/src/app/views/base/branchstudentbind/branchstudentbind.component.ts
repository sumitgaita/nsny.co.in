import { Component } from '@angular/core';
import { Title } from "@angular/platform-browser";
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { CommonModule, DatePipe } from '@angular/common'
import { DocsExampleComponent } from '@docs-components/public-api';
import { CourseService } from '../../../services/course.service';
import { CommissionPayService } from '../../../services/commissionpay.service';
import { StudentService } from '../../../services/student.service';
import { BranchstudentbindService } from '../../../services/branchstudentbind.service';
import { AuthenticationService } from '../../../services/authentication.service';
import { WalletService } from '../../../services/wallet.service';
import { RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent, CardBodyComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, DropdownDividerDirective, FormSelectDirective} from '@coreui/angular';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'branch-student-bind',
  templateUrl: './branchstudentbind.component.html',
  styleUrls: ['./branchstudentbind.component.scss'],
    standalone: true,
  imports: [RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent,
    CardBodyComponent, DocsExampleComponent, InputGroupComponent, InputGroupTextDirective,
    FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective,
    ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective,
    DropdownItemDirective, RouterLink, DropdownDividerDirective, FormSelectDirective,
    ReactiveFormsModule, CommonModule]
})
export class BranchStudentBindComponent {
  loading = false;
  submitted = false;
  currentUser: any;
  nssCodeList: any = [];
  courseList: any = [];
  addCourseStudentForm: FormGroup | any;
  totalWalletAmount: number = 0;
  paymentModeList: string[] = ['Full Payment', 'Installment Payment'];
  constructor(private titleService: Title, private courseService: CourseService,
    private commissionPayService: CommissionPayService,
    private studentService: StudentService,
    private toastr: ToastrService,
    private branchstudentbindService: BranchstudentbindService,
    private authenticationService: AuthenticationService,
    private datePipe: DatePipe,
    private walletService: WalletService,
    private spinner: NgxSpinnerService,
    private formBuilder: FormBuilder) {
    this.titleService.setTitle("Course Binding Page");
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }
  ngOnInit() {
    this.loading = true;
    this.addCourseStudentForm = this.formBuilder.group({
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
      theory: [0.00],
      practical: [0.00]
    });
    this.getNssCode();
    this.getActiveCourseList();
    this.addCourseStudentForm.get('scsjoin').setValue(this.datePipe.transform(new Date(), 'yyyy-MM-dd'));
    if (this.currentUser.paymentMode === 'Wallet') {
      this.onBranchBalanceCheck()
    }


  }
  get f() { return this.addCourseStudentForm.controls; }

  onBranchBalanceCheck() {
    const branchId = Number(this.currentUser.id);
    this.spinner.show();
    this.totalWalletAmount = 0;
    this.walletService.GetBranchWallet(branchId).subscribe((res: any) => {
      if (res && res.length > 0) {
        this.totalWalletAmount = Number(res[0].existingamount);
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }
  private getNssCode() {
    this.spinner.show();
    this.studentService.getCenterCodeStudent(this.currentUser.id).subscribe((res: any) => {
      if (res) {
        this.nssCodeList = res;
        this.addCourseStudentForm.get('scstid').setValue(res[0].nssY_code);
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
        this.addCourseStudentForm.get('sccid').setValue(res[0].id);
        this.getSelectedCourse();
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }

    });
  }

  getSelectedCourse() {
    this.spinner.show();
    this.courseService.GetByIdCourse(this.f.sccid.value).subscribe((res: any) => {
      if (res) {
        this.getPaymentStaus(res[0]);
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }
  getSelectedPaymentMode() {
    this.spinner.show();
    this.courseService.GetByIdCourse(this.f.sccid.value).subscribe((res: any) => {
      if (res) {
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
    this.addCourseStudentForm.get('scamountremaing').setValue(amount);
  }
  private getPaymentStaus(res: any) {
    if (this.f.scctype.value === 'Full Payment') {
      this.addCourseStudentForm.get('scctotal').setValue(res.cfullpay);
      this.addCourseStudentForm.get('scamountremaing').setValue(res.cfullpay);
      this.addCourseStudentForm.get('sctotalInstallment').setValue(0);
      this.addCourseStudentForm.get('scremainginstallment').setValue(0);
    }
    else if (this.f.scctype.value === 'Installment Payment') {
      this.addCourseStudentForm.get('scctotal').setValue(res.cinspay_f);
      this.addCourseStudentForm.get('scamountremaing').setValue(res.cinspay_f);
      this.addCourseStudentForm.get('sctotalInstallment').setValue(res.cinspay_xm);
      this.addCourseStudentForm.get('scremainginstallment').setValue(res.cinspay_xm);
    }
    this.addCourseStudentForm.get('amount_crpay').setValue(res.hqamount);
    this.addCourseStudentForm.get('scpaymentclear').setValue('Payment Not Clear');
  }
  onAddCourseStudentSubmit() {
    this.submitted = true;
    this.spinner.show();
    if (this.addCourseStudentForm.invalid) {
      this.spinner.hide();
      return;
    }
    const addBranchStudentBind = {
      scbid: this.currentUser.id,
      scbname: this.currentUser.bname,
      scstid: this.f.scstid.value,
      scsjoin: this.f.scsjoin.value,
      scamountremaing: this.f.scamountremaing.value,
      sccid: this.f.sccid.value,
      sclastamountpay: this.f.sclastamountpay.value,
      scctype: this.f.scctype.value,
      sctotalInstallment: this.f.sctotalInstallment.value,
      scctotal: this.f.scctotal.value,
      sccdiscount: this.f.sccdiscount.value,
      scremainginstallment: this.f.scremainginstallment.value,
      scpaymentclear: this.f.scpaymentclear.value,
      scdateofpayment: this.f.scsjoin.value,
      theory: this.f.theory.value,
      practical: this.f.practical.value
    }
    this.branchstudentbindService.createbranchstudentbind(addBranchStudentBind).subscribe((res: any) => {
      if (res) {
        this.toastr.success('Successfully', 'Inserted');
        this.commissionPayInsert();
        this.spinner.hide();
        this.addCourseStudentForm.get('theory').setValue('');
        this.addCourseStudentForm.get('practical').setValue('');
        if (this.currentUser.paymentMode === 'Wallet') {
          this.onBranchBalanceCheck()
        }
      }
      else {
        const hqValue = isNaN(parseFloat(this.f.amount_crpay.value)) ? 0 : this.f.amount_crpay.value;
        const totalexistingamount = (this.totalWalletAmount - hqValue);
        if (this.currentUser.paymentMode === 'Wallet' && totalexistingamount < 0) {
          this.toastr.warning('Recharge Your Account. Contact your head quarter.');
        }
        else {
          this.toastr.warning('Already Add Course to Student.');
        }
        this.spinner.hide();
      }
    });
  }
  private commissionPayInsert() {
    this.spinner.show();
    this.getCourseName();
    const addBranchcommission = {
      bidpay: this.currentUser.id,
      bnamepay: this.currentUser.bname,
      stidpay: this.f.scstid.value,
      cnamepay: this.f.cname.value,
      amount_crpay: this.f.amount_crpay.value,
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
    this.addCourseStudentForm.reset();
  }
  getCourseName() {
    for (const key in this.courseList) {
      if (this.courseList[key].id === Number(this.f.sccid.value)) {
        this.addCourseStudentForm.get('cname').setValue(this.courseList[key].cname);
        break;
      }
    }
  }

}
