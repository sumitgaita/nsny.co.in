import { Component } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { DocsExampleComponent } from '@docs-components/public-api';
import { NgxSpinnerService } from "ngx-spinner";
import { WalletService } from '../../../services/wallet.service';
import { RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent, CardBodyComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, DropdownDividerDirective, FormSelectDirective } from '@coreui/angular';
import { ToastrService } from "ngx-toastr";
import { CommonModule } from '@angular/common'
@Component({
  selector: 'wallet',
  templateUrl: './wallet.component.html',
  styleUrls: ['./wallet.component.scss'],
    standalone: true,
  imports: [RowComponent, ColComponent, TextColorDirective, CardComponent,
    CardHeaderComponent, CardBodyComponent, DocsExampleComponent,
    InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective,
    FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent,
    DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective,
    RouterLink, DropdownDividerDirective,
    FormSelectDirective, ReactiveFormsModule,CommonModule]
})
export class WalletComponent {
  submitted = false;
  addwalletForm: FormGroup | any;
  paymentNoteList: string[] = ['Add Billing', 'extracharge + fine']; //'Spend by center'
  branchList: any[] = [];
  totalWalletAmount: number = 0;
  constructor(
    private walletService: WalletService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.addwalletForm = this.formBuilder.group({
      branchId: [0],
      comment: [''],
      walletamount: [0],
      extraoffer: [0],
      totalamount: [0],
      existingamount: [0],
      extrachargesfine: [0],
      paymentnote: ['Add Billing']

    });
    this.getAllBranch();
    this.disable();
  }
  get f() { return this.addwalletForm.controls; }
   private getAllBranch() {
    this.spinner.show();
    this.branchList = [];
    this.walletService.getAllWalletBranch().subscribe((res: any) => {
      if (res && res.length > 0) {
        this.branchList = res;
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }
  onBranchChange(event: any) {
    const branchId = Number(event.target.value);
    this.spinner.show();
    this.totalWalletAmount = 0;
    this.walletService.GetBranchWallet(branchId).subscribe((res: any) => {
      if (res && res.length > 0) {
        //this.addwalletForm.get('comment').setValue(res[0].comment);
        //this.addwalletForm.get('walletamount').setValue(res[0].walletamount);
        // this.addwalletForm.get('extraoffer').setValue(res[0].extraoffer);
        //this.addwalletForm.get('totalamount').setValue(res[0].totalamount);
        this.addwalletForm.get('existingamount').setValue(res[0].existingamount);
        this.totalWalletAmount = Number(res[0].existingamount);
        // this.addwalletForm.get('extrachargesfine').setValue(res[0].extrachargesfine);
        // this.addwalletForm.get('paymentnote').setValue(res[0].paymentnote);
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
        this.reset();
      }
    });
  }

  onPaymentNoteChange() {
    this.disable();
  }
  onAddwalletSubmit() {
    this.submitted = true;
    if (this.addwalletForm.invalid) {
      return;
    }
    this.spinner.show();
    const addwallet = {
      branchId: this.f.branchId.value === null ? 0 : this.f.branchId.value,
      comment: this.f.comment.value === null ? '' : this.f.comment.value,
      walletamount: this.f.walletamount.value === null ? 0 : this.f.walletamount.value,
      extraoffer: this.f.extraoffer.value === null ? 0 : this.f.extraoffer.value,
      totalamount: this.f.totalamount.value === null ? 0 : this.f.totalamount.value,
      existingamount: this.f.existingamount.value === null ? 0 : this.f.existingamount.value,
      extrachargesfine: this.f.extrachargesfine.value === null ? 0 : this.f.extrachargesfine.value,
      paymentnote: this.f.paymentnote.value
    }
    if (this.f.branchId.value !== null && this.f.branchId.value > 0) {
      this.walletService.createWallet(addwallet).subscribe((res: any) => {
        if (res) {
          this.totalWalletAmount = 0;
          this.reset();
          this.toastr.success('Successfully', 'Inserted');
          this.addwalletForm.get('branchId').setValue(0);
          this.spinner.hide();
        }
        else {
          this.spinner.hide();
        }
      });
    }
    else {
      this.toastr.success('Select Center Code.');
      this.spinner.hide();
    }
  }

  private reset() {
    // this.addwalletForm.reset();    
    this.addwalletForm.get('comment').setValue('');
    this.addwalletForm.get('walletamount').setValue(0);
    this.addwalletForm.get('extraoffer').setValue(0);
    this.addwalletForm.get('totalamount').setValue(0);
    this.addwalletForm.get('existingamount').setValue(0);
    this.addwalletForm.get('extrachargesfine').setValue(0);
    this.addwalletForm.get('paymentnote').setValue('Add Billing');
    this.disable();
    this.totalWalletAmount = 0;
  }

  private disable() {
    if (this.f.paymentnote.value == 'Add Billing') {
      this.addwalletForm.controls['extrachargesfine'].disable();
      this.addwalletForm.controls['comment'].disable();
      this.addwalletForm.controls['walletamount'].enable();
      this.addwalletForm.controls['extraoffer'].enable();
      this.addwalletForm.get('comment').setValue('');
      this.addwalletForm.get('extrachargesfine').setValue(0);
      this.onExtraChargesFineChange();

    }
    else if (this.f.paymentnote.value == 'extracharge + fine') {
      this.addwalletForm.controls['extrachargesfine'].enable();
      this.addwalletForm.controls['comment'].enable();
      this.addwalletForm.controls['walletamount'].disable();
      this.addwalletForm.controls['extraoffer'].disable();
      this.addwalletForm.get('walletamount').setValue(0);
      this.addwalletForm.get('extraoffer').setValue(0);
      this.onWalletAmountChange();
      this.onExtraOfferChange();
    }
  }

  onWalletAmountChange() {
    this.addwalletForm.get('existingamount').setValue(this.totalWalletAmount);
    const extraoffer = isNaN(parseFloat(this.f.extraoffer.value)) ? 0 : this.f.extraoffer.value;
    const walletamount = isNaN(parseFloat(this.f.walletamount.value)) ? 0 : this.f.walletamount.value;
    const existingamount = isNaN(parseFloat(this.f.existingamount.value)) ? 0 : this.f.existingamount.value;
    const totalexistingamount = (parseFloat(parseFloat(existingamount).toFixed(2)) + parseFloat(parseFloat(walletamount).toFixed(2))
      + parseFloat(parseFloat(extraoffer).toFixed(2))).toFixed(2);
    this.addwalletForm.get('existingamount').setValue(totalexistingamount);
    const totalamountcal = (parseFloat(parseFloat(extraoffer).toFixed(2)) + parseFloat(parseFloat(walletamount).toFixed(2))).toFixed(2);
    this.addwalletForm.get('totalamount').setValue(totalamountcal);
  }

  onExtraChargesFineChange() {
    this.addwalletForm.get('existingamount').setValue(this.totalWalletAmount);
    const extrachargesfine = isNaN(parseFloat(this.f.extrachargesfine.value)) ? 0 : this.f.extrachargesfine.value;
    const existingamount = isNaN(parseFloat(this.f.existingamount.value)) ? 0 : this.f.existingamount.value;
    const totalexistingamount = (parseFloat(parseFloat(existingamount).toFixed(2)) - parseFloat(parseFloat(extrachargesfine).toFixed(2))).toFixed(2);
    this.addwalletForm.get('existingamount').setValue(totalexistingamount);
  }


  onExtraOfferChange() {
    this.addwalletForm.get('existingamount').setValue(this.totalWalletAmount);
    const walletamount = isNaN(parseFloat(this.f.walletamount.value)) ? 0 : this.f.walletamount.value;
    const extraoffer = isNaN(parseFloat(this.f.extraoffer.value)) ? 0 : this.f.extraoffer.value;
    const existingamount = isNaN(parseFloat(this.f.existingamount.value)) ? 0 : this.f.existingamount.value;
    const totalextraoffer = (parseFloat(parseFloat(existingamount).toFixed(2)) + parseFloat(parseFloat(extraoffer).toFixed(2))
      + parseFloat(parseFloat(walletamount).toFixed(2))).toFixed(2);
    this.addwalletForm.get('existingamount').setValue(totalextraoffer);
    const totalamountcal = (parseFloat(parseFloat(walletamount).toFixed(2)) + parseFloat(parseFloat(extraoffer).toFixed(2))).toFixed(2);
    this.addwalletForm.get('totalamount').setValue(totalamountcal);
  }

}
