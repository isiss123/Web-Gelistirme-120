const container = document.querySelector('.container');
const image = document.querySelector('#music-image');
const audio = document.querySelector('#music-audio');

const title = document.querySelector('#title');
const singner = document.querySelector('#singner');

//Progress
const currentTime = document.querySelector('#current-time');
const durationTime = document.querySelector('#duration-time');
const progresBar = document.querySelector('#progres-bar');

//Controls
const playI = document.querySelector('#playI')
const play = document.querySelector('#play')
const next = document.querySelector('#next')
const pre = document.querySelector('#previous')

//Volume
const volume = document.querySelector('#volume')
const volumeI = document.querySelector('#volume-icon')
const volumeBar = document.querySelector('#volume-bar');

// Music List
const ul = document.querySelector('#music-list ul')

var player = new MusicPlayer(musicList);

window.addEventListener("load",()=>{
    let music = player.getMusic();
    displayMusic(music);
    displayMusicList(player.musicList)
})
const displayMusic = (music) =>{
    title.innerText = music.getName();
    singner.innerText = music.singner;
    image.src = "img/" + music.image;
    audio.src = "audio/" + music.music;
}

//Controls
play.addEventListener("click",()=>{
    if(container.classList.contains("playing") == true){
        pauseMusic()
    }else{
        playMusic();
    }
});
next.addEventListener("click",()=>{
    nextMusic();
    
});
pre.addEventListener("click",()=>{
    container.classList.remove("playing");
    playI.classList = "fa-solid fa-play";
    player.pre();
    let music = player.getMusic();
    displayMusic(music);
});


// Progress 
audio.addEventListener("loadedmetadata",()=>{
    durationTime.textContent = translateTime(audio.duration);
    progresBar.max = Math.floor(audio.duration);
})
audio.addEventListener("timeupdate",()=>{
    progresBar.value = Math.floor(audio.currentTime)
    currentTime.textContent = translateTime(progresBar.value)
})

progresBar.addEventListener("input",()=>{
    currentTime.textContent = translateTime(progresBar.value);
    audio.currentTime = progresBar.value;
})

//Volume
volume_Status = "unmuted"
volume.addEventListener("click",()=>{
    if(volume_Status == "unmuted"){
        audio.muted = true;
        volume_Status = "muted";
        volumeBar.value = 0;
        volumeI.classList = "fa-solid fa-volume-xmark"
    }else{
        audio.muted = false;
        volume_Status = "unmuted";
        volumeI.classList = "fa-solid fa-volume-high"
        volumeBar.value = 100;
    }
})
volumeBar.addEventListener("input",(e)=>{
    const value = e.target.value;
    audio.volume = value/100
    if(value==0){
        volume_Status = "muted";
        audio.muted = true;
        volumeI.classList = "fa-solid fa-volume-xmark"
    }else if(value < 50){
        volume_Status = "unmuted";
        audio.muted = false;
        volumeI.classList = "fa-solid fa-volume-low"
    }else{
        volume_Status = "unmuted";
        audio.muted = false;
        volumeI.classList = "fa-solid fa-volume-high"
    }
})

// Music List
displayMusicList = (list) =>{
    for(let i =0 ; i<list.length; i++){
        let li = `
            <li li-index="${i}" onclick="selectedMusic(this)" class="list-group-item d-flex justify-content-between aling-items-center">
                <span>${list[i].getName()}</span>
                <span id="music-${i}" class="badge bg-primary rounded-pill"></span>
                <audio src="audio/${list[i].music}" class="music-${i}"></audio>
            </li>
        `;
        ul.insertAdjacentHTML("beforeend",li)
        let liAudioDuration = ul.querySelector(`#music-${i}`)
        let liAudioTag = ul.querySelector(`.music-${i}`)
        liAudioTag.addEventListener("loadeddata",()=>{
            liAudioDuration.innerText = translateTime(liAudioTag.duration)
        })
    }
}



















playMusic = () =>{
    container.classList.add("playing");
    playI.classList = "fa-solid fa-pause";
    audio.play();
}
pauseMusic = () =>{
    container.classList.remove("playing");
    playI.classList = "fa-solid fa-play";
    audio.pause();
}
nextMusic = () =>{
    container.classList.remove("playing");
    playI.classList = "fa-solid fa-play";
    player.next();
    let music = player.getMusic();
    displayMusic(music);
}
translateTime = (value) =>{
    let minutes = Math.floor(value/60);
    let seconds = Math.floor(value%60);
    let updateSeconds = seconds < 10 ? `0${seconds}` :`${seconds}`
    return `${minutes}.${updateSeconds}`
}
selectedMusic = (li) =>{
    player.index = li.getAttribute("li-index");
    displayMusic(player.getMusic());
    isPlayerMusic();
    playMusic();
}
isPlayerMusic = () =>{
    for(let li of ul.querySelectorAll("li")){
        if(li.classList.contains("playing")){
            li.classList.remove("playing")
        }
        if(li.getAttribute("li-index") == player.index){
            li.classList.add("playing")
        }
    }
}

//bitende musiqi deyisme
audio.addEventListener("ended",()=>{
    nextMusic();
    playMusic();
})