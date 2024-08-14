import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { ChatService } from 'src/app/core/services/chat/chat.service';
import { AddUserToChatRequest } from 'src/app/shared/models/chat/add-user-to-chat-request.model';
import { Chat } from 'src/app/shared/models/chat/chat.model';

@Component({
  selector: 'app-chat-table',
  templateUrl: './chat-table.component.html',
  styleUrls: ['./chat-table.component.css']
})
export class ChatTableComponent implements OnInit, OnDestroy {
  @Input() filterType: 'participating' | 'created' | 'other' = 'other';
  @Input() buttonType: 'view' | 'join' = 'join';

  userId: string | null = null;
  chats$?: Observable<Chat[]>;
  joinChatSubscription?: Subscription;

  constructor(private chatService: ChatService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.userId = this.route.snapshot.paramMap.get('userId');
  }

  ngOnInit(): void {
    this.chats$ = this.chatService.getAllChats();
  }

  ngOnDestroy(): void {
    this.joinChatSubscription?.unsubscribe();
  }

  filterChat(chat: Chat): boolean {
    if (!this.userId) {
      return false;
    }

    const isParticipant = chat.participantIds.includes(this.userId);
    const isCreator = chat.creatorUserId === this.userId;

    switch (this.filterType) {
      case 'participating':
        return isParticipant && !isCreator;
      case 'created':
        return !isParticipant && isCreator;
      case 'other':
        return !isParticipant && !isCreator;
      default:
        return false;
    }
  }

  viewChat(chat: Chat): void {
    if (this.userId) {
      if (chat.participantIds.includes(this.userId) && chat.creatorUserId != this.userId) {
        this.router.navigateByUrl(`${this.userId}/chats/${chat.id}`);
      }
      else if (!chat.participantIds.includes(this.userId) && chat.creatorUserId == this.userId) {
        this.router.navigateByUrl(`${this.userId}/chats/${chat.id}`);
      } 
    }
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
