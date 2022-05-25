var isim = "Ahmet"; // global scope
const adres = "İstanbul"; // deyistirilemeyen

function yazdir() {
    var isim = "Ayşe";
    var yas = 20;
    console.log("function scope: ", isim, yas);
}

if(true) {
    let cinsiyet = "Kadın"; // private
    let isim = "Zeynep"; // private
    console.log(isim, cinsiyet);
}

console.log(isim);

yazdir();

// fonksiyonlar kendi scope alanlarını oluşturur.
// block içerisinde yeni bir scope oluşmaz. (let,const)