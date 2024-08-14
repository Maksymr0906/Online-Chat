import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ChatService } from 'src/app/core/services/chat/chat.service';
import { Chat } from 'src/app/shared/models/chat/chat.model';

@Component({
  selector: 'app-participating-chats-list',
  templateUrl: './participating-chats-list.component.html',
  styleUrls: ['./participating-chats-list.component.css']
})

export class ParticipatingChatsListComponent {

}
