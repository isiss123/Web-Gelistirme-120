import { Injectable } from '@angular/core';
import { Movies } from './movies.datasource';

@Injectable({
  providedIn: 'root'
})
export class MoviesService {

  constructor() { }
  getMovies(){
    return Movies
  }
}
