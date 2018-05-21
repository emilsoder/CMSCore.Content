import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Comment} from "./content.service";

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor(private httpClient: HttpClient) { }


}
