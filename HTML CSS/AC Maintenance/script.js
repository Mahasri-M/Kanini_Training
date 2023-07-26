function bookAppointment() { 
var yearlyMaintenance = document.getElementById("yearlyMaintenance").checked; 
var customerName = document.getElementById("customerName").value; 
var acType = document.getElementById("acType").value; 
var serviceType = document.getElementById("serviceTypes") 
var selectedService = serviceType.options[serviceType.selectedIndex].value; 
var selectedServiceText = serviceType.options[serviceType.selectedIndex].text; 
var email = document.getElementById("email").value; 
var serviceCharge; 
switch (selectedServiceText) { 
case "Cleaning": 
var serviceCharge = 500 
break; 
case "Repair": 
var serviceCharge = 1000 
break; 
default: 
var serviceCharge = 1500 
break; 
} 
var isYearlyMaintenance = (yearlyMaintenance === true) ? "with" : "without"; 
if(yearlyMaintenance==true){
 var extra = serviceCharge+ 1000;
    var result = "Hello " + customerName + ", your service appointment for " + acType + " AC " + selectedServiceText + " " + isYearlyMaintenance + " yearly maintenance will be send to your email ID " + email + " and the estimated service charge will be Rs " + extra; 
    document.getElementById('result').innerHTML = result; 

}
else{
var result = "Hello " + customerName + ", your service appointment for " + acType + " AC " + selectedServiceText + " " + isYearlyMaintenance + " yearly maintenance will be send to your email ID " + email + " and the estimated service charge will be Rs " + serviceCharge; 
document.getElementById('result').innerHTML = result; 
}
return false; 
} 
function showRangevalue(x) { 
document.getElementById("show-range-value").innerHTML = x + " Months"; 
} 
