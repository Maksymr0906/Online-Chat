import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { UserService } from 'src/app/core/services/user/user.service';
import { Message } from 'src/app/shared/models/message/message.model';
import { User } from 'src/app/shared/models/user/user.model';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.css']
})
export class MessageComponent implements OnInit, OnDestroy {
  @Input() message?: Message | null;
  @Input() currentUserId?: string | null;
  currentUser?: User;
  user?: User;
  getCurrentUserByIdSubscription?: Subscription;
  getUserByIdSubscription?: Subscription;

  constructor(private userService: UserService) {
    
  }

  ngOnInit(): void {
    if (this.currentUserId) {
      this.getCurrentUserByIdSubscription = this.userService.getUserById(this.currentUserId).subscribe({
        next: (response) => {
          this.currentUser = response;
        }
      })
    }

    if (this.message?.userId) {
      this.getCurrentUserByIdSubscription = this.userService.getUserById(this.message.userId).subscribe({
        next: (response) => {
          this.user = response;
        }
      })
    }
  }
  
  ngOnDestroy(): void {
    this.getCurrentUserByIdSubscription?.unsubscribe();
    this.getUserByIdSubscription?.unsubscribe();
  }

  isCurrentUser(): boolean {
    if (this.user) {
      return this.user.id === this.currentUserId;
    }
    
    return false;
  }
}
