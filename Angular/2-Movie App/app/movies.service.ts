import { Injectable } from '@angular/core';
import { Movie } from './movie';
import { Movies } from './movies.datasource';
import { Observable, of } from 'rxjs';
import { LoggingService } from './logging.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MoviesService {
  private ApiMoviesUrl = 'api/movies'

  constructor(
    private loggingService: LoggingService,
    private http: HttpClient
    ) { }
  getMovies(): Observable<Movie[]> {
    this.loggingService.add('Movies Service: movies listening')
    return this.http.get<Movie[]>(this.ApiMoviesUrl)
  }
  getMovie(id: number):  Observable<any> {
    this.loggingService.add('Movies Service: get detail by id='+id)
    return this.http.get<Movie>(this.ApiMoviesUrl+'/'+id)
  }
}
