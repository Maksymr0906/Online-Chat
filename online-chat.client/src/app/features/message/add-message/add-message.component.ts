import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { MessageService } from 'src/app/core/services/message/message.service';
import { AddMessageRequest } from 'src/app/shared/models/message/add-message-request.model';

@Component({
  selector: 'app-add-message',
  templateUrl: './add-message.component.html',
  styleUrls: ['./add-message.component.css']
})
export class AddMessageComponent implements OnInit, OnDestroy {
  @Input() userId?: string | null;
  @Input() chatId?: string | null;

  model: AddMessageRequest;
  addMessageSubscription?: Subscription;

  constructor(private messageService: MessageService) {
    this.model = {
      content: '',
      userId: this.userId ?? '',
      chatId: this.chatId ?? '',
      sentTime: new Date(),
    };
  }

   ngOnInit(): void {
    if (this.userId && this.chatId) {
      this.model.userId = this.userId;
      this.model.chatId = this.chatId;
    }
  }

  onSubmit() {
    if (this.model.content && this.userId && this.chatId) {
      this.model.sentTime = new Date();
    
      this.addMessageSubscription = this.messageService.addMessage(this.model).subscribe({
        next: (response) => {
          this.model.content = '';
        }
      });
    }
  }
  
  ngOnDestroy(): void {
    this.addMessageSubscription?.unsubscribe();
  }
}
