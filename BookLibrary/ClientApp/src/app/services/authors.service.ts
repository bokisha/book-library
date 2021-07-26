import { SelectItemById } from "./../models/select-item-by-id";
import { Inject, Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { shareReplay, take } from "rxjs/operators";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class AuthorsService {
  private readonly authorsApiUrl = this.baseUrl + "api/authors";
  private cache$: Observable<Array<SelectItemById>>;
  constructor(
    private readonly http: HttpClient,
    @Inject("BASE_URL") private readonly baseUrl: string,
    @Inject("CACHE_SIZE") private readonly cacheSize: number
  ) {}

  public get authors(): Observable<Array<SelectItemById>> {
   if (!this.cache$) {
     this.cache$ = this.requestAuthors().pipe(shareReplay(this.cacheSize));
   }

    return this.cache$;
  }

  private requestAuthors() {
    return this.http.get<Array<SelectItemById>>(this.authorsApiUrl);
  }
}
