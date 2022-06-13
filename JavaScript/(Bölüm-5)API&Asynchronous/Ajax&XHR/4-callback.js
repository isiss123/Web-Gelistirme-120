list = [
    {"id":1,"ad":"Axot 1","sa":5000},
    {"id":2,"ad":"Axot 2","sa":3000},
    {"id":3,"ad":"Axot 3","sa":4000},
    {"id":4,"ad":"Axot 4","sa":6000}
]

let added = false
function addList(pr,callback){
    setTimeout(()=>{
        if(added == true){
            list.push(pr)
            callback(null,pr)
        }else{
            callback(404,pr)
        }
    },2000)
}
function getList(){
    setTimeout(()=>{
        list.forEach(function(i){
            console.log(i.ad)
        })
    },1000)
}

addList({"id":5,"ad":"Axot 5","sa":7000},function(err,data){
    if(err){
        console.log('Xəta: ',err)
    }else{
        console.log(data)
    }
})
