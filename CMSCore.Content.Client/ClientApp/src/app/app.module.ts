import {NgModule} from "@angular/core";

import {BrowserModule} from '@angular/platform-browser';
import {AppComponent} from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {ManageComponent} from './manage/manage.component';
import {NavigationComponent} from './navigation/navigation.component';
import {LayoutModule} from '@angular/cdk/layout';
import {PageComponent} from './page/page.component';
import {ContentService} from "./services/content.service";
import {HttpClientModule} from "@angular/common/http";
import {FeeditemComponent} from './feeditem/feeditem.component';
import {RouterModule} from "@angular/router";
import {FlexLayoutModule} from "@angular/flex-layout";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {SnackbarComponent} from "./snackbar/snackbar.component";
import {AuthService} from "./auth/auth.service";
import {CallbackComponent} from "./callback/callback.component";
import {CreatePageComponent} from './manage/page/create-page/create-page.component';
import {MaterialModule} from "./material.module";
import {routes} from "./routes";

@NgModule({
  declarations: [
    AppComponent,
    ManageComponent,
    NavigationComponent,
    PageComponent,
    FeeditemComponent,
    SnackbarComponent,
    CallbackComponent,
    CreatePageComponent
  ],
  imports: [
    MaterialModule,
    BrowserModule,
    BrowserAnimationsModule,
    LayoutModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    RouterModule.forRoot(routes)
  ],
  entryComponents: [
    SnackbarComponent
  ],
  providers: [
    ContentService,
    AuthService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}


