import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ChatService } from 'src/app/core/services/chat/chat.service';
import { Chat } from 'src/app/shared/models/chat/chat.model';

@Component({
  selector: 'app-participating-chats-list',
  templateUrl: './participating-chats-list.component.html',
  styleUrls: ['./participating-chats-list.component.css']
})
export class ParticipatingChatsListComponent {
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
      if (chat.participantIds.includes(this.userId) && chat.creatorUserId != this.userId) {
        this.router.navigateByUrl(`${this.userId}/chats/${chat.id}`);
      } 
    }
  }
}
