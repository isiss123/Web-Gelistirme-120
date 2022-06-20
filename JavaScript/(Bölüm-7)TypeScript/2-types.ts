let a: number = 5;
let b: string = 'a';
let c: boolean = false;
let d: any = 'a'; // her sey olabiler
let e: number[] = [1,2,3];
let f: Array<number> = [1,2,3];
let g: [any,number,string,boolean] = ['a1',1,'sa',true];

enum Payment {kredi=0,havale=1,qapi=3,eft=2};

let krediPayment = Payment.kredi; // 0 
let havalePayment = Payment.havale; // 1
let eftPayment = Payment.eft; // 3
let qapiPayment = Payment.qapi; // 2
