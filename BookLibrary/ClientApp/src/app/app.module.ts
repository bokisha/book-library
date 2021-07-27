import { BookDetailsComponent } from "./components/book-details/book-details.component";
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./components/nav-menu/nav-menu.component";
import { BooksComponent } from "./components/books/books.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MatButtonModule } from "@angular/material";
import { AlertComponent } from "./components/alert/alert.component";
import { TruncatePipe } from './pipes/truncate.pipe';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    BooksComponent,
    BookDetailsComponent,
    AlertComponent,
    TruncatePipe,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      {
        path: "books",
        children: [
          {
            path: "",
            component: BooksComponent,
          },
          {
            path: "edit/:id",
            component: BookDetailsComponent,
          },
          {
            path: "add",
            component: BookDetailsComponent,
          },
        ],
      },
      {
        path: "**",
        redirectTo: "books",
      },
    ]),
    BrowserAnimationsModule,
    MatButtonModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
