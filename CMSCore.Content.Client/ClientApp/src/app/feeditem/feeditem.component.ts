import {Component, OnInit} from '@angular/core';
import {Comment, ContentService, CreateComment, FeedItemDetails, OperationResult} from "../services/content.service";
import {ActivatedRoute} from "@angular/router";
import {Subscription} from "rxjs/internal/Subscription";
import {FormControl, Validators} from "@angular/forms";
import 'rxjs/add/operator/first'
import {MatSnackBar} from "@angular/material";
import {SnackbarComponent} from "../snackbar/snackbar.component";

@Component({
  selector: 'app-feeditem',
  templateUrl: './feeditem.component.html',
  styleUrls: ['./feeditem.component.css']
})
export class FeeditemComponent implements OnInit {
  private sub: Subscription;
  private feedItemId: string;
  public feedItem: FeedItemDetails;
  public comment: CreateComment = new CreateComment();

  constructor(private route: ActivatedRoute,
              public contentService: ContentService,
              public snackBar: MatSnackBar) {
  }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.feedItemId = params['id'];
      this.getFeedItem();
    });
  }

  private getFeedItem(): void {
    this.contentService.feedItem(this.feedItemId).first().subscribe(p => this.feedItem = p);

  }

  email = new FormControl('', [Validators.required, Validators.email]);
  text = new FormControl('', [Validators.required]);

  getErrorMessage() {
    return this.email.hasError('required') ? 'You must enter your email' :
      this.email.hasError('email') ? 'Not a valid email' :
        '';
  }

  submitComment(): void {
    this.comment.feedItemId = this.feedItemId;
    this.contentService.submitComment(this.comment).first().subscribe(x => {
      this.openSnackbar(x);
      this.getFeedItem();
    }, error1 => this.openSnackbar(error1));
  }

  openSnackbar(data: OperationResult) {
    this.snackBar.openFromComponent(SnackbarComponent, {
      data: data, duration: 2500
    });
  }
}
