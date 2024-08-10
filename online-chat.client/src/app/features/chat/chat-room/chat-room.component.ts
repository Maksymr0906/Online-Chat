import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ChatService } from 'src/app/core/services/chat/chat.service';
import { MessageService } from 'src/app/core/services/message/message.service';
import { RemoveUserFromChatRequest } from 'src/app/shared/models/chat/remove-user-from-chat-request.model';
import { Message } from 'src/app/shared/models/message/message.model';

@Component({
  selector: 'app-chat-room',
  templateUrl: './chat-room.component.html',
  styleUrls: ['./chat-room.component.css']
})
export class ChatRoomComponent implements OnInit, OnDestroy{
  userId: string | null = null;
  chatId: string | null = null;
  getAllMessagesSubscription?: Subscription;
  messages?: Message[];

  constructor(private chatService: ChatService, private messageService: MessageService, private router: Router, private route: ActivatedRoute) {
    this.userId = this.route.snapshot.paramMap.get('userId');
    this.chatId = this.route.snapshot.paramMap.get('chatId');
  }

  ngOnInit(): void {
    if (this.chatId) {
      this.getAllMessagesSubscription = this.messageService.getAllChatMessages(this.chatId).subscribe({
        next: (response) => {
          this.messages = response.sort((a, b) => {
            return new Date(a.sentTime).getTime() - new Date(b.sentTime).getTime();
          });
        }
      });
    }
  }
  
  ngOnDestroy(): void {
    this.getAllMessagesSubscription?.unsubscribe();
  }

  leaveChat() {
    if (this.userId && this.chatId) {
      const model: RemoveUserFromChatRequest = {
        userId: this.userId
      };

      this.chatService.removeUserFromChat(this.chatId, model).subscribe({
        next: (response) => {
          this.router.navigateByUrl(`${this.userId}`);
        }
      })
    }
  }

  getMessageClass(messageUserId: string): string {
    return messageUserId === this.userId
      ? 'current-user-message'
      : 'other-user-message';
  }
}
