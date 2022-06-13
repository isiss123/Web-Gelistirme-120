first = () =>{
    console.log('first')
    second()
}
second = () =>{
    setTimeout(() =>{
        console.log('second')   //Siraya alir novbeti funksiyalari edir ve geri qayidir
    },2000 )
    third()
}
third = () =>{
    console.log('third')
}
first()