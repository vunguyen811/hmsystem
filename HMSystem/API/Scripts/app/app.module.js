"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
///<reference path="../../typings/index.d.ts"/>
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var http_1 = require("@angular/http");
var router_1 = require("@angular/router");
var forms_1 = require("@angular/forms");
require("rxjs/Rx");
var app_component_1 = require("./components/app.component");
var home_component_1 = require("./components/home/home.component");
var lounge_list_component_1 = require("./components/lounge/lounge-list.component");
var lounge_detail_component_1 = require("./components/lounge/lounge-detail.component");
var place_list_component_1 = require("./components/explore/place-list.component");
var place_detail_component_1 = require("./components/explore/place-detail.component");
var app_routing_1 = require("./app.routing");
var app_service_1 = require("./services/app.service");
var AppModule = (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        core_1.NgModule({
            // directives, components, and pipes
            declarations: [
                app_component_1.AppComponent,
                home_component_1.HomeComponent,
                lounge_list_component_1.LoungeListComponent,
                lounge_detail_component_1.LoungeDetailComponent,
                place_list_component_1.PlaceListComponent,
                place_detail_component_1.PlaceDetailComponent
            ],
            // modules
            imports: [
                platform_browser_1.BrowserModule,
                http_1.HttpModule,
                forms_1.FormsModule,
                router_1.RouterModule,
                app_routing_1.AppRouting
            ],
            // providers
            providers: [
                app_service_1.AppService
            ],
            bootstrap: [
                app_component_1.AppComponent
            ]
        }), 
        __metadata('design:paramtypes', [])
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map