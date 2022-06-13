myObj = {
    "url":"https://randomuser.me/api/?results=5"
}

let request = (obj) =>{
    return new Promise((resolve, reject) =>{
        var xhr = new XMLHttpRequest();
        xhr.open('GET',obj.url)
        xhr.onload = function(){
            if(xhr.status >= 200 && xhr.status < 300){
                resolve(xhr.response)
            }else{
                reject(xhr.statusText)
            }
        }
        xhr.send()
    })
}
let getUsers = (data) =>{
    let users = JSON.parse(data)
    let html = "";
    users.results.forEach(user =>{
        html +=`
        <img src="${user.picture.medium}">
        <div id="name">${user.name.title} - ${user.name.first} - ${user.name.last}</div> 
        `
    })
    document.querySelector('#users').innerHTML = html
    console.log(users) 
    return Promise.resolve('Axot geldi')
}
request(myObj).then(getUsers)
.then(msg =>{
    console.log(msg)
}).catch((err)=>{
    console.log(err)
})