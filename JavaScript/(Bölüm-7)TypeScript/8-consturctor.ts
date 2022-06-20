interface eded {
    x:number,
    y:number
}

interface all{
    currentLocation:eded;
    travelTo(yer: eded):void;
}

class Taksi implements all{
    color: string;
    constructor(currentLocation?: eded,color?: string){
        this.currentLocation = currentLocation,
        this.color = color
    }
    // .. taksiye ozel olan funksiyalar
    currentLocation:eded;
    aga: string;
    travelTo(yer: eded):void{
        console.log(`Taksi X: ${yer.x} -dan Y: ${yer.y} -a gedir`)
    };
}


let  taxi1= new Taksi({x:10,y:23},'red');
console.log(taxi1)

let  taxi2= new Taksi({x:10,y:23});
console.log(taxi2)

let  taxi3= new Taksi();
console.log(taxi3)