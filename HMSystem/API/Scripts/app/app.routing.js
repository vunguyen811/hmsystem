"use strict";
var router_1 = require("@angular/router");
var home_component_1 = require("./components/home/home.component");
var lounge_detail_component_1 = require("./components/lounge/lounge-detail.component");
var place_detail_component_1 = require("./components/explore/place-detail.component");
var routes = [
    {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
    },
    {
        path: 'home',
        component: home_component_1.HomeComponent
    },
    {
        path: 'lounge/:id',
        component: lounge_detail_component_1.LoungeDetailComponent
    },
    {
        path: 'explore/:id',
        component: place_detail_component_1.PlaceDetailComponent
    }
];
exports.AppRoutingProviders = [];
exports.AppRouting = router_1.RouterModule.forRoot(routes);
//# sourceMappingURL=app.routing.js.map