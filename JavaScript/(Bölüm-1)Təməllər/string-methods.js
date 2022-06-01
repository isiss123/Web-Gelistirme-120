let cumle = "Komple Uygulamali Web Gelistirme Egitimi"
let netice;

netice = cumle.toUpperCase();   // hamisini boyuk edir
netice = cumle.toLowerCase();   // hamisini balaca edir
netice = cumle.slice(0,6);      // 0 - 6 a qeder olan indexleri alir
netice = cumle.substring(0,6);  // 0 - 6 a qeder olan indexleri alir
netice = cumle.replaceAll("Egitimi","Kursu"); // egitimi sozunu kursu olaraq deyisir

netice = cumle.trim(); //basda ve sonda olan bosluglari silir
netice = cumle.trimStart(); //basda olan bosluqlari silie
netice = cumle.trimEnd(); //sonda olan bosluqlari silir

netice = cumle.indexOf("Komple"); //necenci indexden basladigini gosterir
netice = cumle.split(" "); //bosluga gore bolur
//netice = cumle.split(" ")[3]; 
netice = cumle.length; // karakter sayini gosterir

console.log(netice);