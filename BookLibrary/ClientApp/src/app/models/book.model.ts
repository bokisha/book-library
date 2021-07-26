export interface Book {
  id: number;
  modifiedUtc: Date;
  title: string;
  description: string;
  genre: number;
  genreString: string;
  authorId: number;
  authorString: string;
}
