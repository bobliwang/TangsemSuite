import { Route } from "@angular/router";

export interface ExtendedRoute extends Route {
    hideFromMenuItem?: boolean;
}