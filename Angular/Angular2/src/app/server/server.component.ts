import { Component } from '@angular/core';
import { retry } from 'rxjs';

@Component({
  selector: 'app-server',
  templateUrl: './server.component.html',
  styleUrls: ['./server.component.css']
})
export class ServerComponent {
serverId:number=1001;
serverStatus:string='offline';

getServerId(){
  return this.serverId;
}
getServerStatus(){
  return this.serverStatus;
}
}
