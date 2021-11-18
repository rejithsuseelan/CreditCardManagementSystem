import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { CreditCardsService } from '../service/creditcards.service';

@Component({
  selector: 'app-credit-card',
  templateUrl: './credit-card.component.html',
  styleUrls: ['./credit-card.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class CreditCardComponent implements OnInit {

  constructor(private router: Router, private cardsService: CreditCardsService) { }

  ngOnInit() {
  }

  selectCard(card) {
    this.cardsService.selectedCard = card;
    this.router.navigate(['credit-card/apply/' + card.id]);
  }

}
