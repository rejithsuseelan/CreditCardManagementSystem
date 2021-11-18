import { Component, OnInit } from "@angular/core";
import { CHttpClient } from "src/app/http/http.client";
import { CreditCardDTO } from "../apply/apply.component";

@Component({
  selector: "app-check-application-status",
  templateUrl: "./check-application-status.component.html",
  styleUrls: ["./check-application-status.component.css"],
})
export class CheckApplicationStatusComponent implements OnInit {
  Search: string = "";
  creditCard: any;
  isNotFound: boolean = false;
  timeLine: any;

  constructor(private httpClient: CHttpClient) {
    this.timeLine = [];
  }

  ngOnInit() {}

  getApplicationById() {
    this.httpClient
      .get("api/Application/GetApplicationById", { Id: this.Search })
      .subscribe((resData) => {
        if (resData != null) {
          this.Search = "";
          this.creditCard = resData;
          this.timeLine = this.creditCard.courierLogs;
          this.isNotFound = false;
        } else {
          this.isNotFound = true;
        }
      });
  }
}
