interface eded {
    x:number,
    y:number
}

interface all{
    currentLocation:eded;
    travelTo(yer: eded):void;
}

class Taksi implements all{
    // private color: string;
    // private currentLocation: eded;
    /* YADA */
    constructor(private location?: eded, private color?: string){}
    
    travelTo(yer: eded):void{
        console.log(`Taksi X: ${this.location.x} Y: ${this.location.y} -dan X: ${yer.x} Y: ${yer.y}-a gedir`)
    };
}


let  taxi1= new Taksi({x:10,y:23});
taxi1.travelTo({x:15,y:30})