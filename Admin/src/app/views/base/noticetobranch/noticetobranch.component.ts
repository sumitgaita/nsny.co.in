import { Component } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common'
import { DocsExampleComponent } from '@docs-components/public-api';
import { RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent, CardBodyComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, DropdownDividerDirective, FormSelectDirective } from '@coreui/angular';
import { ToastrService } from "ngx-toastr";
import { NgxSpinnerService } from "ngx-spinner";
import { BranchService } from '../../../services/branch.service';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { NgxEditorModule } from 'ngx-editor';
import { Editor } from 'ngx-editor';

@Component({
  selector: 'notice-to-branch',
  templateUrl: './noticetobranch.component.html',
  styleUrls: ['./noticetobranch.component.scss'],
  standalone: true,
  imports: [RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent,
    CardBodyComponent, DocsExampleComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective,
    FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent,
    DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, RouterLink, DropdownDividerDirective,
    FormSelectDirective, ReactiveFormsModule, CommonModule, NgMultiSelectDropDownModule,
    FormsModule, NgxEditorModule]
})
export class NoticetoBranchComponent {
  [x: string]: any;
  id!: number;
  title: string = '';
  content!: string;

  editor: Editor | any;
  html = '';
  mycontent!: string;
  selectedBranchId: number = 0;
  log!: string;

  res: any;
  branchList: any[] = [];
  selectedItems: any[] = [];
  dropdownSettings: IDropdownSettings = {};
  constructor(private branchService: BranchService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,) {
    this.mycontent = `<p>My html content</p>`;
  }

  ngOnInit() {
    this.editor = new Editor();
    this.content = '';
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'id',
      textField: 'bname',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 10,
      allowSearchFilter: true
    };
    this.getAllBranch();
  }

  private getAllBranch() {
    this.spinner.show();
    this.branchList = [];
    this.branchService.getAllBranch().subscribe((res: any) => {
      if (res && res.length > 0) {
        this.branchList = res;
        this.selectedBranchId = res[0].id;
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }
  onSubmit() {
    this.spinner.show();
    if (this.title === '') {
      this.spinner.hide();
      this.toastr.info('Enter Title.', 'Title');
      return;
    }
    for (const key in this.selectedItems) {
      const addNotification = {
        title: this.title,
        content_details: this.content,
        bid: this.selectedItems[key].id,
        activation: 1
      }
      this.branchService.createBranchNotification(addNotification).subscribe((res: any) => {

      });
    }
    this.toastr.success('Successfully', 'Inserted');
    this.spinner.hide();
  }
  editorChange(event: any) {
    this.content = event;
  }
  onItemSelect(item: any) {
    console.log('onItemSelect', item);
  }
  onSelectAll(items: any) {
    console.log('onSelectAll', items);
  }

}
