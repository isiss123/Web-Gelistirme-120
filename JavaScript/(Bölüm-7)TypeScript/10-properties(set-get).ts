interface eded {
    x:number,
    y:number
}

interface all{
    currentLocation:eded;
    travelTo(yer: eded):void;
}

class Taksi implements all{
    constructor(private _location?: eded, private _color?: string){}
    
    travelTo(yer: eded):void{
        console.log(`Taksi X: ${this._location.x} Y: ${this._location.y} -dan X: ${yer.x} Y: ${yer.y}-a gedir`)
    };

    /* 1 */
    // getLocation(){
    //     return this._location
    // }
    // setLocation(value: eded){
    //     if(value.x < 0 || value.y < 0){
    //         throw new Error('Menfi ededler olmaz')
    //     }
    //     this._location = value
    // }

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


let  taxi1= new Taksi({x:10,y:23});
taxi1.travelTo({x:15,y:30})
