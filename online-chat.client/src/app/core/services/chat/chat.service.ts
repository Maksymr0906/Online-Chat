import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddChatRequest } from 'src/app/shared/models/chat/add-chat-request.model';
import { AddUserToChatRequest } from 'src/app/shared/models/chat/add-user-to-chat-request.model';
import { Chat } from 'src/app/shared/models/chat/chat.model';
import { RemoveUserFromChatRequest } from 'src/app/shared/models/chat/remove-user-from-chat-request.model';
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

  addUserToChat(chatId: string, model: AddUserToChatRequest): Observable<void> {
    return this.http.post<void>(`${environment.apiBaseUrl}/api/chats/${chatId}/addUser`, model);
  }

  removeUserFromChat(chatId: string, model: RemoveUserFromChatRequest): Observable<void> {
    return this.http.post<void>(`${environment.apiBaseUrl}/api/chats/${chatId}/removeUser`, model);
  }
}
