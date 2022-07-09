import { Component, OnInit } from '@angular/core';
import { PostService } from '../services/post.service';

@Component({
  selector: 'posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {
  posts!: [any];

  constructor( private postService: PostService) { }
  ngOnInit(): void {
    this.postService.getPosts().subscribe(responce=>{
        this.posts = <[any]>responce;
    })
  }
  
  creatPost(input: HTMLInputElement){
      const post = {id: Number, title: input.value};
      input.value = '';
      this.postService.craetePost(post).subscribe(
        responce=>{
          this.posts.splice(0,0,post)
          console.log(responce);
        })
  }
  updatePost(post: any){
    post.title = "Update"
    this.postService.updatePost(post).subscribe(response=>{
      console.log(response);
    })
    // this.http.patch(this.url+'/'+post.id,JSON.stringify({
    //   title: 'Update PATCH'
    // })).subscribe(response=>{
    //   console.log(response)
    // })
  }
  deletePost(post: any){
   this.postService.deletePost(post).subscribe(response=>{
      console.log(response);
      let index = this.posts.indexOf(post);
      this.posts.splice(index,1)
    })
  }


}
