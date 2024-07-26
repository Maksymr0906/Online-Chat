import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddChatRequest } from 'src/app/shared/models/chat/add-chat-request.model';
import { ChatWithCreator } from 'src/app/shared/models/chat/chat-with-creator.model';
import { Chat } from 'src/app/shared/models/chat/chat.model';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  constructor(private http: HttpClient) { }

  addChat(model: AddChatRequest): Observable<Chat> {
    return this.http.post<Chat>(`${environment.apiBaseUrl}/api/chats`, model)
  }

  getAllChats(): Observable<Chat[]> {
    return this.http.get<Chat[]>(`${environment.apiBaseUrl}/api/chats`);
  }

  getAllChatsWithCreators(): Observable<ChatWithCreator[]> {
    return this.http.get<ChatWithCreator[]>(`${environment.apiBaseUrl}/api/chats/with-creators`);
  }
}
