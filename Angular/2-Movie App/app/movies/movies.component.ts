import { Component } from "@angular/core";
import { Movie } from "../movie";

@Component({
    selector:'movies', //<movies>...</movies>
    templateUrl:'movies.component.html',
    styleUrls: ['./movies.component.css']
})

export class MoviesComponent{
    title = 'Movies List'
    movie: Movie = {
        id:1,
        name:'Axot 1'
    }
    getTitle(){
        return this.title
    }
    getMovie(){
        return this.movie
    }
}