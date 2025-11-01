import { Component, LOCALE_ID, Inject } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { ICellRendererParams } from 'ag-grid-community';
import { formatDate } from '@angular/common';

@Component({
  selector: 'datetime-cell',
  template: `<span>{{ formatTheDate() }}</span>`
})
export class DateTimeRenderer implements ICellRendererAngularComp {

  params!: ICellRendererParams;
  selectedDate!: Date;
  dateFormat = 'yyyy-MM-dd';

  constructor(@Inject(LOCALE_ID) public locale: string) { }

  agInit(params: ICellRendererParams): void {
    this.params = params;
    this.selectedDate = params.value;

    if (typeof params?.colDef?.cellRendererParams != 'undefined') {
      this.dateFormat = params.colDef.cellRendererParams;
    }
  }

  formatTheDate() {
    if (!this.selectedDate && this.selectedDate == null)
      return "";

    return formatDate(this.selectedDate, this.dateFormat, this.locale);
  }

  public onChange(event:any) {
    this.params!.data[this.params!.colDef!.field!] = event.currentTarget.checked;
  }

  refresh(params: ICellRendererParams): boolean {
    this.selectedDate = params.value;
    return true;
  }
}
