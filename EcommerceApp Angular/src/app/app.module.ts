import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { HttpClientModule } from '@angular/common/http';
import { DecriptionComponent } from './decription/decription.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxSpinnerModule } from 'ngx-spinner';
import { RouterModule } from '@angular/router';
import { CategoryProductComponent } from './category-product/category-product.component';
import { RegisterComponent } from './register/register.component';
import { AddNewItemComponent } from './add-new-item/add-new-item.component';



@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HeaderComponent,
    FooterComponent,
    DecriptionComponent,
    CategoryProductComponent,
    RegisterComponent,
    AddNewItemComponent,

  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    NgbModule,
    BrowserAnimationsModule,
    NgxSpinnerModule,
    RouterModule.forRoot([
      {
        path: '',
        component: HeaderComponent
      },
      {
        path: 'register',
        component: RegisterComponent
      },
      {
        path: 'newPost',
        component: AddNewItemComponent
      },

      { path: 'category/:id', component: CategoryProductComponent },
      {
        path: 'product/:id',
        component: DecriptionComponent
      }

    ])


  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
