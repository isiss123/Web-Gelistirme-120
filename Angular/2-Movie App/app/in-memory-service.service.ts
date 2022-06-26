import { Injectable } from '@angular/core';
import { InMemoryDbService, RequestInfo } from 'angular-in-memory-web-api';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InMemoryServiceService implements InMemoryDbService {

  constructor() { }

  createDb() {
    const movies= [
      {id:1, name:'Movie 1', description:'Axot 1',image:'1.jpg'},
      {id:2, name:'Movie 2', description:'Axot 2',image:'2.jpg'},
      {id:3, name:'Movie 3', description:'Axot 3',image:'3.jpg'},
      {id:4, name:'Movie 4', description:'Axot 4',image:'4.jpg'},
      {id:5, name:'Movie 5', description:'Axot 5',image:'5.jpg'},
  ]
  return { movies }
  }
}
