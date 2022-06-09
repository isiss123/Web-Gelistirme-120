
const container = document.querySelector(".container")
const image = document.querySelector("#music-img")
const audio = document.querySelector("#music-audio")
const title = document.querySelector(".container .details #title")
const singner = document.querySelector(".container .details #singner")
const ul = document.querySelector("ul")


const play = document.querySelector(".container .controls #play")
const previous = document.querySelector(".container .controls #previous")
const next = document.querySelector(".container .controls #next")
const volume = document.querySelector("#volume")
const volumeBar = document.querySelector("#volume-bar")


const currentTime = document.querySelector("#curent-time")
const duration = document.querySelector("#duration")
const progressBar = document.querySelector("#progress-bar")


var player = new MusicPlayer(musicList);

window.addEventListener("load",()=>{
    let music = player.getMusic();
    displayMusic(music);
    displayMusicList(player.musicList);
    isPlayingMusing()
});
function displayMusic(music){
    title.innerText = music.getName();
    singner.innerText = music.singner;
    image.src = "img/" + music.image;
    audio.src = "audio/" + music.music;
}
const displayMusicList = (list) =>{
    for(let i =0; i<list.length; i++){
        let tag = `
        <li li-index='${i}' onclick="selectedMusic(this)" class="list-group-item d-flex justify-content-between aling-items-center">
            <span>${list[i].getName()}</span>
            <span id="music-${i}" class="badge bg-primary rounded-pill"></span>
            <audio src="audio/${list[i].music}" class="music-${i}"></audio>
        </li>`;
        ul.insertAdjacentHTML("beforeend",tag);

        let liAduioDuration = ul.querySelector(`#music-${i}`);
        let liAduioTag = ul.querySelector(`.music-${i}`);
        liAduioTag.addEventListener("loadeddata",()=>{
            liAduioDuration.innerText = translateTime(liAduioTag.duration)
        })
    }
}



play.addEventListener("click",() =>{
    
    const isPlayMusic = container.classList.contains("playing")
    if(isPlayMusic == true) {
        pauseMusic();
    }else{
        playMusic();
    }
})

function playMusic(){
    container.classList.add("playing");
    play.classList = "fa-solid fa-pause"
    audio.play();
    
}
function pauseMusic(){
    container.classList.remove("playing")
    play.classList = "fa-solid fa-play"
    audio.pause();
    
}


next.addEventListener("click",()=>{
    nextMusic();
})
previous.addEventListener("click",()=>{
    preMusic();
})
function preMusic(){
    container.classList.remove("playing")
    player.previous();
    play.classList = "fa-solid fa-play"
    let music = player.getMusic();
    displayMusic(music);
    isPlayingMusing()
}
function nextMusic(){
    container.classList.remove("playing")
    player.next();
    play.classList = "fa-solid fa-play"
    let music = player.getMusic();
    displayMusic(music);
    isPlayingMusing()
}
let translateTime = (value) =>{
    const minutes = Math.floor(value / 60);
    const seconds = Math.floor(value % 60);
    const updateSeconds = seconds < 10 ?`0${seconds}`:`${seconds}`
    return `${minutes}.${updateSeconds}`
}
audio.addEventListener("loadedmetadata",() =>{
    duration.textContent = translateTime(audio.duration);
    progressBar.max = Math.floor(audio.duration)
})
audio.addEventListener("timeupdate",()=>{
    progressBar.value = Math.floor(audio.currentTime);
    currentTime.textContent = translateTime(progressBar.value)
})

//MUSIQI SES KECISLERI
progressBar.addEventListener("input",()=>{
    currentTime.textContent = translateTime(progressBar.value)
    audio.currentTime = progressBar.value;
})

let volume_Status = "unmuted";
volume.addEventListener("click",()=>{
    if(volume_Status=="unmuted"){
        volume_Status = "muted";
        audio.muted = true;
        volumeBar.value = 0;
        volume.classList = "fa-solid fa-volume-xmark";
    }else{
        volume_Status = "unmuted";
        audio.muted= false;
        volumeBar.value = 100;
        volume.classList = "fa-solid fa-volume-high";
    }

})
volumeBar.addEventListener("input",(e)=>{
    const value = e.target.value;
    audio.volume = value/100
    if(value ==0){
        volume_Status = "muted";
        audio.muted= true;
        volume.classList = "fa-solid fa-volume-xmark";
    }else if(value <50){
        volume_Status = "unmuted";
        audio.muted= false;
        volume.classList = "fa-solid fa-volume-low";
    }
    else{
        volume_Status = "unmuted";
        audio.muted= false;
        volume.classList = "fa-solid fa-volume-high";
    }
})


//LISTE MUSIC SECME
const selectedMusic = (li) =>{
    player.index = li.getAttribute("li-index");
    displayMusic(player.getMusic())
    playMusic();
    isPlayingMusing();
}

const isPlayingMusing = () =>{
    for(let li of ul.querySelectorAll("li")){
        if(li.classList.contains("playing")){
            li.classList.remove("playing")
        }
        if(li.getAttribute("li-index")==player.index){
            li.classList.add("playing")
        }
    }
}

//bitende novbeti musiqiye kecmesi
audio.addEventListener("ended",()=>{
    nextMusic();
    playMusic()
})