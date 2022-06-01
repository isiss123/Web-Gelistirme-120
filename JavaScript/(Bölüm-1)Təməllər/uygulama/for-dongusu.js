let sayilar= [1,5,10,7,24,15,3,25,12];

// 1 - Her elemanin kvadrati
// for(let sayi of sayilar){
//     console.log(Math.pow(sayi, 2));
// }

// 2 - 5 e bolunen ededler
// for(let i = 0; i < sayilar.length; i++){
//     if(sayilar[i]%5 == 0){
//         console.log(sayilar[i]);
//     }
// }

// 3 - cut ededlerin cemi
// let toplam = 0;
// for(let sayi of sayilar){
//     if(sayi % 2 == 0){
//         toplam += sayi;
//     }
// }
// console.log(toplam);


let urunler = ["iphone 12","iphone 12 pro max","samsung s22","samsung a90"];

// 4 - butun urunleri boyuk herfle yazdir
// for(let urun of urunler){
//     console.log(urun.toUpperCase());
// }

// 5 - nece samsung urunu var
// let say = 0;
// for(let urun of urunler){
//     if(urun.includes("samsung")){
//         say++;
//     }
// }
// console.log(say);

let ogrenciler=[
    {"ad" : "axot" ,"notlar" : [60,70,80]},
    {"ad" : "yoxdu","notlar" : [40,90,80]},
    {"ad" : "bekar","notlar" : [1,2,8]}
]
// 6 - not ortalamasini ve basari durumu
for(let ogrenci of ogrenciler){
    let not_toplam = 0;
    let ortalama   = 0;
    let say        = 0;
    for(let not of ogrenci.notlar){
        not_toplam += not;
        say++;
    }
    ortalama = Math.round(not_toplam / say);
    console.log(`${ogrenci.ad} adli sagirdin ortalamasi : ${ortalama}`);
    if(ortalama >= 50){
        console.log("basarili");
    }
    else{
        console.log("basarisiz");
    }
}