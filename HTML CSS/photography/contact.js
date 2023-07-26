function validatename(){
    var entered_name=document.getElementById("fn");
    var validName=/^[a-zA-Z\s]*$/;
    if(entered_name.value==""||!entered_name.value.match(validName)){
        document.getElementById("resultname").innerHTML="<span class='red'>Please enter valid name";
    }
}
function validateemail(){
    var entered_email=document.getElementById("email");
    var valid_email=/^[a-zA-Z0-9 .]+@[a-zA-Z]+(.[a-zA-Z0-9])*$/;
    if(entered_email.value==""||!entered_email.value.match(valid_email)){
        document.getElementById("resultemail").innerHTML="<span class='red'>Please enter valid email";
    }
}
function validatephnno(){
    var entered_phnumber=document.getElementById("num");
    var valid_phno="^[7-9][0-9]{9}$";
    if(!entered_phnumber.value.match(valid_phno)){
        document.getElementById("resultphno").innerHTML="<span class='red'>Please enter valid phone number";
    }
}
function validatemsg(){
    var entered_msg=document.getElementById("que");
    if(entered_msg.value==""){
        document.getElementById("resultmsg").innerHTML="<span class='red'>Please enter valid massage";
    }
}
function validatedevice(){
    var entered_device=document.getElementById("devname");
    var valid_devname=/^[a-zA-Z0-9]$/;
    if(entered_device.value==""||!entered_device.value.match(valid_devname)){
        document.getElementById("resultdev").innerHTML="<span class='red'>Please enter valid device name";
    }
}
function submit(){
    if(entered_name||entered_email||entered_phnumber||entered_msg==""){
 document.getElementById("resultbtn").innerHTML="<span class='red'>Please enter the credentials";
    }
}