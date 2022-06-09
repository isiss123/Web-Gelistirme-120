class Music{
    constructor(title,singner,image,music){
        this.title = title;
        this.singner = singner;
        this.image = image;
        this.music = music;
    }
    getName(){
        let tag = `${this.title} - ${this.singner}`;
        return tag;
    }
}
musicList = [
    new Music("Axot 1","Bekar 1","1.jpg","1.mp3"),
    new Music("Axot 2","Bekar 2","2.jpg","2.mp3"),
    new Music("Axot 3","Bekar 3","3.jpg","3.mp3")
]