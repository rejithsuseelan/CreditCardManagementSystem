import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppComponent } from "./app.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import {
  MatButtonModule,
  MatCardModule,
  MatCheckboxModule,
  MatDatepickerModule,
  MatDialogModule,
  MatIconModule,
  MatInputModule,
  MatListModule,
  MatMenuModule,
  MatNativeDateModule,
  MatRadioModule,
  MatSelectModule,
  MatSidenavModule,
  MatTableModule,
  MatTabsModule,
  MatToolbarModule,
} from "@angular/material";
import { CreditCardComponent } from "./component/credit-card/credit-card.component";
import { AppRoutingModule } from "./app-routing.module";
import { CreditCardApplyComponent } from "./component/apply/apply.component";
import { CreditCardsService } from "./component/service/creditcards.service";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from "@angular/forms";
import { AppliedCardComponent } from "./component/applied-card/applied-card.component";
import { CheckApplicationStatusComponent } from "./component/check-application-status/check-application-status.component";
import { TimelineComponent } from "./component/timeline/timeline.component";
import { LoginComponent } from './component/login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    CreditCardComponent,
    CreditCardApplyComponent,
    AppliedCardComponent,
    CheckApplicationStatusComponent,
    TimelineComponent,
    LoginComponent,
  ],
  imports: [
    AppRoutingModule,
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,

    MatButtonModule,
    MatTabsModule,
    MatListModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatRadioModule,
    MatSelectModule,
    MatCheckboxModule,
    MatIconModule,
    MatToolbarModule,
    MatSidenavModule,
    MatToolbarModule,
    MatSidenavModule,
    MatCardModule,
    MatTableModule,
    MatMenuModule,
    MatDialogModule,
  ],
  providers: [CreditCardsService],
  bootstrap: [AppComponent],
})
export class AppModule {}
