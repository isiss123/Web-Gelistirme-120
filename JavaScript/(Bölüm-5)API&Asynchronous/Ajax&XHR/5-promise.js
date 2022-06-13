list = [
    {"id":1,"ad":"Axot 1","sa":5000},
    {"id":2,"ad":"Axot 2","sa":3000},
    {"id":3,"ad":"Axot 3","sa":4000},
    {"id":4,"ad":"Axot 4","sa":6000}
]


function addList(pr){
    return new Promise(function(resolve,reject){
        setTimeout(()=>{
            list.push(pr)
            let added = true;
            if(added){
                resolve()
            }else{
                reject('Xəta: 404')
            }
        },2000)
    })
    
}
function getList(){
    setTimeout(()=>{
        list.forEach(function(i){
            console.log(i.ad)
        })
    },1000)
}

addList({"id":5,"ad":"Axot 5","sa":7000}).then(getList).catch(function(err){
    console.log(err)
})
