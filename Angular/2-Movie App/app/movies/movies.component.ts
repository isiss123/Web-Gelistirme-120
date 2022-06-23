import { Component } from "@angular/core";
import { Movies } from "../movies.datasource";
import { MoviesService } from "../movies.service";
import { Movie } from "../movie";
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

    // MOVIE SERVICE CAGIRMA
    constructor(private moviesService: MoviesService){}
    getMovies(): void{
        this.movies =  this.moviesService.getMovies()
    }
    //CONSTRUCTOR bitdenden sonra cagirir
    ngOnInit(): void {
        this.getMovies();
    }
}