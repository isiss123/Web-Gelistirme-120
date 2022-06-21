import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  name = 'Axot';
  items = [
    {description:"Axot 1", status:"Yox 1"},
    {description:"Axot 2", status:"Yox 2"},
    {description:"Axot 3", status:"Yox 3"},
    {description:"Axot 4", status:"Yox 4"}
  ]
}
