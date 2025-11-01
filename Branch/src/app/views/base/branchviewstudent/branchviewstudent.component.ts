import { Component } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { NgbAlertModule, NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule } from '@angular/common'
import { DocsExampleComponent } from '@docs-components/public-api';
import { NgxSpinnerService } from "ngx-spinner";
import { RowComponent, ColComponent, TextColorDirective, CardComponent, CardHeaderComponent, CardBodyComponent, InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective, FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent, DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective, DropdownDividerDirective, FormSelectDirective } from '@coreui/angular';
import { AgGridAngular } from 'ag-grid-angular'; 
import { ColDef } from 'ag-grid-community'; 
import { StudentService } from '../../../services/student.service';
import { ImageFormatterComponent } from '../../../services/ImageFormatter';
import { AuthenticationService } from '../../../services/authentication.service';
@Component({
  selector: 'branch-view-student',
  templateUrl: './branchviewstudent.component.html',
  styleUrls: ['./branchviewstudent.component.scss'],
  standalone: true,
  imports: [RowComponent, ColComponent, TextColorDirective, CardComponent,
    CardHeaderComponent, CardBodyComponent, DocsExampleComponent,
    InputGroupComponent, InputGroupTextDirective, FormControlDirective, FormLabelDirective,
    FormCheckInputDirective, ButtonDirective, ThemeDirective, DropdownComponent,
    DropdownToggleDirective, DropdownMenuDirective, DropdownItemDirective,
    RouterLink, DropdownDividerDirective,
    FormSelectDirective, ReactiveFormsModule, NgbAlertModule, NgbDatepickerModule,
    CommonModule, FormsModule, AgGridAngular]
})
export class BranchViewStudentComponent {

  columnDefs: ColDef[] = [];
  currentUser: any;
  branchviewstudentList: any[] = [];
  pageSize: number = 20;

  constructor(private studentService: StudentService,
    private spinner: NgxSpinnerService,
    private authenticationService: AuthenticationService
  ) {
    this.columnDefs = [
      { headerName: 'ID', field: 'stid', sortable: true },
      { headerName: 'Name', field: 'sname', sortable: true, filter: true },
      { headerName: 'Father Name', field: 'guardian', sortable: true, filter: true },
      { headerName: 'Course', field: 'cname', sortable: true, filter: true },
      { headerName: 'Admission', field: 'sjoin', sortable: true },
      { headerName: 'Address', field: 'stuaddress', sortable: true },
      { headerName: 'Mobile', field: 'stumobile', sortable: true },
      { headerName: 'DOB', field: 'studob', sortable: true },
      { headerName: 'Sex', field: 'stusex', sortable: true },
      { headerName: 'Passing out year', field: 'passingoutyear', sortable: true },
      { headerName: 'PIC', field: 'stupic', sortable: true, cellRenderer: ImageFormatterComponent }
    ];
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  ngOnInit() {
    this.getAllStudentByBranch();
  }
  private getAllStudentByBranch() {
    this.spinner.show();
    this.branchviewstudentList = [];
    this.studentService.getBranchViewStudent(this.currentUser.id).subscribe((res: any) => {
      if (res && res.length > 0) {
        this.branchviewstudentList = res;
        this.spinner.hide();
      }
      else {
        this.spinner.hide();
      }
    });
  }

  excelFileData() {
    let strhtml = "";
    strhtml += " <table class=\"table table-hover table-bordered table-striped\" border=\"1\">";
    strhtml += "  <thead>";
    strhtml += "       <tr>";
    strhtml += "        <th>ID</th>";
    strhtml += "         <th>Name</th>";
    strhtml += "         <th>Father Name</th>";
    strhtml += "         <th>Course</th>";
    strhtml += "         <th>Admission</th>";
    strhtml += "         <th>Address</th>";
    strhtml += "         <th>Mobile</th>";
    strhtml += "         <th>DOB</th>";
    strhtml += "         <th>Sex</th>";
    strhtml += "         <th>Passing out year</th>";
    strhtml += "         <th width =\"50\" height =\"50\">PIC</th>";
    strhtml += "                   </tr>";
    strhtml += "               </thead>";
    strhtml += "              <tbody>";
    for (const key in this.branchviewstudentList) {
      strhtml += "        <tr>";
      strhtml += "          <td>" + this.branchviewstudentList[key].stid + "</td>";
      strhtml += "          <td>" + this.branchviewstudentList[key].sname + "</td>";
      strhtml += "          <td>" + this.branchviewstudentList[key].guardian + "</td>";
      strhtml += "          <td>" + this.branchviewstudentList[key].cname + "</td>";
      strhtml += "          <td>" + this.branchviewstudentList[key].sjoin + "</td>";
      strhtml += "          <td>" + this.branchviewstudentList[key].stuaddress + "</td>";
      strhtml += "          <td>" + this.branchviewstudentList[key].stumobile + "</td>";
      strhtml += "          <td>" + this.branchviewstudentList[key].studob + "</td>";
      strhtml += "          <td>" + this.branchviewstudentList[key].stusex + "</td>";
      strhtml += "          <td>" + this.branchviewstudentList[key].passingoutyear + "</td>";
      //strhtml += "          <td width =\"50\" height =\"50\"><img width =\"50\" height =\"50\" src =\"" + environment.apiUrl + "/Files/" + this.branchviewstudentList[key].stupic + "\"></td>";
      strhtml += "           <td>" + this.branchviewstudentList[key].stupic + "</td>";
      strhtml += "   </tr>";

    }
    strhtml += "      </tbody>";
    strhtml += "      </table>";
    const blob = new Blob([strhtml], {
      type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
    });
    const link = document.createElement('a');
    link.href = window.URL.createObjectURL(blob);
    link.download = 'StudentDetailsList.xls';
    link.click();
    window.URL.revokeObjectURL(link.href);
  }
  printData() {
    let strhtml = "";
    strhtml += " <table class=\"table table-hover table-bordered table-striped\" border=\"1\">";
    strhtml += "  <thead>";
    strhtml += "       <tr>";
    strhtml += "        <th>ID</th>";
    strhtml += "         <th>Name</th>";
    strhtml += "         <th>Father Name</th>";
    strhtml += "         <th>Course</th>";
    strhtml += "         <th>Admission</th>";
    strhtml += "         <th>Address</th>";
    strhtml += "         <th>Mobile</th>";
    strhtml += "         <th>DOB</th>";
    strhtml += "         <th>Sex</th>";
    strhtml += "         <th>Passing out year</th>";
    strhtml += "         <th>PIC</th>";
    strhtml += "                   </tr>";
    strhtml += "               </thead>";
    strhtml += "              <tbody>";
    for (const key in this.branchviewstudentList) {
      strhtml += "        <tr>";
      strhtml += "          <td>" + this.branchviewstudentList[key].stid + "</td>";
      strhtml += "           <td>" + this.branchviewstudentList[key].sname + "</td>";
      strhtml += "          <td>" + this.branchviewstudentList[key].guardian + "</td>";
      strhtml += "          <td>" + this.branchviewstudentList[key].cname + "</td>";
      strhtml += "          <td>" + this.branchviewstudentList[key].sjoin + "</td>";
      strhtml += "          <td>" + this.branchviewstudentList[key].stuaddress + "</td>";
      strhtml += "          <td>" + this.branchviewstudentList[key].stumobile + "</td>";
      strhtml += "          <td>" + this.branchviewstudentList[key].studob + "</td>";
      strhtml += "          <td>" + this.branchviewstudentList[key].stusex + "</td>";
      strhtml += "          <td>" + this.branchviewstudentList[key].passingoutyear + "</td>";
      //strhtml += " <td><img border=\"0\" width =\"50\" height =\"50\" src =\"" + environment.apiUrl + "/Files/" + this.branchviewstudentList[key].stupic + "\"></td>";
      strhtml += "          <td>" + this.branchviewstudentList[key].stupic + "</td>";

      strhtml += "   </tr>";

    }
    strhtml += "      </tbody>";
    strhtml += "      </table>";
    const mywindow = window.open('', '_blank', 'height=600,width=700')!;
    mywindow.document.open();
    mywindow.document.write(strhtml);
    setTimeout(() => {
      mywindow.print();
      mywindow.close();
    }, 1000);

  }
}
