import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Movie } from '../movie';
import { MoviesService } from '../movies.service';

@Component({
  selector: 'movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.css']
})
export class MovieDetailComponent implements OnInit {
  @Input() movie: Movie
  constructor(
    private movieService: MoviesService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.getMovie()
  }

  getMovie(): void{
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.movieService.getMovie(id).forEach(movie=>this.movie = movie)
  }

}
