import {Routes} from "@angular/router";
import {ManageComponent} from "./manage/manage.component";
import {PageComponent} from "./page/page.component";
import {FeeditemComponent} from "./feeditem/feeditem.component";

export const routes: Routes = [
  {path: '', redirectTo: "/home", pathMatch: 'full'},
  {path: 'home', component: ManageComponent, pathMatch: 'full'},
  {path: 'page/:id', component: PageComponent},
  {path: 'feeditem/:id', component: FeeditemComponent},
  {path: 'manage', component: ManageComponent}
];
