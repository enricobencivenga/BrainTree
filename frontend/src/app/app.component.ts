import { Component } from '@angular/core';
import { Observable, of } from 'rxjs';
import { NgxBraintreeService } from 'projects/ngx-braintree/src/public_api';
import { AppSettings } from './app.settings';

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"]
})
export class AppComponent {
  paymentResponse: any;
  chargeAmount = 11.11;
  
  clientTokenURL =  AppSettings.GET_CLIENT_TOKEN_URL;
  createPurchaseURL =  AppSettings.CREATE_PURCHASE_URL;
  
  onDropinLoaded(event) {
    console.log("dropin loaded...");
  }

  onPaymentStatus(response): void {
    this.paymentResponse = response;
  }
}
