import { Component } from '@angular/core';
import { Model, ToDoItem } from './model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  model = new Model;
  isDisplay = false;
  getName(){
    return this.model.name;
  }
  getItems(){
    if(this.isDisplay == true){
      return this.model.items
    }
    return this.model.items.filter(item=>item.status == false);
  }
  addItem(value: string){
    if(value != ""){
      let gorev = new ToDoItem(value,false)
      this.model.items.push(gorev)
    }
  }
}
