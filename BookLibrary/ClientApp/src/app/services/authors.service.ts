import { SelectItemById } from "./../models/select-item-by-id";
import { Inject, Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { take } from "rxjs/operators";

@Injectable({
  providedIn: "root",
})
export class AuthorsService {
  private readonly authorsApiUrl = this.baseUrl + "api/authors";
  public authors: SelectItemById[] = [];
  constructor(
    private readonly http: HttpClient,
    @Inject("BASE_URL") private readonly baseUrl: string
  ) {}

  public getAuthors(): void {
    this.http
      .get<SelectItemById[]>(this.authorsApiUrl)
      .pipe(take(1))
      .subscribe((authors) => (this.authors = authors));
  }
}
