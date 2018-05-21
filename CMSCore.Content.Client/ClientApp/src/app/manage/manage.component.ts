import {Component} from '@angular/core';
import {ContentService, CreatePage, OperationResult} from "../services/content.service";
import {MatSnackBar} from "@angular/material";
import {SnackbarComponent} from "../snackbar/snackbar.component";

@Component({
  selector: 'manage',
  templateUrl: './manage.component.html',
  styleUrls: ['./manage.component.css']
})
export class ManageComponent {

  constructor(private contentService: ContentService,
              public snackBar: MatSnackBar) {
  }

  public page: CreatePage = new CreatePage();

  openSnackbar(data: OperationResult) {
    this.snackBar.openFromComponent(SnackbarComponent, {
      data: data, duration: 2500
    });
  }

  createPage(): void {
    this.contentService.createPage(this.page).first().subscribe(x => {
      this.openSnackbar(x);
    }, error1 => this.openSnackbar(error1));
  }
}
