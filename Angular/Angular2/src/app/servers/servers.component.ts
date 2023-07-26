import { Component } from '@angular/core';

@Component({
  //selector: 'app-servers',
  //selector:'.app-servers',
  selector:'[app-server]',
  templateUrl: './servers.component.html',
  styleUrls: ['./servers.component.css']
})
export class ServersComponent {
serverCreateOption:boolean=false;
serverStatus:string="offline";


constructor(){
  setTimeout(() => {
    this.serverCreateOption=true
  }, 5000);
}
onServerAdd(){
  this.serverStatus="Online";
}
}
