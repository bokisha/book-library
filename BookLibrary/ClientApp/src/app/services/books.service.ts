import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Book } from "../models/book.model";

@Injectable({
  providedIn: "root",
})
export class BooksService {
  private readonly bookApiUrl = this.baseUrl + "api/books";
  constructor(
    private readonly http: HttpClient,
    @Inject("BASE_URL") private readonly baseUrl: string
  ) {}

  public getAll(): Observable<Book[]> {
    return this.http.get<Book[]>(this.bookApiUrl);
  }

  public getById(bookId: number): Observable<Book> {
    return this.http.get<Book>(this.bookApiUrl + "/" + bookId);
  }

  public delete(bookId: number): Observable<number> {
    return this.http.delete<number>(this.bookApiUrl + "/" + bookId);
  }

  public create(book: Book) {
    return this.http.post(this.bookApiUrl, book);
  }
  public update(book: Book) {
    return this.http.put(this.bookApiUrl + "/" + book.id, book);
  }
}
