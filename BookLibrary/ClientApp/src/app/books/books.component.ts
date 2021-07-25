import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { take } from 'rxjs/operators';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './books.component.html'
})
export class BooksComponent implements OnInit {
  public books: Book[];
  constructor(private readonly http: HttpClient,
    @Inject('BASE_URL') private readonly baseUrl: string) {  }
  public ngOnInit(): void {
    this.fetchData();
  }

  private fetchData(): void {
    this.http.get<Book[]>(this.baseUrl + "api/" + 'books').subscribe(books => this.books = books);
  }

  public delete(book: Book): void {
    if (confirm(`Are you sure you want to delete '${book.title}'?`)) {
      this.http.delete(this.baseUrl + "api/books" + "/" + book.id).pipe(
        take(1)
      ).subscribe(
          () => this.fetchData()
      );
    }
  }

  public trackByFn(index: number, item: Book) {
    return item.id;
  }
}

interface Book {
  id: number;
  modifiedUtc: Date;
  title: string;
  description: string;
  genre: number;
  authorId: number;
}

