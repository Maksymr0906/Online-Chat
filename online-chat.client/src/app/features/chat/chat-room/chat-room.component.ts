import { AfterViewChecked, Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ChatService } from 'src/app/core/services/chat/chat.service';
import { MessageService } from 'src/app/core/services/message/message.service';
import { SignalRService } from 'src/app/core/services/signal-r/signal-r.service';
import { RemoveUserFromChatRequest } from 'src/app/shared/models/chat/remove-user-from-chat-request.model';
import { Message } from 'src/app/shared/models/message/message.model';

@Component({
  selector: 'app-chat-room',
  templateUrl: './chat-room.component.html',
  styleUrls: ['./chat-room.component.css']
})
export class ChatRoomComponent implements OnInit, OnDestroy, AfterViewChecked  {
  @ViewChild('messagesContainer') private messagesContainer?: ElementRef;

  messages: Message[] = [];
  userId: string | null = null;
  chatId: string | null = null;
  isAnyMessage: boolean = true;

  getAllMessagesSubscription?: Subscription;
  messageReceivedSubscription?: Subscription;

  constructor(
    private chatService: ChatService,
    private messageService: MessageService,
    private signalrService: SignalRService,
    private router: Router,
    private route: ActivatedRoute) {
    this.userId = this.route.snapshot.paramMap.get('userId');
    this.chatId = this.route.snapshot.paramMap.get('chatId');
  }

  ngOnInit(): void {
    if (this.chatId) {      
      this.getAllMessagesSubscription = this.messageService.getAllChatMessages(this.chatId).subscribe(messages => {
        this.messages = messages.sort((a, b) => new Date(a.sentTime).getTime() - new Date(b.sentTime).getTime());
        this.isAnyMessage = this.messages.length > 0;
      });

      this.signalrService.startConnection();
      this.messageReceivedSubscription = this.signalrService.messageReceived$.subscribe((message) => {
        if (message && message.chatId === this.chatId) {
          this.messages.push(message);
        }
      });
    }
  }

  ngOnDestroy(): void {
    this.getAllMessagesSubscription?.unsubscribe();
    this.messageReceivedSubscription?.unsubscribe();
    this.signalrService.disconnect();
  }

  ngAfterViewChecked(): void {
    this.scrollToBottom();
  }
  
  scrollToBottom(): void {
    if (this.messagesContainer && this.messagesContainer.nativeElement) {
      this.messagesContainer.nativeElement.scrollTop = this.messagesContainer.nativeElement.scrollHeight;
    }
  }

  leaveChat() {
    if (this.userId && this.chatId) {
      const model: RemoveUserFromChatRequest = {
        userId: this.userId
      };

      this.chatService.removeUserFromChat(this.chatId, model).subscribe(() => {
        this.router.navigateByUrl(`${this.userId}`);
      });
    }
  }

  getMessageClass(messageUserId: string): string {
    return messageUserId === this.userId
      ? 'current-user-message'
      : 'other-user-message';
  }
}
