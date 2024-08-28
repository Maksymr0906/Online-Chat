import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { MessageService } from 'src/app/core/services/message/message.service';
import { SignalRService } from 'src/app/core/services/signal-r/signal-r.service';
import { AddMessageRequest } from 'src/app/shared/models/message/add-message-request.model';

@Component({
  selector: 'app-add-message',
  templateUrl: './add-message.component.html',
  styleUrls: ['./add-message.component.css']
})
export class AddMessageComponent implements OnInit, OnDestroy {
  @Input() userId?: string | null;
  @Input() chatId?: string | null;

  model: AddMessageRequest = {
      content: '',
      userId: this.userId ?? '',
      chatId: this.chatId ?? '',
      sentTime: '',
  };
  addMessageSubscription?: Subscription;
  
  constructor(private messageService: MessageService, private signalrService: SignalRService) {
  }

  ngOnInit(): void {
     if (this.userId) {
      this.model.userId = this.userId;
     }
     if (this.chatId) {
      this.model.chatId = this.chatId;
     }
  }

  ngOnDestroy(): void {
    this.addMessageSubscription?.unsubscribe();
  }

  onSubmit() {
    if (this.model.content && this.userId && this.chatId) {
      this.model.sentTime = new Date().toLocaleString();

      this.addMessageSubscription = this.messageService.addMessage(this.model).subscribe(newMessage => {
        this.signalrService.sendMessage(newMessage);
        this.model.content = '';
      })
    }
  }
}
