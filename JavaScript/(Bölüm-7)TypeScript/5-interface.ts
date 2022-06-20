interface eded {
    x:number,
    y:number
}
interface axot{
    name: string;
    phone:string;
}
interface Hamisi{
    currentLocation:eded;
    travelTo(yer: eded):void;
    uzunluq(yerA: eded, yerB: eded):number;
    add(person: axot):void;
    remove(person: axot):void
}

let travelTo = (yer: eded)=>{
    // .../
}

let uzunluq = (yerA: eded, yerB: eded)=>{
    // .../
}
