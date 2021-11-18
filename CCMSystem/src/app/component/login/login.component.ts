import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { CreditCardsService } from "../service/creditcards.service";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"],
})
export class LoginComponent implements OnInit {
  username: string;
  password: string;

  constructor(
    private router: Router,
    private creditCardsService: CreditCardsService
  ) {}

  ngOnInit() {}

  login() {
    if (this.username == "test" && this.password == "test") {
      sessionStorage.setItem("username", this.username);
      sessionStorage.setItem("password", this.password);
      sessionStorage.setItem("isLoginSuccess", "true");

      this.creditCardsService.isLoggedIn = true;

      this.router.navigate(["/applied-card"]);
    }
  }
}
