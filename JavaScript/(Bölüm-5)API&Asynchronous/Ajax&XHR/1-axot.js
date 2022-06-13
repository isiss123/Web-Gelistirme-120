var xhr = new XMLHttpRequest()

xhr.onreadystatechange = function() {
    if(xhr.readyState == 4){
        if(xhr.status == 200){
            console.log(xhr.responseText)
        }else if(xhr.status == 404){
            console.log('axot yoxdu')
        }
        
    }
}
xhr.onprogress = function(){
    console.log('Yuklenir...')
}
xhr.open('GET','1-msg.txt',true)
    // false : Senkron(islem bitmeden basqa bir islem edilebilmez)
    // true  : Asenkron(Islem bitene qeder diger islemleri edir ve bu islem bitende geri qayidir)
xhr.send()
console.log('axot')