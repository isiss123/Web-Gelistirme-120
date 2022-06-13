const searchProfile = document.querySelector('#searchProfile')
const profile = new Profile();
const ui = new UI();

searchProfile.addEventListener('keyup',(event)=>{
    let text = event.target.value;
    ui.clear();
    if(text != ''){
        profile.getProfile(text).then(rs=>{
            if(rs.profile.length !=0){
                ui.showProfile(rs.profile[0])
                
                ui.showTodo(rs.todos)
            }else{
                ui.showAlert(text)
            }
        }).catch(err=>{
            ui.showAlert(text)
        })
    }
})