import { Component, OnDestroy, OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { ChatService } from 'src/app/core/services/chat/chat.service';
import { UserService } from 'src/app/core/services/user/user.service';
import { Chat } from 'src/app/shared/models/chat/chat.model';

@Component({
  selector: 'app-chat-list',
  templateUrl: './chat-list.component.html',
  styleUrls: ['./chat-list.component.css']
})
export class ChatListComponent implements OnInit {
  chats$?: Observable<Chat[]>;

  constructor(private chatService: ChatService) {
    
  }

  ngOnInit(): void {
    this.chats$ = this.chatService.getAllChats();
  }
}
