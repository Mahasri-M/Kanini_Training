/*function f1(){
    document.getElementById("para1").innerHTML="Welcome";
}
function f2(){
    document.write("Welcome!");
}
function f3(){
    window.alert("Message");
   
}
function f3(){
   console.log("Message");
   
}
function f1(x,y){
   //let x=5,y=hello;
    document.getElementById("para1").innerHTML=x+y;
    {
        document.getElementById("para2").innerHTML=x+y;
    }
}
function f2(){
    stud={rno:100, name:'aaa',add:'13,chennai'}
    document.getElementById('para2').innerHTML=stud.rno+' '+stud.name;
    stud.name='bbb';
    document.getElementById('para1').innerHTML=stud.rno+' '+stud.name;
}
/* declartion:
 x=5;
 var x=4,y=5; priority3
 let x=5, y=6; highest priority p1
const x=9, y=3; priority2

function f3(){
   /* number=[100,200,300]
    alert(number[2])
    number[2]=1000
    alert(number[2])
    number[3]=2000
    alert(number[3])
    number[5]=8000
    alert(number[5])
  
    alert(number[4])

    number2=new Array(10,20,30);
    alert(number2[0])
}*/
function regex(){
    let pattern="visit w3school";
    let input="w3school";
    alert(pattern.search(input));
}