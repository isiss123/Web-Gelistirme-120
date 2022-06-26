import { Component, OnInit } from '@angular/core';
import { Movie } from '../movie';
import { MoviesService } from '../movies.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  movies: Movie[]=[];
  moviesLength: Number;

  constructor(private movieService: MoviesService) { }
  getMovies(): void{
    this.movieService.getMovies().subscribe(movies=>{
      this.movies = movies.slice(0,3);
      this.moviesLength = movies.length
    })
  }
  ngOnInit(): void {
    this.getMovies()
  }

}
