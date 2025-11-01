import { Component } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common'
import { DocsExampleComponent } from '@docs-components/public-api';
import { AuthenticationService } from '../../../services/authentication.service';
import { RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent, CardBodyComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, DropdownDividerDirective, FormSelectDirective } from '@coreui/angular';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerModule } from "ngx-spinner";
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'change-branch-password',
  templateUrl: './changebranchpassword.component.html',
  styleUrls: ['./changebranchpassword.component.scss'],
  standalone: true,
  imports: [RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent,
    CardBodyComponent, DocsExampleComponent, InputGroupComponent, InputGroupTextDirective,
    FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective,
    ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective,
    DropdownItemDirective, RouterLink, DropdownDividerDirective, FormSelectDirective,
    ReactiveFormsModule, CommonModule, FormsModule, NgxSpinnerModule]
})
export class ChangeBranchPasswordComponent {
  loading = false;
  currentUser: any;
  password!: string;
  constructor(private authenticationService: AuthenticationService, private spinner: NgxSpinnerService, private toastr: ToastrService, private router: Router) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  ngOnInit() {
    this.loading = true;
    this.password = this.currentUser.password;
  }
  changeBranchPassword() {
    this.spinner.show();
    this.authenticationService.changeBranchPassword(this.currentUser.id, this.password).subscribe((res: any) => {
      if (res) {
        this.toastr.success('Successfully', 'Updated');
        this.spinner.hide();
        this.router.navigate(['/']);
      }
      else {
        this.spinner.hide();
      }
    });
  }

}
