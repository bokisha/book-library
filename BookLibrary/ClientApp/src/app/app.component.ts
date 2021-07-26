import { AuthorsService } from "./services/authors.service";
import { GenreService } from "./services/genre.service";
import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
})
export class AppComponent implements OnInit {
  constructor(
    private readonly genreService: GenreService,
    private readonly authorsService: AuthorsService
  ) {}

  ngOnInit(): void {
    this.genreService.getGenres();
    this.authorsService.getAuthors();
  }
  title = "app";
}
