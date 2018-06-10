(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"],{

/***/ "./src/$$_lazy_route_resource lazy recursive":
/*!**********************************************************!*\
  !*** ./src/$$_lazy_route_resource lazy namespace object ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(function() {
		var e = new Error('Cannot find module "' + req + '".');
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "./src/$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "./src/app/app.component.css":
/*!***********************************!*\
  !*** ./src/app/app.component.css ***!
  \***********************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/app.component.html":
/*!************************************!*\
  !*** ./src/app/app.component.html ***!
  \************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<navigation></navigation>\n<div id=\"content-container\" [style.marginLeft]=\"isHandset ? '0px' : '200px'\">\n<router-outlet></router-outlet>\n</div>\n"

/***/ }),

/***/ "./src/app/app.component.ts":
/*!**********************************!*\
  !*** ./src/app/app.component.ts ***!
  \**********************************/
/*! exports provided: AppComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppComponent", function() { return AppComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_cdk_layout__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/cdk/layout */ "./node_modules/@angular/cdk/esm5/layout.es5.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var AppComponent = /** @class */ (function () {
    function AppComponent(breakpointObserver) {
        var _this = this;
        this.breakpointObserver = breakpointObserver;
        this.title = 'app';
        this.breakpointObserver.observe(_angular_cdk_layout__WEBPACK_IMPORTED_MODULE_1__["Breakpoints"].Handset).subscribe(function (x) { return _this.isHandset = x.matches; });
    }
    AppComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-root',
            template: __webpack_require__(/*! ./app.component.html */ "./src/app/app.component.html"),
            styles: [__webpack_require__(/*! ./app.component.css */ "./src/app/app.component.css")]
        }),
        __metadata("design:paramtypes", [_angular_cdk_layout__WEBPACK_IMPORTED_MODULE_1__["BreakpointObserver"]])
    ], AppComponent);
    return AppComponent;
}());



/***/ }),

/***/ "./src/app/app.module.ts":
/*!*******************************!*\
  !*** ./src/app/app.module.ts ***!
  \*******************************/
/*! exports provided: MaterialModule, routes, AppModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "MaterialModule", function() { return MaterialModule; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "routes", function() { return routes; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppModule", function() { return AppModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_material__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/material */ "./node_modules/@angular/material/esm5/material.es5.js");
/* harmony import */ var _angular_cdk_table__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/cdk/table */ "./node_modules/@angular/cdk/esm5/table.es5.js");
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/fesm5/platform-browser.js");
/* harmony import */ var _app_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./app.component */ "./src/app/app.component.ts");
/* harmony import */ var _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/platform-browser/animations */ "./node_modules/@angular/platform-browser/fesm5/animations.js");
/* harmony import */ var _manage_manage_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./manage/manage.component */ "./src/app/manage/manage.component.ts");
/* harmony import */ var _navigation_navigation_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./navigation/navigation.component */ "./src/app/navigation/navigation.component.ts");
/* harmony import */ var _angular_cdk_layout__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/cdk/layout */ "./node_modules/@angular/cdk/esm5/layout.es5.js");
/* harmony import */ var _page_page_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./page/page.component */ "./src/app/page/page.component.ts");
/* harmony import */ var _services_content_service__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ./services/content.service */ "./src/app/services/content.service.ts");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _feeditem_feeditem_component__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! ./feeditem/feeditem.component */ "./src/app/feeditem/feeditem.component.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _angular_flex_layout__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! @angular/flex-layout */ "./node_modules/@angular/flex-layout/esm5/flex-layout.es5.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _snackbar_snackbar_component__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(/*! ./snackbar/snackbar.component */ "./src/app/snackbar/snackbar.component.ts");
/* harmony import */ var _auth_auth_service__WEBPACK_IMPORTED_MODULE_17__ = __webpack_require__(/*! ./auth/auth.service */ "./src/app/auth/auth.service.ts");
/* harmony import */ var _callback_callback_component__WEBPACK_IMPORTED_MODULE_18__ = __webpack_require__(/*! ./callback/callback.component */ "./src/app/callback/callback.component.ts");
/* harmony import */ var _manage_page_manage_page_manage_page_component__WEBPACK_IMPORTED_MODULE_19__ = __webpack_require__(/*! ./manage/page/manage-page/manage-page.component */ "./src/app/manage/page/manage-page/manage-page.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var MaterialModule = /** @class */ (function () {
    function MaterialModule() {
    }
    MaterialModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            exports: [
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatFormFieldModule"],
                _angular_cdk_table__WEBPACK_IMPORTED_MODULE_2__["CdkTableModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatAutocompleteModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatBadgeModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatBottomSheetModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatButtonModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatButtonToggleModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatCardModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatCheckboxModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatChipsModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatStepperModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatDatepickerModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatDialogModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatDividerModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatExpansionModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatGridListModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatIconModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatInputModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatListModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatMenuModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatNativeDateModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatPaginatorModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatProgressBarModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatProgressSpinnerModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatRadioModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatRippleModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatSelectModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatSidenavModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatSliderModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatSlideToggleModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatSnackBarModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatSortModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatTableModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatTabsModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatToolbarModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatTooltipModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_1__["MatTreeModule"],
            ],
            declarations: [_manage_page_manage_page_manage_page_component__WEBPACK_IMPORTED_MODULE_19__["ManagePageComponent"]]
        })
    ], MaterialModule);
    return MaterialModule;
}());


















var routes = [
    { path: '', redirectTo: "/home", pathMatch: 'full' },
    { path: 'home', component: _manage_manage_component__WEBPACK_IMPORTED_MODULE_6__["ManageComponent"], pathMatch: 'full' },
    { path: 'page/:id', component: _page_page_component__WEBPACK_IMPORTED_MODULE_9__["PageComponent"] },
    { path: 'feeditem/:id', component: _feeditem_feeditem_component__WEBPACK_IMPORTED_MODULE_12__["FeeditemComponent"] },
    { path: 'manage', component: _manage_manage_component__WEBPACK_IMPORTED_MODULE_6__["ManageComponent"] }
];
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            declarations: [
                _app_component__WEBPACK_IMPORTED_MODULE_4__["AppComponent"],
                _manage_manage_component__WEBPACK_IMPORTED_MODULE_6__["ManageComponent"],
                _navigation_navigation_component__WEBPACK_IMPORTED_MODULE_7__["NavigationComponent"],
                _page_page_component__WEBPACK_IMPORTED_MODULE_9__["PageComponent"],
                _feeditem_feeditem_component__WEBPACK_IMPORTED_MODULE_12__["FeeditemComponent"],
                _snackbar_snackbar_component__WEBPACK_IMPORTED_MODULE_16__["SnackbarComponent"],
                _callback_callback_component__WEBPACK_IMPORTED_MODULE_18__["CallbackComponent"]
            ],
            imports: [
                MaterialModule,
                _angular_platform_browser__WEBPACK_IMPORTED_MODULE_3__["BrowserModule"],
                _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_5__["BrowserAnimationsModule"],
                _angular_cdk_layout__WEBPACK_IMPORTED_MODULE_8__["LayoutModule"],
                _angular_common_http__WEBPACK_IMPORTED_MODULE_11__["HttpClientModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_15__["FormsModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_15__["ReactiveFormsModule"],
                _angular_flex_layout__WEBPACK_IMPORTED_MODULE_14__["FlexLayoutModule"],
                _angular_router__WEBPACK_IMPORTED_MODULE_13__["RouterModule"].forRoot(routes)
            ],
            entryComponents: [
                _snackbar_snackbar_component__WEBPACK_IMPORTED_MODULE_16__["SnackbarComponent"]
            ],
            providers: [
                _services_content_service__WEBPACK_IMPORTED_MODULE_10__["ContentService"],
                _auth_auth_service__WEBPACK_IMPORTED_MODULE_17__["AuthService"]
            ],
            bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_4__["AppComponent"]]
        })
    ], AppModule);
    return AppModule;
}());



/***/ }),

/***/ "./src/app/auth/auth.service.ts":
/*!**************************************!*\
  !*** ./src/app/auth/auth.service.ts ***!
  \**************************************/
/*! exports provided: AuthService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AuthService", function() { return AuthService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _auth0_variables__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./auth0-variables */ "./src/app/auth/auth0-variables.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var rxjs_add_operator_filter__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/add/operator/filter */ "./node_modules/rxjs-compat/_esm5/add/operator/filter.js");
/* harmony import */ var auth0_js__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! auth0-js */ "./node_modules/auth0-js/src/index.js");
/* harmony import */ var auth0_js__WEBPACK_IMPORTED_MODULE_4___default = /*#__PURE__*/__webpack_require__.n(auth0_js__WEBPACK_IMPORTED_MODULE_4__);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





var AuthService = /** @class */ (function () {
    function AuthService(router) {
        this.router = router;
        this.auth0 = new auth0_js__WEBPACK_IMPORTED_MODULE_4__["WebAuth"]({
            clientID: _auth0_variables__WEBPACK_IMPORTED_MODULE_1__["AUTH_CONFIG"].clientID,
            domain: _auth0_variables__WEBPACK_IMPORTED_MODULE_1__["AUTH_CONFIG"].domain,
            responseType: 'token id_token',
            audience: _auth0_variables__WEBPACK_IMPORTED_MODULE_1__["AUTH_CONFIG"].apiUrl,
            redirectUri: _auth0_variables__WEBPACK_IMPORTED_MODULE_1__["AUTH_CONFIG"].callbackURL,
            scope: 'openid email offline_access profile read:content manage:content'
        });
    }
    AuthService.prototype.login = function () {
        this.auth0.authorize();
    };
    AuthService.prototype.handleAuthentication = function () {
        var _this = this;
        this.auth0.parseHash(function (err, authResult) {
            console.log(err);
            console.log(authResult);
            if (authResult && authResult.accessToken && authResult.idToken) {
                _this.setSession(authResult);
                _this.router.navigate(['/home']);
            }
            else if (err) {
                _this.router.navigate(['/home']);
                console.log(err);
            }
        });
    };
    AuthService.prototype.getProfile = function (cb) {
        var accessToken = localStorage.getItem('access_token');
        console.log(accessToken);
        console.log(JSON.parse(localStorage.getItem("authresult")));
        if (!accessToken) {
            throw new Error('Access token must exist to fetch profile');
        }
        var self = this;
        this.auth0.client.userInfo(accessToken, function (err, profile) {
            if (profile) {
                self.userProfile = profile;
            }
            cb(err, profile);
        });
    };
    AuthService.prototype.setSession = function (authResult) {
        // Set the time that the access token will expire at
        localStorage.setItem("authresult", JSON.stringify(authResult));
        var expiresAt = JSON.stringify((authResult.expiresIn * 1000) + new Date().getTime());
        localStorage.setItem('access_token', authResult.accessToken);
        localStorage.setItem('id_token', authResult.idToken);
        localStorage.setItem('expires_at', expiresAt);
    };
    AuthService.prototype.logout = function () {
        // Remove tokens and expiry time from localStorage
        localStorage.removeItem('access_token');
        localStorage.removeItem('id_token');
        localStorage.removeItem('expires_at');
        // Go back to the home route
        this.router.navigate(['/']);
    };
    AuthService.prototype.isAuthenticated = function () {
        // Check whether the current time is past the
        // access token's expiry time
        var expiresAt = JSON.parse(localStorage.getItem('expires_at'));
        return new Date().getTime() < expiresAt;
    };
    AuthService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])(),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_2__["Router"]])
    ], AuthService);
    return AuthService;
}());



/***/ }),

/***/ "./src/app/auth/auth0-variables.ts":
/*!*****************************************!*\
  !*** ./src/app/auth/auth0-variables.ts ***!
  \*****************************************/
/*! exports provided: AUTH_CONFIG */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AUTH_CONFIG", function() { return AUTH_CONFIG; });
var AUTH_CONFIG = {
    clientID: 'dYHFgoTMjfseGRjW6fjMV9hmF2Ko0QiT',
    domain: 'cmscore-prod.eu.auth0.com',
    callbackURL: 'http://localhost:3000/callback',
    apiUrl: 'http://localhost:50467/api'
};


/***/ }),

/***/ "./src/app/callback/callback.component.css":
/*!*************************************************!*\
  !*** ./src/app/callback/callback.component.css ***!
  \*************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".loading {\n  position: absolute;\n  display: flex;\n  justify-content: center;\n  height: 100vh;\n  width: 100vw;\n  top: 0;\n  bottom: 0;\n  left: 0;\n  right: 0;\n  background-color: #fff;\n}"

/***/ }),

/***/ "./src/app/callback/callback.component.html":
/*!**************************************************!*\
  !*** ./src/app/callback/callback.component.html ***!
  \**************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"loading\">\n  <img src=\"assets/loading.svg\" alt=\"loading\">\n</div>\n"

/***/ }),

/***/ "./src/app/callback/callback.component.ts":
/*!************************************************!*\
  !*** ./src/app/callback/callback.component.ts ***!
  \************************************************/
/*! exports provided: CallbackComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CallbackComponent", function() { return CallbackComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var CallbackComponent = /** @class */ (function () {
    function CallbackComponent() {
    }
    CallbackComponent.prototype.ngOnInit = function () {
    };
    CallbackComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-callback',
            template: __webpack_require__(/*! ./callback.component.html */ "./src/app/callback/callback.component.html"),
            styles: [__webpack_require__(/*! ./callback.component.css */ "./src/app/callback/callback.component.css")]
        }),
        __metadata("design:paramtypes", [])
    ], CallbackComponent);
    return CallbackComponent;
}());



/***/ }),

/***/ "./src/app/feeditem/feeditem.component.css":
/*!*************************************************!*\
  !*** ./src/app/feeditem/feeditem.component.css ***!
  \*************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".example-form {\r\n  min-width: 150px;\r\n  max-width: 500px;\r\n  width: 100%;\r\n}\r\n\r\n.form-input-full-width {\r\n  width: 100%;\r\n}\r\n"

/***/ }),

/***/ "./src/app/feeditem/feeditem.component.html":
/*!**************************************************!*\
  !*** ./src/app/feeditem/feeditem.component.html ***!
  \**************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<mat-card *ngIf=\"feedItem\">\n  <mat-card-title>\n    {{feedItem.title}}\n  </mat-card-title>\n  <mat-card-subtitle>\n    {{feedItem.description}}\n  </mat-card-subtitle>\n  <mat-card-content>\n    {{feedItem.content}}\n  </mat-card-content>\n  <mat-chip-list>\n    <mat-chip *ngFor=\"let tag of feedItem.tags\">{{tag.name}}</mat-chip>\n  </mat-chip-list>\n\n</mat-card>\n\n<mat-card *ngIf=\"feedItem && feedItem.commentsEnabled\">\n\n  <mat-card-header>\n    <mat-card-title>Comments</mat-card-title>\n  </mat-card-header>\n  <mat-card-content>\n    <mat-accordion>\n      <mat-expansion-panel>\n        <mat-expansion-panel-header>\n          <mat-panel-title>\n            Leave a comment\n          </mat-panel-title>\n        </mat-expansion-panel-header>\n        <form class=\"example-form\" fxLayout=\"column\">\n\n          <div fxFlex>\n            <mat-form-field class=\"form-input-full-width\">\n              <textarea matInput placeholder=\"Leave a comment\" [formControl]=\"text\" required [(ngModel)]=\"comment.text\"></textarea>\n            </mat-form-field>\n          </div>\n\n          <div fxFlex>\n            <mat-form-field class=\"form-input-full-width\">\n              <input matInput placeholder=\"Enter your email\" [formControl]=\"email\" required [(ngModel)]=\"comment.fullName\">\n              <mat-error *ngIf=\"email.invalid\">{{getErrorMessage()}}</mat-error>\n            </mat-form-field>\n          </div>\n          <div fxFlex>\n            <button mat-raised-button [disabled]=\"text.invalid || email.invalid\" (click)=\"submitComment()\">Submit</button>\n          </div>\n        </form>\n\n      </mat-expansion-panel>\n    </mat-accordion>\n  </mat-card-content>\n  <div *ngIf=\"feedItem?.comments\">\n    <mat-card class=\"example-card\" *ngFor=\"let comment of feedItem?.comments\" style=\"padding: 5px;\">\n      <mat-card-header>\n        <mat-card-title>{{comment.fullName}}</mat-card-title>\n        <mat-card-subtitle>\n          {{comment.text}}\n        </mat-card-subtitle>\n      </mat-card-header>\n    </mat-card>\n  </div>\n</mat-card>\n"

/***/ }),

/***/ "./src/app/feeditem/feeditem.component.ts":
/*!************************************************!*\
  !*** ./src/app/feeditem/feeditem.component.ts ***!
  \************************************************/
/*! exports provided: FeeditemComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "FeeditemComponent", function() { return FeeditemComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _services_content_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../services/content.service */ "./src/app/services/content.service.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var rxjs_add_operator_first__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs/add/operator/first */ "./node_modules/rxjs-compat/_esm5/add/operator/first.js");
/* harmony import */ var _angular_material__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/material */ "./node_modules/@angular/material/esm5/material.es5.js");
/* harmony import */ var _snackbar_snackbar_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../snackbar/snackbar.component */ "./src/app/snackbar/snackbar.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var FeeditemComponent = /** @class */ (function () {
    function FeeditemComponent(route, contentService, snackBar) {
        this.route = route;
        this.contentService = contentService;
        this.snackBar = snackBar;
        this.comment = new _services_content_service__WEBPACK_IMPORTED_MODULE_1__["CreateComment"]();
        this.email = new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormControl"]('', [_angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].required, _angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].email]);
        this.text = new _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormControl"]('', [_angular_forms__WEBPACK_IMPORTED_MODULE_3__["Validators"].required]);
    }
    FeeditemComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.sub = this.route.params.subscribe(function (params) {
            _this.feedItemId = params['id'];
            _this.getFeedItem();
        });
    };
    FeeditemComponent.prototype.getFeedItem = function () {
        var _this = this;
        this.contentService.feedItem(this.feedItemId).first().subscribe(function (p) { return _this.feedItem = p; });
    };
    FeeditemComponent.prototype.getErrorMessage = function () {
        return this.email.hasError('required') ? 'You must enter your email' :
            this.email.hasError('email') ? 'Not a valid email' :
                '';
    };
    FeeditemComponent.prototype.submitComment = function () {
        var _this = this;
        this.comment.feedItemId = this.feedItemId;
        this.contentService.submitComment(this.comment).first().subscribe(function (x) {
            _this.openSnackbar(x);
            _this.getFeedItem();
        }, function (error1) { return _this.openSnackbar(error1); });
    };
    FeeditemComponent.prototype.openSnackbar = function (data) {
        this.snackBar.openFromComponent(_snackbar_snackbar_component__WEBPACK_IMPORTED_MODULE_6__["SnackbarComponent"], {
            data: data, duration: 2500
        });
    };
    FeeditemComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-feeditem',
            template: __webpack_require__(/*! ./feeditem.component.html */ "./src/app/feeditem/feeditem.component.html"),
            styles: [__webpack_require__(/*! ./feeditem.component.css */ "./src/app/feeditem/feeditem.component.css")]
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_2__["ActivatedRoute"],
            _services_content_service__WEBPACK_IMPORTED_MODULE_1__["ContentService"],
            _angular_material__WEBPACK_IMPORTED_MODULE_5__["MatSnackBar"]])
    ], FeeditemComponent);
    return FeeditemComponent;
}());



/***/ }),

/***/ "./src/app/manage/manage.component.css":
/*!*********************************************!*\
  !*** ./src/app/manage/manage.component.css ***!
  \*********************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".grid-container {\n  margin: 20px;\n}\n\n.dashboard-card {\n  position: absolute;\n  top: 15px;\n  left: 15px;\n  right: 15px;\n  bottom: 15px;\n}\n\n.more-button {\n  position: absolute;\n  top: 5px;\n  right: 10px;\n}\n\n.dashboard-card-content {\n  text-align: center;\n}"

/***/ }),

/***/ "./src/app/manage/manage.component.html":
/*!**********************************************!*\
  !*** ./src/app/manage/manage.component.html ***!
  \**********************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"grid-container\">\n  <h1 class=\"mat-h1\">Dashboard</h1>\n\n  <mat-tab-group>\n    <mat-tab label=\"Page\">\n\n    </mat-tab>\n    <mat-tab label=\"Tab 2\">Content 2</mat-tab>\n  </mat-tab-group>\n\n</div>\n"

/***/ }),

/***/ "./src/app/manage/manage.component.ts":
/*!********************************************!*\
  !*** ./src/app/manage/manage.component.ts ***!
  \********************************************/
/*! exports provided: ManageComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ManageComponent", function() { return ManageComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _services_content_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../services/content.service */ "./src/app/services/content.service.ts");
/* harmony import */ var _angular_material__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/material */ "./node_modules/@angular/material/esm5/material.es5.js");
/* harmony import */ var _snackbar_snackbar_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../snackbar/snackbar.component */ "./src/app/snackbar/snackbar.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var ManageComponent = /** @class */ (function () {
    function ManageComponent(contentService, snackBar) {
        this.contentService = contentService;
        this.snackBar = snackBar;
        this.page = new _services_content_service__WEBPACK_IMPORTED_MODULE_1__["CreatePage"]();
    }
    ManageComponent.prototype.openSnackbar = function (data) {
        this.snackBar.openFromComponent(_snackbar_snackbar_component__WEBPACK_IMPORTED_MODULE_3__["SnackbarComponent"], {
            data: data, duration: 2500
        });
    };
    ManageComponent.prototype.createPage = function () {
        var _this = this;
        this.contentService.createPage(this.page).first().subscribe(function (x) {
            _this.openSnackbar(x);
        }, function (error1) { return _this.openSnackbar(error1); });
    };
    ManageComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'manage',
            template: __webpack_require__(/*! ./manage.component.html */ "./src/app/manage/manage.component.html"),
            styles: [__webpack_require__(/*! ./manage.component.css */ "./src/app/manage/manage.component.css")]
        }),
        __metadata("design:paramtypes", [_services_content_service__WEBPACK_IMPORTED_MODULE_1__["ContentService"],
            _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatSnackBar"]])
    ], ManageComponent);
    return ManageComponent;
}());



/***/ }),

/***/ "./src/app/manage/page/manage-page/manage-page.component.css":
/*!*******************************************************************!*\
  !*** ./src/app/manage/page/manage-page/manage-page.component.css ***!
  \*******************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/manage/page/manage-page/manage-page.component.html":
/*!********************************************************************!*\
  !*** ./src/app/manage/page/manage-page/manage-page.component.html ***!
  \********************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<p>\n  manage-page works!\n</p>\n"

/***/ }),

/***/ "./src/app/manage/page/manage-page/manage-page.component.ts":
/*!******************************************************************!*\
  !*** ./src/app/manage/page/manage-page/manage-page.component.ts ***!
  \******************************************************************/
/*! exports provided: ManagePageComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ManagePageComponent", function() { return ManagePageComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var ManagePageComponent = /** @class */ (function () {
    function ManagePageComponent() {
    }
    ManagePageComponent.prototype.ngOnInit = function () {
    };
    ManagePageComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-manage-page',
            template: __webpack_require__(/*! ./manage-page.component.html */ "./src/app/manage/page/manage-page/manage-page.component.html"),
            styles: [__webpack_require__(/*! ./manage-page.component.css */ "./src/app/manage/page/manage-page/manage-page.component.css")]
        }),
        __metadata("design:paramtypes", [])
    ], ManagePageComponent);
    return ManagePageComponent;
}());



/***/ }),

/***/ "./src/app/navigation/navigation.component.css":
/*!*****************************************************!*\
  !*** ./src/app/navigation/navigation.component.css ***!
  \*****************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".sidenav-container {\n  height: 100%;\n}\n\n.sidenav {\n  width: 200px;\n  box-shadow: 3px 0 6px rgba(0,0,0,.24);\n}\n"

/***/ }),

/***/ "./src/app/navigation/navigation.component.html":
/*!******************************************************!*\
  !*** ./src/app/navigation/navigation.component.html ***!
  \******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<mat-sidenav-container class=\"sidenav-container\">\n  <mat-sidenav\n    #drawer\n    class=\"sidenav\"\n    fixedInViewport=\"true\"\n    [attr.role]=\"isHandset ? 'dialog' : 'navigation'\"\n    [mode]=\"(isHandset | async)!.matches ? 'over' : 'side'\"\n    [opened]=\"!(isHandset | async)!.matches\">\n    <mat-toolbar color=\"primary\">Menu</mat-toolbar>\n    <mat-nav-list>\n      <a *ngFor=\"let page of pageTree | async\" mat-list-item routerLink=\"/page/{{page.entityId}}\">{{page.name}}</a>\n    </mat-nav-list>\n  </mat-sidenav>\n  <mat-sidenav-content>\n    <mat-toolbar color=\"primary\">\n      <button\n        type=\"button\"\n        aria-label=\"Toggle sidenav\"\n        mat-icon-button\n        (click)=\"drawer.toggle()\"\n        *ngIf=\"(isHandset | async)!.matches\">\n        <mat-icon aria-label=\"Side nav toggle icon\">menu</mat-icon>\n      </button>\n      <span>Application Title</span>\n      <a *ngIf=\"auth.isAuthenticated()\" routerLink=\"/manage\"> Manage</a>\n      <a *ngIf=\"!auth.isAuthenticated()\" (click)=\"auth.login()\">Log In</a>\n    </mat-toolbar>\n  </mat-sidenav-content>\n</mat-sidenav-container>\n"

/***/ }),

/***/ "./src/app/navigation/navigation.component.ts":
/*!****************************************************!*\
  !*** ./src/app/navigation/navigation.component.ts ***!
  \****************************************************/
/*! exports provided: NavigationComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "NavigationComponent", function() { return NavigationComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_cdk_layout__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/cdk/layout */ "./node_modules/@angular/cdk/esm5/layout.es5.js");
/* harmony import */ var _services_content_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../services/content.service */ "./src/app/services/content.service.ts");
/* harmony import */ var _auth_auth_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../auth/auth.service */ "./src/app/auth/auth.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var NavigationComponent = /** @class */ (function () {
    function NavigationComponent(breakpointObserver, auth, contentService) {
        this.breakpointObserver = breakpointObserver;
        this.auth = auth;
        this.contentService = contentService;
        this.isHandset = this.breakpointObserver.observe(_angular_cdk_layout__WEBPACK_IMPORTED_MODULE_1__["Breakpoints"].Handset);
    }
    NavigationComponent.prototype.ngOnInit = function () {
        this.pageTree = this.contentService.pageTree();
    };
    NavigationComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'navigation',
            template: __webpack_require__(/*! ./navigation.component.html */ "./src/app/navigation/navigation.component.html"),
            styles: [__webpack_require__(/*! ./navigation.component.css */ "./src/app/navigation/navigation.component.css")]
        }),
        __metadata("design:paramtypes", [_angular_cdk_layout__WEBPACK_IMPORTED_MODULE_1__["BreakpointObserver"],
            _auth_auth_service__WEBPACK_IMPORTED_MODULE_3__["AuthService"],
            _services_content_service__WEBPACK_IMPORTED_MODULE_2__["ContentService"]])
    ], NavigationComponent);
    return NavigationComponent;
}());



/***/ }),

/***/ "./src/app/page/page.component.css":
/*!*****************************************!*\
  !*** ./src/app/page/page.component.css ***!
  \*****************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/page/page.component.html":
/*!******************************************!*\
  !*** ./src/app/page/page.component.html ***!
  \******************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<mat-card>\n  <mat-card-title>\n    {{page?.name}}\n  </mat-card-title>\n  <mat-card-subtitle>\n    {{page?.date}}\n  </mat-card-subtitle>\n\n  <mat-card-content>\n    {{page?.content}}\n  </mat-card-content>\n\n  <mat-card *ngFor=\"let feedItem of page?.feed?.feedItems\">\n    <mat-card-title>\n      <button mat-button routerLink=\"/feeditem/{{feedItem.entityId}}\" style=\"width: 100%\"> {{feedItem?.title}}</button>\n    </mat-card-title>\n    <mat-card-subtitle>\n      {{feedItem?.description}}\n    </mat-card-subtitle>\n    <p> {{feedItem?.date}}</p>\n\n    <mat-chip-list>\n      <mat-chip *ngFor=\"let tag of feedItem.tags\">{{tag.name}}</mat-chip>\n    </mat-chip-list>\n  </mat-card>\n</mat-card>\n"

/***/ }),

/***/ "./src/app/page/page.component.ts":
/*!****************************************!*\
  !*** ./src/app/page/page.component.ts ***!
  \****************************************/
/*! exports provided: PageComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PageComponent", function() { return PageComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _services_content_service__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../services/content.service */ "./src/app/services/content.service.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var rxjs_operator__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operator */ "./node_modules/rxjs/operator.js");
/* harmony import */ var rxjs_operator__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(rxjs_operator__WEBPACK_IMPORTED_MODULE_3__);
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var PageComponent = /** @class */ (function () {
    function PageComponent(route, contentService) {
        this.route = route;
        this.contentService = contentService;
    }
    PageComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.sub = this.route.params.subscribe(function (params) {
            _this.pageId = params['id'];
            _this.contentService.page(_this.pageId).subscribe(function (p) { return _this.page = p; });
        });
    };
    PageComponent.prototype.ngOnDestroy = function () {
        this.sub.unsubscribe();
    };
    PageComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-page',
            template: __webpack_require__(/*! ./page.component.html */ "./src/app/page/page.component.html"),
            styles: [__webpack_require__(/*! ./page.component.css */ "./src/app/page/page.component.css")]
        }),
        __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_2__["ActivatedRoute"],
            _services_content_service__WEBPACK_IMPORTED_MODULE_1__["ContentService"]])
    ], PageComponent);
    return PageComponent;
}());



/***/ }),

/***/ "./src/app/services/content.service.ts":
/*!*********************************************!*\
  !*** ./src/app/services/content.service.ts ***!
  \*********************************************/
/*! exports provided: ContentService, contentBaseUrl, createContentBaseUrl, ContentEndpoint, CreateContentEndpoint, CreateComment, CreatePage */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ContentService", function() { return ContentService; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "contentBaseUrl", function() { return contentBaseUrl; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "createContentBaseUrl", function() { return createContentBaseUrl; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ContentEndpoint", function() { return ContentEndpoint; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CreateContentEndpoint", function() { return CreateContentEndpoint; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CreateComment", function() { return CreateComment; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CreatePage", function() { return CreatePage; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var ContentService = /** @class */ (function () {
    function ContentService(httpClient) {
        this.httpClient = httpClient;
        this._headers = new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpHeaders"]().set('Content-Type', 'application/json');
    }
    ContentService.prototype.get = function (url) {
        return this.httpClient.get(url);
    };
    ContentService.prototype.pageTree = function () {
        return this.httpClient.get(ContentEndpoint.pageTree);
    };
    ContentService.prototype.page = function (id) {
        return this.httpClient.get(ContentEndpoint.pageById(id));
    };
    ContentService.prototype.feedItem = function (id) {
        return this.httpClient.get(ContentEndpoint.feedItemById(id));
    };
    ContentService.prototype.submitComment = function (comment) {
        return this.httpClient.post(CreateContentEndpoint.comment, comment);
    };
    ContentService.prototype.createPage = function (page) {
        return this.httpClient.post(CreateContentEndpoint.page, page, { headers: this.authHeaders() });
    };
    ContentService.prototype.createFeedItem = function (feedItem) {
        return this.httpClient.post(CreateContentEndpoint.feedItem, feedItem, { headers: this.authHeaders() });
    };
    ContentService.prototype.authHeaders = function () {
        var headers = new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpHeaders"]().set('Content-Type', 'application/json');
        var accessToken = localStorage.getItem('access_token');
        headers.append("Authorization", "Bearer " + accessToken);
        return headers;
    };
    ContentService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({
            providedIn: "root"
        }),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]])
    ], ContentService);
    return ContentService;
}());

var contentBaseUrl = "http://localhost:5000/api/content/";
var createContentBaseUrl = "http://localhost:5000/api/content/create/";
var ContentEndpoint = {
    pageTree: contentBaseUrl,
    pageById: function (id) { return contentBaseUrl + "page/" + id; },
    feedItemById: function (id) { return contentBaseUrl + "feeditem/" + id; }
};
var CreateContentEndpoint = {
    comment: createContentBaseUrl + "comment",
    page: createContentBaseUrl + "page",
    feedItem: createContentBaseUrl + "feedItem",
    feed: createContentBaseUrl + "feed",
};
var CreateComment = /** @class */ (function () {
    function CreateComment() {
        this.fullName = '';
        this.text = '';
    }
    return CreateComment;
}());

var CreatePage = /** @class */ (function () {
    function CreatePage() {
    }
    return CreatePage;
}());



/***/ }),

/***/ "./src/app/snackbar/snackbar.component.ts":
/*!************************************************!*\
  !*** ./src/app/snackbar/snackbar.component.ts ***!
  \************************************************/
/*! exports provided: SnackbarComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "SnackbarComponent", function() { return SnackbarComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_material__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/material */ "./node_modules/@angular/material/esm5/material.es5.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (undefined && undefined.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};


var SnackbarComponent = /** @class */ (function () {
    function SnackbarComponent(data) {
        this.data = data;
    }
    SnackbarComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'snack-bar',
            template: ' Successful: {{data?.successful}} Message: {{ data?.message }}',
        }),
        __param(0, Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Inject"])(_angular_material__WEBPACK_IMPORTED_MODULE_1__["MAT_SNACK_BAR_DATA"])),
        __metadata("design:paramtypes", [Object])
    ], SnackbarComponent);
    return SnackbarComponent;
}());



/***/ }),

/***/ "./src/environments/environment.ts":
/*!*****************************************!*\
  !*** ./src/environments/environment.ts ***!
  \*****************************************/
/*! exports provided: environment */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "environment", function() { return environment; });
// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
var environment = {
    production: false
};
/*
 * In development mode, to ignore zone related error stack frames such as
 * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
 * import the following file, but please comment it out in production mode
 * because it will have performance impact when throw error
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.


/***/ }),

/***/ "./src/main.ts":
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/platform-browser-dynamic */ "./node_modules/@angular/platform-browser-dynamic/fesm5/platform-browser-dynamic.js");
/* harmony import */ var _app_app_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./app/app.module */ "./src/app/app.module.ts");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./environments/environment */ "./src/environments/environment.ts");




if (_environments_environment__WEBPACK_IMPORTED_MODULE_3__["environment"].production) {
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["enableProdMode"])();
}
Object(_angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__["platformBrowserDynamic"])().bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_2__["AppModule"])
    .catch(function (err) { return console.log(err); });


/***/ }),

/***/ 0:
/*!***************************!*\
  !*** multi ./src/main.ts ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! C:\Users\dev.emil.sodergren\Documents\Examensarbete\Labb\CMSCore.Content\CMSCore.Content.Client\ClientApp\src\main.ts */"./src/main.ts");


/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main.js.map