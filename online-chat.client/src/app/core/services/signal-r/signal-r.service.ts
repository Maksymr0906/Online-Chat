import { Injectable } from '@angular/core';
import { HttpTransportType, HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { Message } from 'src/app/shared/models/message/message.model';
import { environment } from 'src/environments/environment.development';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private messageReceivedSubject = new BehaviorSubject<Message | null>(null);
  messageReceived$ = this.messageReceivedSubject.asObservable();

  private hubConnection?: HubConnection;

  startConnection(): void {
    if (this.hubConnection && this.hubConnection.state === 'Connected') {
      return; // Avoid creating multiple connections
    }

    this.hubConnection = new HubConnectionBuilder()
      .withUrl(`${environment.apiBaseUrl}/chathub`, {
        skipNegotiation: true,
        transport: HttpTransportType.WebSockets
      })
      .build();
    
    this.hubConnection.start().then(() => {
      console.log('Connection Started');
      this.receiveMessage();
    }).catch(err => console.log(`Error while starting connection: ` + err));
  }

  sendMessage(message: Message): void {
    if (this.hubConnection && this.hubConnection.state === 'Connected') {
      this.hubConnection.invoke('SendMessage', message)
        .catch(err => console.log('Error sending message:', err));
    }
  }

  private receiveMessage(): void {
    if (this.hubConnection) {
      this.hubConnection.on('ReceiveMessage', (message: Message) => {
        this.messageReceivedSubject.next(message);
      });
    }
  }

  disconnect(): void {
    if (this.hubConnection) {
      this.hubConnection.stop().then(() => {
        this.hubConnection = undefined;
        console.log('Connection Stopped');
      }).catch(err => console.log('Error while stopping connection: ', err));
    }
  }
}
