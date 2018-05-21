import {Component, OnDestroy, OnInit} from '@angular/core';
import {ContentEndpoint, ContentService} from "../services/content.service";
import {ActivatedRoute} from "@angular/router";
import {Subscription} from "rxjs/internal/Subscription";
import "rxjs/operator"

@Component({
  selector: 'app-page',

  templateUrl: './page.component.html',
  styleUrls: ['./page.component.css']
})
export class PageComponent implements OnInit, OnDestroy {
  private sub: Subscription;
  private pageId: string;
  public page: Page;

  constructor(
    private route: ActivatedRoute,
    public contentService: ContentService) {
  }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.pageId = params['id'];
      this.contentService.page(this.pageId).subscribe(p => this.page = p);
     });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

}

export interface Tag {
  entityId: string;
  name: string;
  normalizedName: string;
}

export interface FeedItem {
  entityId: string;
  title: string;
  normalizedTitle: string;
  description: string;
  date: Date;
  modified: Date;
  tags: Tag[];
}

export interface Feed {
  entityId: string;
  name: string;
  normalizedName: string;
  date: Date;
  modified: Date;
  feedItems: FeedItem[];
}

export interface Page {
  content: string;
  date: Date;
  entityId: string;
  feed: Feed;
  modified: Date;
  name: string;
  normalizedName: string;
}
