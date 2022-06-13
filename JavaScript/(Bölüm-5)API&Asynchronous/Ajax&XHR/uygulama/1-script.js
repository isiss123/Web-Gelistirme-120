const getUser = document.querySelector('#get-user')

getUser.addEventListener("click",add)

function add(){
    const xhr = new XMLHttpRequest();
    document.querySelector('#loading').style.display = "block"
    
    setTimeout(()=>{
        xhr.open('GET','1-users.json',true)
        xhr.onreadystatechange = function(){
            if(xhr.readyState == 4){
                if(xhr.status == 200){
                    document.querySelector('#loading').style.display = "none";
                    let users = JSON.parse(this.responseText)
                    let html = "";
                    users.forEach(user =>{
                        html += `
                        <tr>
                            <td>${user.firstName}</td>
                            <td>${user.lastName}</td>
                            <td>${user.age}</td>
                        </tr>
                        `
                    })
                    document.querySelector("#users").innerHTML = html;
                }else if(xhr.status == 404){
                    document.querySelector('body').style.background = "url('1-404.jpeg')";
                    document.querySelector('#loading').style.display = "none";
                    document.querySelector('table').style.display = "none";
                }
            }
        }
        xhr.send()
    },1500)
    
    
}
