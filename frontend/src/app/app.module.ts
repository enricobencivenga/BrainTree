import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NgxBraintreeModule } from 'projects/ngx-braintree/src/public_api';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    NgxBraintreeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
