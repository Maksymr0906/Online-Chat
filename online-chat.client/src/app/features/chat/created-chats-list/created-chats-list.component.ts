import { Component } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ChatService } from 'src/app/core/services/chat/chat.service';
import { Chat } from 'src/app/shared/models/chat/chat.model';

@Component({
  selector: 'app-created-chats-list',
  templateUrl: './created-chats-list.component.html',
  styleUrls: ['./created-chats-list.component.css']
})
export class CreatedChatsListComponent {
  chats$?: Observable<Chat[]>;
  userId: string | null = null;

  constructor(private chatService: ChatService,
    private route: ActivatedRoute,
    private router: Router) {
    this.userId = this.route.snapshot.paramMap.get('userId');
  }

  ngOnInit(): void {
    this.chats$ = this.chatService.getAllChats();
  }

  viewChat(chat: Chat): void {
    if (this.userId) {
      if (!chat.participantIds.includes(this.userId) && chat.creatorUserId == this.userId) {
        this.router.navigateByUrl(`${this.userId}/chats/${chat.id}`);
      } 
    }
  }
}
