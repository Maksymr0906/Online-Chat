import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { UserService } from 'src/app/core/services/user/user.service';
import { AddUserRequest } from 'src/app/shared/models/user/add-user-request.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnDestroy {
  name: string;
  addUserSubscription?: Subscription;
  getUserByNameSubscription?: Subscription;

  constructor(private userService: UserService, private router: Router) {
    this.name = '';
  }

  enterChat() {
    this.getUserByNameSubscription = this.userService.getUserByName(this.name).subscribe({
      next: (response) => {
        if (!response) {
          const model: AddUserRequest = {
            userName: this.name
          };

          this.addUserSubscription = this.userService.addUser(model).subscribe();

          console.log("New user created");
        }

        this.router.navigateByUrl('chats');
      }
    })
  }

  ngOnDestroy(): void {
    this.getUserByNameSubscription?.unsubscribe();
    this.addUserSubscription?.unsubscribe();
  }
}
