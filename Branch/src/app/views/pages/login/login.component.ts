import { Component } from '@angular/core';
import { NgStyle } from '@angular/common';
import { IconDirective } from '@coreui/icons-angular';
import { CommonModule } from '@angular/common'
import { ReactiveFormsModule, FormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ContainerComponent, RowComponent, ColComponent, CardGroupComponent, TextColorDirective, CardComponent, CardBodyComponent, FormDirective, InputGroupComponent, InputGroupTextDirective, FormControlDirective, ButtonDirective } from '@coreui/angular';
import { AuthenticationService } from '../../../services/authentication.service';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from "ngx-spinner";
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  standalone: true,
  imports: [ContainerComponent, RowComponent, ColComponent, CardGroupComponent, TextColorDirective,
    CardComponent, CardBodyComponent, FormDirective, InputGroupComponent, InputGroupTextDirective,
    IconDirective, FormControlDirective, ButtonDirective, NgStyle, ReactiveFormsModule, FormsModule, CommonModule]
})
export class LoginComponent {
  loginForm: FormGroup | any;
  loading = false;
  submitted = false;
  returnUrl!: string;
  error = '';
  loginType: string[] = ['Admin', 'Branch'];
  public title = environment.websitetitle;
  constructor(

    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private spinner: NgxSpinnerService,
    private router: Router,
    private toastr: ToastrService,
    private authenticationService: AuthenticationService
  ) {

    //this.titleService.setTitle("Login Page");
  }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      loginType: ['Branch', Validators.required] //'Admin', 'Branch'
    });
    this.authenticationService.logout();
    this.router.navigate(['/']);
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';

  }


  get f() { return this.loginForm.controls; }

  onSubmit() {
    this.submitted = true;
    this.spinner.show();

    if (this.loginForm.invalid) {
      return;
      this.spinner.hide();
    }


    this.authenticationService.login(this.f.username.value, this.f.password.value, this.f.loginType.value)
      .subscribe((res: any) => {
        if (res) {
          this.spinner.hide();
          this.router.navigate(['/base/branchdashboard']);
        }
        else {
          this.toastr.error('Worng', 'Username and Password');
          this.loading = false;
          this.spinner.hide();
        }
      });

  }
}
