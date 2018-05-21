import { Component } from '@angular/core';
import {BreakpointObserver, Breakpoints} from "@angular/cdk/layout";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  isHandset: boolean;

  constructor(private breakpointObserver: BreakpointObserver){
    this.breakpointObserver.observe(Breakpoints.Handset).subscribe(x => this.isHandset = x.matches);

  }
}
