class UI{
    constructor(){
        this.profilecontainer = document.querySelector('#profileContainer'),
        this.alert = document.querySelector('#alert')
    }
    showProfile(profile){
        
        this.profilecontainer.innerHTML = `
        <div class="card">
        <div class="card-body">
            <div class="row">
                <div class="col-md-3">
                    <a href="https://placeholder.com"><img src="https://via.placeholder.com/350x150" class="img-thumbnail"></a>
                </div>
                <div class="col-md-9">
                    <h4>Contact Us</h4>
                    <ul class="list-group">
                        <li class="list-group-item">
                            Name : ${profile.name}
                        </li>
                        <li class="list-group-item">
                            User Name : ${profile.username}
                        </li>
                        <li class="list-group-item">
                            Email : ${profile.email}
                        </li>
                        <li class="list-group-item">
                            Phone : ${profile.phone}
                        </li>
                        <li class="list-group-item">
                            Website : ${profile.website}
                        </li>
                        <li class="list-group-item">
                            Address : ${profile.address.street}/${profile.address.city}
                        </li>
                    </ul>
                    <h4 class="mt-3">Todos List</h4>
                    <ul id="todos" class="list-group">
                        
                    </ul>
                </div>
            </div>
        </div>
    </div>
        `
    }
    showAlert(text){
        this.alert.innerHTML = `${text} is not found`
    }
    showTodo(todos){
        //console.log(todos[9].completed)
        let html = "";
        todos.forEach(todo=>{
            if(todo.completed == true){
                html += `
                <li class="list-group-item true">${todo.title}</li>
                `
            }else{
                html += `
                <li class="list-group-item false">${todo.title}</li>
                `
            }
        })
        this.profilecontainer.querySelector('#todos').innerHTML = html;
    }
    clear(){
        this.alert.innerHTML ='';
        this.profilecontainer.innerHTML = '';
    }
}