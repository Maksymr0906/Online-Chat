import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Message } from 'src/app/shared/models/message/message.model';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  constructor(private http: HttpClient) { }

  getAllMessages(): Observable<Message[]> {
    return this.http.get<Message[]>(`${environment.apiBaseUrl}/api/messages`);
  }

  getAllChatMessages(chatId: string): Observable<Message[]> {
    return this.http.get<Message[]>(`${environment.apiBaseUrl}/api/messages/chat/${chatId}`);
  }
}
