import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent {
  posts: any;
  constructor(private http: HttpClient) { 
    http.get('https://api.themoviedb.org/3/movie/popular?api_key=5ec94e14b8b567730a34a448b3f79830&language=en-US&page=4').subscribe(
      responce=>{
        this.posts = responce;
    })
  }


}
