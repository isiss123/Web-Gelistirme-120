import { Component } from "@angular/core";
import { MoviesService } from "../movies.service";
import { Movie } from "../movie";
import { LoggingService } from "../logging.service";
@Component({
    selector:'movies', //<movies>...</movies>
    templateUrl:'./movies.component.html',
    styleUrls: ['./movies.component.css']
})
export class MoviesComponent{
    title = 'Movies List';
    movies: Movie[];
    selectedMovie: Movie;

    onSelect(movie: Movie): void{
        this.selectedMovie = movie;
    }

    // MOVIE,LOGGING SERVICE CAGIRMA
    constructor(private moviesService: MoviesService, private loggingService: LoggingService){}
    getMovies(): void{
        this.moviesService.getMovies().subscribe(movies =>{
            this.movies = movies;
        })
    }
    //CONSTRUCTOR bitdenden sonra cagirir
    ngOnInit(): void {
        this.getMovies();
    }
}