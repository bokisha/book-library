import { BooksService } from "./../../services/books.service";
import { Component, Inject, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { take } from "rxjs/operators";
import { Book } from "src/app/models/book.model";

@Component({
  selector: "app-fetch-data",
  templateUrl: "./books.component.html",
})
export class BooksComponent implements OnInit {
  public books: Book[];
  constructor(private readonly booksService: BooksService) {}
  public ngOnInit(): void {
    this.fetchData();
  }

  private fetchData(): void {
    this.booksService
      .getAll()
      .pipe(take(1))
      .subscribe((books) => (this.books = books));
  }

  public delete(book: Book): void {
    if (confirm(`Are you sure you want to delete '${book.title}'?`)) {
     this.booksService.delete(book.id)
        .pipe(take(1))
        .subscribe(() => this.fetchData());
    }
  }

  public trackByFn(index: number, item: Book) {
    return item.id;
  }
}
