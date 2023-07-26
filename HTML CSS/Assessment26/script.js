function nameValidation(){
    var entered_name=document.getElementById("name");
    var validName=/^[A-Za-z\s]*$/;
    if(entered_name.value==""|| !entered_name.value.match(validName)){
        document.getElementById("result").innerHTML="Please enter valid name";
    }
}
function phoneValidation(){
    var entered_phnumber=document.getElementById("phoneNumber");
    var phn_no=/^[7-9][0-9]{0,8}$/;
    if(entered_phnumber.value == 0 || !entered_phnumber.value.match(phn_no)){
        document.getElementById("result").innerHTML="Please enter valid phone number";
    }
}
function emailValidation(){
    var entered_email=document.getElementById("emailId");
    var valid_email=/^[a-zA-Z0-9.!#$%&'*+/=?^_{|}~`-]+@[a-zA-Z0-9]+(?:\.[a-zA-Z0-9]+)*$/;
    if(!entered_email.value.match(valid_email)){
        document.getElementById("result").innerHTML="Please enter valid emailid";
    }
}
function addressValidation(){
    var entered_address=document.getElementById("address");
    if(entered_address.value==""){
        document.getElementById("result").innerHTML="Please enter valid address";
    }
}
var comboPrices={
    option1:799,
    option2:899,
    option3:1199,
    option4:299,
    option5:999,
};
function costCalculation(){
    var checkCombo1=document.getElementById("option1").checked;
    var checkCombo2=document.getElementById("option2").checked;
    var checkCombo3=document.getElementById("option3").checked;
    var checkCombo4=document.getElementById("option4").checked;
    var checkCombo5=document.getElementById("option5").checked;
    var originalPrice=0;
    if(checkCombo1||checkCombo2||checkCombo3||checkCombo4||checkCombo5){
        if(checkCombo1){
            originalPrice += comboPrices.option1;
        }
        if (checkCombo2) {
          originalPrice += comboPrices.option2;
        }
        if (checkCombo3) {
          originalPrice += comboPrices.option3;
        }
        if (checkCombo4) {
          originalPrice += comboPrices.option4;
        }
        if (checkCombo5) {
          originalPrice += comboPrices.option5;
        }
        if(originalPrice>=2000){
            var discount=(originalPrice*20)/100;
            var netPrice=originalPrice-discount;
            document.getElementById("result").innerHTML="Order has been placed successfully. You are requested to pay Rs."+Math.round(netPrice)+"on delivery.";
        }
        else{
            document.getElementById("result").innerHTML="Order has been placed successfully. You are requested to pay Rs."+Math.round(originalPrice)+"on delivery.";
        }
    }else{
        document.getElementById("result").innerHTML="No selection has been made.";
    }
}
