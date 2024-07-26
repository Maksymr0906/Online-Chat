import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ChatService } from 'src/app/core/services/chat/chat.service';
import { ChatWithCreator } from 'src/app/shared/models/chat/chat-with-creator.model';


@Component({
  selector: 'app-chat-list',
  templateUrl: './chat-list.component.html',
  styleUrls: ['./chat-list.component.css']
})
export class ChatListComponent implements OnInit {
  chats$?: Observable<ChatWithCreator[]>;

  constructor(private chatService: ChatService) {
    
  }

  ngOnInit(): void {
    this.chats$ = this.chatService.getAllChatsWithCreators();
    this.chatService.getAllChatsWithCreators().subscribe({
      next: (response) => {
        console.log(response);
      }
    })
  }
}
