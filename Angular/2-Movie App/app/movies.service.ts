import { Injectable } from '@angular/core';
import { Movie } from './movie';
import { Movies } from './movies.datasource';
import { Observable, of } from 'rxjs';
import { LoggingService } from './logging.service';

@Injectable({
  providedIn: 'root'
})
export class MoviesService {

  constructor(private loggingService: LoggingService) { }
  getMovies(): Observable<Movie[]> {
    return of(Movies)
  }
  getMovie(id: number):  Observable<any> {
    this.loggingService.add('Movies Service: get detail by id='+id)
    return of(Movies.find(movie => movie.id === id))
  }
}
