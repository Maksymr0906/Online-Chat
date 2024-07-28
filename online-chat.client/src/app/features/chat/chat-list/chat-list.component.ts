import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { ChatService } from 'src/app/core/services/chat/chat.service';
import { AddUserToChatRequest } from 'src/app/shared/models/chat/add-user-to-chat-request.model';
import { Chat } from 'src/app/shared/models/chat/chat.model';


@Component({
  selector: 'app-chat-list',
  templateUrl: './chat-list.component.html',
  styleUrls: ['./chat-list.component.css']
})
export class ChatListComponent implements OnInit, OnDestroy {
  joinChatSubscription?: Subscription;
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

  ngOnDestroy(): void {
    this.joinChatSubscription?.unsubscribe();
  }

  joinChat(chat: Chat): void {
    if (this.userId) {
      if (!chat.participantIds.includes(this.userId) && chat.creatorUserId != this.userId) {
        const model: AddUserToChatRequest = {
          userId: this.userId
        };

        this.joinChatSubscription = this.chatService.addUserToChat(chat.id, model).subscribe({
          next: (response) => {
            this.router.navigateByUrl(`${this.userId}/chats/${chat.id}`);
          }
        });
      } 
    }
  }
}
