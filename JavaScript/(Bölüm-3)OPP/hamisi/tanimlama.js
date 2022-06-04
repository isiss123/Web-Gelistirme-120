
const option_list = document.querySelector(".quiz_box .option_list");
const option = option_list.querySelectorAll(".option");
const correctIcon = '<div class="icon"><i class="fa-solid fa-check"></i></div>';
const incorrectIcon = '<div class="icon"><i class="fa-solid fa-xmark"></i></div>';

const timer_text = document.querySelector(".timer_text");
const timer_second = document.querySelector(".timer_second");
const timer_line = document.querySelector(".timer_line");


//BUTTONS
const btn_start = document.querySelector(".btn_start");
const btn_next = document.querySelector(".btn_next");
const btn_reload =document.querySelector(".btn_reload");
const btn_quit =document.querySelector(".btn_quit");