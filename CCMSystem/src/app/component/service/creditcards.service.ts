import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root",
})
export class CreditCardsService {
  public lstCreditCard = [];
  public selectedCard = null;
  public isLoggedIn: boolean = false;

  constructor(private http: HttpClient) {
    this.setValues();
  }

  private setValues() {
    this.lstCreditCard.push(
      {
        id: 1,
        imgSRC: "src/assets/Images/Card 1.png",
        cardHeader: "Citi Rewards Credit Card",
        Name: "Citi Rewards Card",
        BasicOffers: [
          "Earn 10X reward points at departmental and apparel stores (physical oronline)",
          "Earn minimum* 1 reward point for every ₹125 spent on the card",
          "Earn 300 bonus reward points on card purchases of over ₹30,000 in a month",
          "Redeem your reward points via SMS at over 700 outlets and e-shopping sites",
        ],
        Annualfee: "Rs 1000 + taxes",
      },
      {
        id: 2,
        imgSRC: "src/assets/Images/Card 2.png",
        cardHeader: "Citi Cash Back Credit Card",
        Name: "Citi Cash Back Card",
        BasicOffers: [
          "Earn 5% cashback* on phone, utility bills & movie ticket purchases",
          "Earn 0.5% cashback on all other spends",
          "Cashback is auto credited to statement in multiples of ₹500",
          "Your unredeemed cashback is evergreen, and never expires",
        ],
        Annualfee: "Rs 500 + taxes",
      },
      {
        id: 3,
        imgSRC: "src/assets/Images/Card 3.png",
        cardHeader: "IndianOil Citi Credit Card",
        Name: "Citi IndianOil Card",
        BasicOffers: [
          "Earn 4 Turbo points on every spend of ₹150 & a 1% fuel surcharge reversal at authorized IndianOil outlets",
          "Earn 2 Turbo points for every ₹150 spent on groceries andv supermarkets",
          "Earn 1 Turbo point for every ₹150 spent on other eligible spends",
          "Get welcome 250 Turbo Points on your first spend within 30 days of card issuance",
        ],
        Annualfee: "Rs 1000 + taxes",
      },
      {
        id: 4,
        imgSRC: "src/assets/Images/Card 4.png",
        cardHeader: "Citi PremierMiles Credit Card",
        Name: "Citi PremierMiles Card",
        BasicOffers: [
          "Earn 10,000 Miles with your first spend of ₹1,000 or more within 60 days",
          "Earn 10 Miles for every ₹100 spent on www.premiermiles.co.in website and on airline spends*",
          "Earn 4 miles for every ₹100 spent on other spends",
          "Get complimentary access to select airport lounges & freedom to choose from over 100 airlines to fly with",
        ],
        Annualfee: "Rs 3000 + taxes",
      },
      {
        id: 5,
        imgSRC: "src/assets/Images/Card 5.png",
        cardHeader: "Citi Prestige Credit Card",
        Name: "Citi Prestige Card",
        BasicOffers: [
          "Welcome gift of 2,500 bonus reward points* and benefits worth ₹10,000 from Taj Group or ITC Hotels, every year*",
          "Earn minimum* 1 reward point on every ₹100 spent - online and in-store",
          "Earn 2 reward points on International Spends for every ₹100 spent",
          "Enjoy unlimited, complimentary access to airport lounges around the world with Priority Pass™",
        ],
        Annualfee: "Rs 3500 + taxes",
      }
    );
  }
}
