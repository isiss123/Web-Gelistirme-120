import{ Taksi } from './11-export(import-export)'
export interface eded {
    x:number,
    y:number
}

export interface all{
    currentLocation:eded;
    travelTo(yer: eded):void;
}



let  taxi1= new Taksi({x:10,y:23});
taxi1.travelTo({x:15,y:30})
