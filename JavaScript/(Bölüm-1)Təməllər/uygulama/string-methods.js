let url = "https://www.istiqlal.cf";
let cumle = "Komple Uygulamalı Web Geliştirme Eğitimi";
let netice;
// url nece karaterdir
netice = url.length;

// cumle nece sozden ibaretdir
netice = cumle.split(" ").length;

// url https ile basliyir?
if(url.startsWith("https")== true){
    console.log("baslayir");
}else{
    console.log("baslamir");
}

// cumlede egitim sozu var
if(cumle.indexOf("egitimi")> -1 ||cumle.indexOf("Egitimi")> -1 ){
    console.log("var");
}else{
    console.log("yox");
}

// url ve cumleni birlestirerek " https://www.istiqlal.cf/komple-uygulamali-web-gelistirme-eğitimi " cevir
cumle = cumle.toLowerCase().replaceAll(" ","-").replaceAll("ş","s").replaceAll("ı","i");
netice = `${url}/${cumle}`;


console.log(netice);
