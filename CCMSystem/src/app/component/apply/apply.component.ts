import {
  Component,
  OnInit,
  TemplateRef,
  ViewChild,
  ViewEncapsulation,
} from "@angular/core";
import { MatDialog } from "@angular/material";
import { ActivatedRoute, Router } from "@angular/router";
import { CHttpClient } from "src/app/http/http.client";
import { CreditCardsService } from "../service/creditcards.service";

@Component({
  selector: "app-apply",
  templateUrl: "./apply.component.html",
  styleUrls: ["./apply.component.css"],
  encapsulation: ViewEncapsulation.None,
})
export class CreditCardApplyComponent implements OnInit {
  card = null;
  id;
  applicationNumber: number;
  @ViewChild("courierDialog") courierDialog: TemplateRef<any>;

  creditCard: CreditCardDTO;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private dialog: MatDialog,
    private httpClient: CHttpClient,
    private cardsService: CreditCardsService
  ) {
    this.route.params.subscribe((params) => {
      this.id = +params["id"];
    });
  }

  ngOnInit() {
    this.creditCard = new CreditCardDTO();
    this.card = this.cardsService.lstCreditCard.filter(
      (x) => x.id == this.id
    )[0];
  }

  SubmitApplication() {
    this.creditCard.cardName = this.card.Name;
    this.creditCard.cardStatus = 12;
    this.httpClient
      .post("api/Application/AddApplication", this.creditCard)
      .subscribe((resData) => {
        if (resData > 0) {
          this.applicationNumber = resData;
          this.ShowApplicationId();
          console.log("success");
        } else {
          console.log("Failure");
        }
      });
  }

  ShowApplicationId() {
    let dialogRef = this.dialog.open(this.courierDialog, {
      width: "500px",
      height: "230px",
      panelClass: "dialogC",
      disableClose: true,
    });
    dialogRef.afterClosed().subscribe((result) => {
      this.creditCard = new CreditCardDTO();
      this.applicationNumber = null;
    });
  }
}

export class CreditCardDTO {
  emailId: string;
  mobileNumber: string;
  firstName: string;
  lastName: string;
  fatherName: string;
  fatherLastName: string;
  dateOfBirth: string;
  maritalStatus: number;
  citizenship: number;
  pancard: string;
  profession: number;
  companyName: string;
  designation: string;
  annualIncome: string;
  monthlyIncome: string;
  corporateEmailId: string;
  area: string;
  houseNo: string;
  street: string;
  landmark: string;
  city: string;
  pincode: string;
  isTermsAndCondition: boolean;
  cardName: string;
  cardStatus: number;
  trackingNumber: string;
  courierLogs: any;
}
