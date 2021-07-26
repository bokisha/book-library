import { AlertService } from "./../../services/alert.service";
import { BooksService } from "./../../services/books.service";
import { GenreService } from "./../../services/genre.service";
import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { finalize, take } from "rxjs/operators";
import { AuthorsService } from "src/app/services/authors.service";
import { forkJoin, Observable } from "rxjs";
import { Book } from "src/app/models/book.model";
import { SelectItemById } from "src/app/models/select-item-by-id";

@Component({
  selector: "app-book-details",
  templateUrl: "./book-details.component.html",
  styleUrls: ["./book-details.component.css"],
})
export class BookDetailsComponent implements OnInit {
  public id: number;
  isAddMode: boolean;
  form: FormGroup;
  loading = false;
  saving = false;
  submitted = false;

  constructor(
    private readonly route: ActivatedRoute,
    private readonly router: Router,
    private readonly formBuilder: FormBuilder,
    public readonly genreService: GenreService,
    public readonly authorsService: AuthorsService,
    private readonly bookService: BooksService,
    private readonly alertService: AlertService
  ) {}

  ngOnInit() {
    this.loading = true;
    this.id = parseInt(this.route.snapshot.params["id"]);
    this.isAddMode = !this.id;
    let observables: (Observable<SelectItemById[]> | Observable<Book>)[] = [
      this.genreService.genres,
      this.authorsService.authors,
    ];

    if (!this.isAddMode) {
      observables.push(this.bookService.getById(this.id));
    }

    forkJoin(observables)
      .pipe(
        take(1),
        finalize(() => (this.loading = false))
      )
      .subscribe({
        next: (values) => {
          this.form = this.formBuilder.group({
            title: [""],
            description: [""],
            genre: [values[0][0].value, Validators.required],
            authorId: [values[1][0].value, Validators.required],
          });

          if (!this.isAddMode) {
            this.form.patchValue(values[2]);
          }
        },
        error: (error) => {
          this.alertService.error(error);
        },
      });
  }

  public get f() {
    return this.form.controls;
  }

  onSubmit() {
    this.submitted = true;
    if (this.form.invalid) {
      return;
    }

    this.saving = true;
    if (this.isAddMode) {
      this.bookService
        .create(this.form.value)
        .pipe(take(1))
        .subscribe({
          next: () => {
            this.alertService.success("Book added", {
              keepAfterRouteChange: true,
            });
            this.router.navigate(["../"], { relativeTo: this.route });
          },
          error: (error) => {
            this.alertService.error(error);
            this.saving = false;
          },
        });
    } else {
      this.bookService
        .update({ ...this.form.value, id: this.id })
        .pipe(take(1))
        .subscribe({
          next: () => {
            this.alertService.success("Book updated", {
              keepAfterRouteChange: true,
            });
            this.router.navigate(["../"], { relativeTo: this.route });
          },
          error: (error) => {
            this.alertService.error(error);
            this.saving = false;
          },
        });
    }
  }
}
