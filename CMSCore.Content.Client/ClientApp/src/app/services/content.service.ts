import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs/internal/Observable";
import {FeedItem, Page, Tag} from "../page/page.component";
import {Headers} from "@angular/http";

@Injectable({
  providedIn: "root"
})
export class ContentService {

  constructor(public httpClient: HttpClient) {
  }

  private _headers = new HttpHeaders().set('Content-Type', 'application/json');

  get(url): Observable<any> {
    return this.httpClient.get(url);
  }

  pageTree(): Observable<any> {
    return this.httpClient.get(ContentEndpoint.pageTree);
  }

  page(id): Observable<Page> {
    return this.httpClient.get<Page>(ContentEndpoint.pageById(id));
  }

  feedItem(id): Observable<FeedItemDetails> {
    return this.httpClient.get<FeedItemDetails>(ContentEndpoint.feedItemById(id));
  }

  submitComment(comment: CreateComment): Observable<OperationResult> {
    return this.httpClient.post<OperationResult>(CreateContentEndpoint.comment, comment);
  }

  createPage(page: CreatePage): Observable<OperationResult> {
    return this.httpClient.post<OperationResult>(CreateContentEndpoint.page, page,{headers: this.authHeaders()});
  }

  createFeedItem(feedItem: CreateFeedItem): Observable<OperationResult> {
     return this.httpClient.post<OperationResult>(CreateContentEndpoint.feedItem, feedItem, {headers: this.authHeaders()});
  }

  private authHeaders() : HttpHeaders {
    let headers = new HttpHeaders().set('Content-Type', 'application/json');
    const accessToken = localStorage.getItem('access_token');
    headers.append("Authorization", "Bearer " + accessToken)

    return headers;
  }
}

export const contentBaseUrl: string = "http://localhost:5000/api/content/";
export const createContentBaseUrl: string = "http://localhost:5000/api/content/create/";

export const ContentEndpoint = {
  pageTree: contentBaseUrl,
  pageById: (id) => contentBaseUrl + "page/" + id,
  feedItemById: (id) => contentBaseUrl + "feeditem/" + id
};

export const CreateContentEndpoint = {
  comment: createContentBaseUrl + "comment",
  page: createContentBaseUrl + "page",
  feedItem: createContentBaseUrl + "feedItem",
  feed: createContentBaseUrl + "feed",
};

export interface OperationResult {
  successful: boolean;
  message: string;
}

export class CreateComment {
  feedItemId: string;
  fullName: string = '';
  text: string = '';
}

export interface CreateFeedItem {
  commentsEnabled: boolean;
  content: string;
  description: string;
  feedId: string;
  isContentMarkdown: boolean;
  tags: string[];
  title: string;
}

export class CreatePage {
  content: string;
  feedEnabled: boolean;
  name: string;
}

export interface PageTree {
  date: Date;
  entityId: string;
  name: string;
  normalizedName: string;
}

export interface Comment {
  commentId: string;
  date: Date;
  fullName: string;
  text: string;
}


export interface FeedItemDetails {
  comments: Comment[];
  commentsEnabled: boolean;
  content: string;
  date: Date;
  description: string;
  feedId: string;
  id: string;
  modified: Date;
  normalizedTitle: string;
  tags: Tag[];
  title: string;
}
