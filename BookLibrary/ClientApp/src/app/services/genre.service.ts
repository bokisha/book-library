import { SelectItemById } from "./../models/select-item-by-id";
import { Inject, Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { take } from "rxjs/operators";

@Injectable({
  providedIn: "root",
})
export class GenreService {
  private readonly genresApiUrl = this.baseUrl + "api/genres";
  public genres: SelectItemById[] = [];
  constructor(
    private readonly http: HttpClient,
    @Inject("BASE_URL") private readonly baseUrl: string
  ) {}

  public getGenres(): void {
    this.http
      .get<SelectItemById[]>(this.genresApiUrl)
      .pipe(take(1))
      .subscribe((genres) => (this.genres = genres));
  }
}
