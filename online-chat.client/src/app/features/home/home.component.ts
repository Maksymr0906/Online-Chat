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

  joinChat() {
    this.userService.getUserByName(this.name).subscribe(user => {
      if (user) {
        this.router.navigate([`/${user.id}`]);
      } else {
        const addUserRequest: AddUserRequest = {
          userName: this.name
        };

        this.userService.addUser(addUserRequest).subscribe(newUser => {
          this.router.navigate([`/${newUser.id}`]);
        });
      }
    });
  }

  ngOnDestroy(): void {
    this.getUserByNameSubscription?.unsubscribe();
    this.addUserSubscription?.unsubscribe();
  }
}
