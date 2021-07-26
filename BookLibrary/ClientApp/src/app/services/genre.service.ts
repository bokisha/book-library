import { SelectItemById } from "./../models/select-item-by-id";
import { Inject, Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { shareReplay } from "rxjs/operators";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class GenreService {
  private readonly genresApiUrl = this.baseUrl + "api/genres";
  private cache$: Observable<Array<SelectItemById>>;

  constructor(
    private readonly http: HttpClient,
    @Inject("BASE_URL") private readonly baseUrl: string,
    @Inject("CACHE_SIZE") private readonly cacheSize: number
  ) {}

  get genres(): Observable<Array<SelectItemById>> {
    if (!this.cache$) {
      this.cache$ = this.requestGenres().pipe(shareReplay(this.cacheSize));
    }

    return this.cache$;
  }

  private requestGenres() {
    return this.http.get<Array<SelectItemById>>(this.genresApiUrl);
  }
}
