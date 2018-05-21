import {Component, OnInit} from '@angular/core';
import { BreakpointObserver, Breakpoints, BreakpointState } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import {ContentService, PageTree} from "../services/content.service";
import {AuthService} from "../auth/auth.service";

@Component({
  selector: 'navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements  OnInit{
  pageTree: Observable<PageTree[]>;

  isHandset: Observable<BreakpointState> = this.breakpointObserver.observe(Breakpoints.Handset);
  constructor(private breakpointObserver: BreakpointObserver,
              public auth: AuthService,
              private contentService: ContentService) {}

  ngOnInit(): void {
  this.pageTree = this.contentService.pageTree();
  }
}
