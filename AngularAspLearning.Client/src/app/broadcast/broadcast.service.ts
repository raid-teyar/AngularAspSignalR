import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root',
})
export class BroadcastService {
  private hubConnection!: signalR.HubConnection;
  private _result: Subject<any> = new Subject<any>();
  public result = this._result.asObservable();

  constructor(private http: HttpClient) {}

  // creating the connection with the server and starting it
  public startConnection() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Information)
      .withUrl(environment.baseUrl + 'api/broadcast-hub', {
        withCredentials: false,
      })
      .build();
    console.log('Starting connection...');
    this.hubConnection
      .start()
      .then(() => {
        console.log('Connection started.');
        this.updateData();
      })
      .catch((err: any) => console.log(err));
  }

  // asking the server for updates
  public updateData() {
    console.log('Asking for updates...');
    this.http
      .get<any>(environment.baseUrl + 'api/Broadcast/startUpdates')
      .subscribe();
  }

  // adding the listener for the Update event
  public addDataListeners() {
    this.hubConnection.on('Update', (msg) => {
      console.log('Got a message from server: ' + msg);
      this._result.next(msg);
    });
  }
}
