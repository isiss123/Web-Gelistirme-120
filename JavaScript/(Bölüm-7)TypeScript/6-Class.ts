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

