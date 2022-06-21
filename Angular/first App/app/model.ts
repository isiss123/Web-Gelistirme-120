export class Model{
    name;
    items;
   constructor(){
        this.name = 'Axot' ;
        this.items = [
            new ToDoItem("Axot 1",false),
            new ToDoItem("Axot 2",false),
            new ToDoItem("Axot 3",true),
            new ToDoItem("Axot 4",false),
            new ToDoItem("Axot 5",true),
        ]
   }
}

export class ToDoItem{
    description;
    status;
    constructor(description: string,status: boolean){
        this.description = description;
        this.status = status;
    }
}