let axot_1 = (a: number,b: number, c?: number): string=>{  // cixan cavab string tipinde olacaq
    let total = a+b;
    let say = 2;
    if(typeof c !=='undefined'){
        total +=c;
        say += 1;
    }
    let cavab = total/say
    return 'Cavab: '+cavab;
}
axot_1(10,20,30)
axot_1(10,20)

let axot_2 = (...a: number[]): string=>{
    let total = 0;
    let say = 0;
    for(let i=0; i<a.length; i++){
        total += a[i];
        say +=1
    };
    let cavab = total/say
    return 'Cavab: '+cavab;
}
axot_2(10,20,30,40,50)
