import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})
export class PostService {
  private url = 'https://jsonplaceholder.typicode.com/posts';
  constructor( private http: HttpClient) { }
  getPosts(){
    return this.http.get(this.url).pipe(
      retry(3),
      catchError(this.handlerError))
  }
  craetePost(post: any){
    return this.http.post(this.url,JSON.stringify(post))
  }
  updatePost(post: any){
    return this.http.put(this.url+'/'+post.id,JSON.stringify(post))
  }
  deletePost(post: any){
    return this.http.delete(this.url+'/'+post.id).pipe(
      retry(3),
      catchError(this.handlerError))
  }
  private handlerError( error: HttpErrorResponse){
    let err;
    if(error.error instanceof ErrorEvent){
      err = error.message
      console.log('Client error: '+error.message)
    }else{
      err = error.message
      console.log(`backend error: error status: ${error.status} error: ${error.message}`)
    }
    return throwError(err)
  }
}
