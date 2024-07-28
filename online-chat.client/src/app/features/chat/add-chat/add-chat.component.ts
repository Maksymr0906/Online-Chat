import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ChatService } from 'src/app/core/services/chat/chat.service';
import { AddChatRequest } from 'src/app/shared/models/chat/add-chat-request.model';

@Component({
  selector: 'app-add-chat',
  templateUrl: './add-chat.component.html',
  styleUrls: ['./add-chat.component.css']
})
export class AddChatComponent implements OnInit, OnDestroy {
  addChatSubscription?: Subscription;
  model: AddChatRequest;
  userId: string | null = null;

  constructor(private chatService: ChatService,
    private route: ActivatedRoute,
    private router: Router) {
    this.model = {
      chatName: '',
      creatorUserId: '',
      createdTime: new Date(),
    }
  }

  onSubmit() {
    if (this.userId) {
      this.model.creatorUserId = this.userId;
      this.addChatSubscription = this.chatService.addChat(this.model).subscribe({
        next: (response) => {
          this.router.navigateByUrl(`${this.userId}`);
        }
      })
    }
  }

  ngOnInit(): void {
    this.userId = this.route.snapshot.paramMap.get('userId');
  }

  ngOnDestroy(): void {
    this.addChatSubscription?.unsubscribe();
  }
}
