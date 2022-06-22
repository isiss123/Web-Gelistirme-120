import { Component } from "@angular/core";
import { Movies } from "../movies.datasource";


@Component({
    selector:'movies', //<movies>...</movies>
    templateUrl:'movies.component.html',
    styleUrls: ['./movies.component.css']
})

export class MoviesComponent{
    title = 'Movies List';
    movies = Movies
}