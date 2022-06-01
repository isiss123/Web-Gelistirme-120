let indi = new Date();
let netice;

// GET methods

netice = indi.getFullYear(); // IL
netice = indi.getMonth();    // AY
netice = indi.getDate();     // GUN
netice = indi.getDay();      // HEFTE GUNU
netice = indi.getHours();    // SAAT
netice = indi.getTime();     // MILISANIYE

// SET methods

//indi.setFullYear(2025);      // ILi 2025 OLARAQ DEYISIR
//indi.setMonth(11);           // Ayi 12 OLARAQ DEYISIR 


let dogum = new Date(2005,10,04);

netice = indi.getFullYear() - dogum.getFullYear(); 
let miliseconds = indi.getTime() - dogum.getTime();
let second = miliseconds / 1000;
let minute = second / 60;
let hour = minute / 60 ;
let day = hour / 24 ;
let year = day / 365; 
netice = year;

//netice = indi;
console.log(netice);