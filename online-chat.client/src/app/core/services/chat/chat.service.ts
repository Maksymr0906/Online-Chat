import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Chat } from 'src/app/shared/models/chat/chat.model';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  constructor(private http: HttpClient) { }

  getAllChats(): Observable<Chat[]> {
    return this.http.get<Chat[]>(`${environment.apiBaseUrl}/api/chats`);
  }
}
