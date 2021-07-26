import { AlertService } from "./../../services/alert.service";
import { BooksService } from "./../../services/books.service";
import {
  ChangeDetectionStrategy,
  Component,
  OnDestroy,
  OnInit,
} from "@angular/core";
import { switchMap, take, takeUntil } from "rxjs/operators";
import { Book } from "src/app/models/book.model";
import { BehaviorSubject, Observable, Subject } from "rxjs";

@Component({
  selector: "app-books",
  templateUrl: "./books.component.html",
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class BooksComponent implements OnInit, OnDestroy {
  public books$: Observable<Array<Book>>;
  private refreshToken$ = new BehaviorSubject<boolean>(undefined);
  private destroySubject$ = new Subject();
  constructor(
    private readonly booksService: BooksService,
    private readonly alertService: AlertService
  ) {}

  ngOnDestroy(): void {
    this.destroySubject$.unsubscribe();
  }

  public ngOnInit(): void {
    this.books$ = this.refreshToken$.pipe(
      switchMap(() => this.booksService.getAll()),
      takeUntil(this.destroySubject$)
    );
  }

  public delete(book: Book): void {
    if (confirm(`Are you sure you want to delete '${book.title}'?`)) {
      this.booksService
        .delete(book.id)
        .pipe(take(1))
        .subscribe({
          next: () => {
            this.alertService.success("Book deleted");
            this.refreshToken$.next(undefined);
          },
          error: (error) => {
            this.alertService.error(error);
          },
        });
    }
  }

  public trackByFn(index: number, item: Book) {
    return item.modifiedUtc;
  }
}
