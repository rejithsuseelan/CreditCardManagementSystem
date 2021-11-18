import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AppliedCardComponent } from "./component/applied-card/applied-card.component";
import { CreditCardApplyComponent } from "./component/apply/apply.component";
import { CheckApplicationStatusComponent } from "./component/check-application-status/check-application-status.component";
import { CreditCardComponent } from "./component/credit-card/credit-card.component";
import { LoginComponent } from "./component/login/login.component";

const appRoutes: Routes = [
  {
    path: "",
    component: CreditCardComponent,
  },
  {
    path: "dashboard",
    component: CreditCardComponent,
  },
  {
    path: "login",
    component: LoginComponent,
  },
  {
    path: "application-status",
    component: CheckApplicationStatusComponent,
  },
  {
    path: "applied-card",
    component: AppliedCardComponent,
  },
  {
    path: "credit-card/apply/:id",
    component: CreditCardApplyComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes, { useHash: false })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
