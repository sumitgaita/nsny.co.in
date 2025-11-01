import { Component } from '@angular/core';
import { FooterComponent } from '@coreui/angular';
import { environment } from '../../../environments/environment';
@Component({
    selector: 'app-default-footer',
    templateUrl: './default-footer.component.html',
    styleUrls: ['./default-footer.component.scss'],
    standalone: true,
})
export class DefaultFooterComponent extends FooterComponent {
  domain: string = environment.originalsite;
  constructor() {
    super();
  }
}
