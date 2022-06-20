interface eded {
    x:number,
    y:number
}

interface Hamisi{
    currentLocation:eded;
    travelTo(yer: eded):void;
}

class Taxi implements Hamisi{

    // .. taksiye ozel olan funksiyalar
    currentLocation:eded;
    travelTo(yer: eded):void{
        console.log(`Taksi X: ${yer.x} -dan Y: ${yer.y} -a gedir`)
    };
}

class Bus implements Hamisi{

    // .. Avtobusa ozel olan funksiyalar
    currentLocation:eded;
    travelTo(yer: eded):void{
        console.log(`Avtobus X: ${yer.x} -dan Y: ${yer.y} -a gedir`)
    };
}

let  taxi1= new Taxi();
taxi1.travelTo({x:1,y:2});
taxi1.currentLocation={x:4,y:10}

console.log(taxi1.currentLocation)


let bus1 = new Bus()

bus1.travelTo({x:1,y:2});
bus1.currentLocation={x:4,y:10}

console.log(bus1.currentLocation)


