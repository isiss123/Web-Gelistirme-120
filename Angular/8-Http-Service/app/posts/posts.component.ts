import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent {
  posts!: [any];
  private url = 'https://jsonplaceholder.typicode.com/posts';
  constructor(private http: HttpClient) { 
    http.get(this.url).subscribe(
      responce=>{
        this.posts = <[any]>responce;
    })
  }
  creatPost(input: HTMLInputElement){
      const post = {id: Number, title: input.value};
      input.value = '';
      this.http.post(this.url,JSON.stringify(post)).subscribe(
        responce=>{
          this.posts.splice(0,0,post)
          console.log(responce);
        })
  }
  updatePost(post: any){
    post.title = "Update"
    this.http.put(this.url+'/'+post.id,JSON.stringify(post)).subscribe(response=>{
      console.log(response);
    })
    // this.http.patch(this.url+'/'+post.id,JSON.stringify({
    //   title: 'Update PATCH'
    // })).subscribe(response=>{
    //   console.log(response)
    // })
  }


}
