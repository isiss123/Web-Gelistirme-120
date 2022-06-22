import { Component } from "@angular/core";
import { Movies } from "../movies.datasource";
import { Movie } from "../movie";
@Component({
    selector:'movies', //<movies>...</movies>
    templateUrl:'./movies.component.html',
    styleUrls: ['./movies.component.css']
})
export class MoviesComponent{
    title = 'Movies List';
    movies = Movies;
    selectedMovie: Movie;
    onSelect(movie: Movie): void{
        this.selectedMovie = movie;
    }


}