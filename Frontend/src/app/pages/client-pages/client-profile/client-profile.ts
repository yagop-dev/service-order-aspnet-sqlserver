import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-client-profile',
  standalone: true,
  imports: [],
  templateUrl: './client-profile.html',
  styleUrl: './client-profile.css'
})

export class ClientProfile implements OnInit{
  name: string = "";
  telephone: string = "";
  email: string = ""

  ngOnInit(){
    var clientData = localStorage.getItem("client");
    
    if(clientData){
      var client = JSON.parse(clientData);
      this.name = client.name;
      this.telephone = client.telephone;
      this.email = client.email;
    }else{
      this.name = "Client not logged";
      this.telephone = "-";
      this.email = "-";
    }
  }

}
