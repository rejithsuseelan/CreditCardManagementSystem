import {
  Component,
  OnInit,
  TemplateRef,
  ViewChild,
  ViewEncapsulation,
} from "@angular/core";
import { MatDialog } from "@angular/material";
import { CHttpClient } from "src/app/http/http.client";

@Component({
  selector: "app-applied-card",
  templateUrl: "./applied-card.component.html",
  styleUrls: ["./applied-card.component.css"],
  encapsulation: ViewEncapsulation.None,
})
export class AppliedCardComponent implements OnInit {
  @ViewChild("courierDialog") courierDialog: TemplateRef<any>;

  creditCardList = [];
  TrackingNumber: string;
  CourierName: string;

  displayedColumns: string[] = [
    "applicationId",
    "firstName",
    "fatherName",
    "cardName",
    "pancard",
    "annualIncome",
    "cardStatus",
    "trackingNumber",
    "action",
  ];

  constructor(private httpClient: CHttpClient, private dialog: MatDialog) {}

  ngOnInit() {
    this.getApplications();
  }

  getApplications() {
    this.httpClient
      .get("api/Application/GetApplications")
      .subscribe((resData) => {
        if (resData.length > 0) {
          this.creditCardList = resData;
        } else {
          console.log("Failure");
        }
      });
  }

  UpdateApplicationStatus(applicationId, statusId) {
    let params = { applicationId, CardStatus: statusId };
    this.httpClient
      .post("api/Application/UpdateApplicationStatus", params)
      .subscribe((resData) => {
        this.getApplications();
      });
  }

  callAPI(applicationId, statusId) {
    let dialogRef = this.dialog.open(this.courierDialog, {
      width: "600px",
      height: "300px",
      panelClass: "dialogC",
      disableClose: true,
    });
    dialogRef.afterClosed().subscribe((result) => {
      if (result !== undefined) {
        if (result === "yes") {
          let params = {
            applicationId,
            courierName: this.CourierName,
            trackingNumber: this.TrackingNumber,
            CardStatus: statusId,
          };
          this.httpClient
            .post("api/Application/UpdateConsignmentStatus", params)
            .subscribe((resData) => {
              this.getApplications();
            });
          this.dialog.closeAll();
        } else if (result === "no") {
          this.dialog.closeAll();
        }
      }
    });
  }

  consignmentUpdate(applicationId, statusId) {
    let params = {
      applicationId,
      StatusId: statusId,
    };
    this.httpClient
      .post("api/Application/CourierLog", params)
      .subscribe((resData) => {
        this.getApplications();
      });
  }
}
