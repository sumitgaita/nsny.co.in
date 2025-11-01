import { Component } from "@angular/core";
import { environment } from '../../../src/app/environments/environment';
@Component({
  selector: 'app-image-formatter-cell',
  template: `<img border="0" width="50" height="50" src=\"${environment.apiUrl}/Files/{{ params.value }}\">`
})

export class ImageFormatterComponent {
  params: any;
  agInit(params: any) {
    if (params && params.value && params.value !== ''
      && params.value !== '.jpg')
    {
      this.params = params;
    }
    else {
      this.params = { value: 'no-image.jpg' };
    }
  }
}
