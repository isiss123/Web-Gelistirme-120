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
    getMovies(): void{
        this.moviesService.getMovies().subscribe(movies =>{
            this.movies = movies;
        })
    }
    add(name: string, description: string, image: string): void{
        this.moviesService.add({
            name,
            description,
            image
        } as Movie).subscribe(movie =>{this.movies.push(movie);})
    }
    delete(movie: Movie){
        this.movies = this.movies.filter(m=>m!== movie)
        this.moviesService.delete(movie).subscribe();
    }

    // MOVIE,LOGGING SERVICE CAGIRMA
    constructor(private moviesService: MoviesService, private loggingService: LoggingService){}
    
    //CONSTRUCTOR bitdenden sonra cagirir
    ngOnInit(): void {
        this.getMovies();
    }
}