import { Injectable } from '@angular/core';
import { Movie } from './movie';
import { Movies } from './movies.datasource';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MoviesService {

  constructor() { }
  getMovies(): Observable<Movie[]>{
    return of(Movies)
  }
}
