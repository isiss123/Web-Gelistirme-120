import { all, eded } from './11-import(import-export)'
export class Taksi implements all{
    constructor(private _location: eded, private _color?: string){}
    currentLocation: eded
    
    travelTo(yer: eded):void{
        console.log(`Taksi X: ${this._location.x} Y: ${this._location.y} -dan X: ${yer.x} Y: ${yer.y}-a gedir`)
    };
    get location(){
        return this._location
    }
    set location(value: eded){
        if(value.x <0 || value.y < 0){
            throw new Error('Menfi eded olmaz')
        }
        this._location = value
    }
}