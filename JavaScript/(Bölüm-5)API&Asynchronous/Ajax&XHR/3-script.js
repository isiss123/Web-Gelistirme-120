const btnOne  = document.querySelector('#getOne')
const btnAll  = document.querySelector('#getAll')
const result  = document.querySelector('#result')
const btnpost = document.querySelector('#post')

btnOne.addEventListener('click', getOne)
btnAll.addEventListener('click', getAll)
btnpost.addEventListener('click', post)

function getOne(){
    let xhr = new XMLHttpRequest();
    let id = document.querySelector('#getid').value
    let url = 'https://jsonplaceholder.typicode.com/posts/'+id;
    xhr.open('GET', url, true);
    xhr.onreadystatechange = function(){
        if(xhr.readyState === 4){
            if(xhr.status === 200){
                document.querySelector('body').style.background = "none";
                let post = JSON.parse(xhr.responseText);
                html = `
                    <div class="card border-light mb-3" style="max-width: 18rem;">
                        <div class="card-header">${post.id} - ${post.title}</div>
                        <div class="card-body">
                            <p class="card-text">${post.body}</p>
                        </div>
                    </div>
                    `
                result.innerHTML = html;
            }else if(xhr.status === 404){
                document.querySelector('body').style.background = "url('uygulama/1-404.jpeg')";
            }
        }
    }
    xhr.send()
}

function getAll(){
    let xhr = new XMLHttpRequest();
    let url = "https://jsonplaceholder.typicode.com/posts";
    xhr.open('GET', url,true)
    xhr.onreadystatechange = function(){
        document.querySelector('body').style.background = "none";
        if(xhr.readyState == 4){
            if(xhr.status == 200){
                let posts = JSON.parse(xhr.responseText);
                html = "";
                posts.forEach(post =>{
                    html += `
                    <div class="card border-light mb-3" style="max-width: 18rem;">
                        <div class="card-header">${post.id} - ${post.title}</div>
                        <div class="card-body">
                            <p class="card-text">${post.body}</p>
                        </div>
                    </div>
                    `
                })
                result.innerHTML = html;
            }
        }
    }
    xhr.send()
}

function post(){
    const data = {
        userId: 1,
        title: "Axot 1",
        body: "Bekar 1"
    }
    let xhr = new XMLHttpRequest();
    let url = "https://jsonplaceholder.typicode.com/posts";
    xhr.open('POST', url,true)
    let json = JSON.stringify(data)
    xhr.setRequestHeader('Content-Type','application/json; charset=utf-8');
    xhr.onload = function(){
        if(xhr.readyState == 4 && xhr.status == 201){
            var post = xhr.responseText
            console.log(post)
        }
        
    }
    xhr.send(json);
}