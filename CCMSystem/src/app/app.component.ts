import { Component, ViewEncapsulation } from "@angular/core";
import { Router } from "@angular/router";
import { CreditCardsService } from "./component/service/creditcards.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
})
export class AppComponent {
  title = "Credit Card Management System";

  constructor(
    private creditCardsService: CreditCardsService,
    private router: Router
  ) {
    this.creditCardsService.isLoggedIn =
      JSON.parse(JSON.stringify(sessionStorage.getItem("isLoginSuccess"))) ===
      "true"
        ? true
        : false;
  }

  logout() {
    this.creditCardsService.isLoggedIn = false;
    sessionStorage.removeItem("username");
    sessionStorage.removeItem("password");
    sessionStorage.removeItem("isLoginSuccess");
    this.router.navigate(["/dashboard"]);
  }
}
