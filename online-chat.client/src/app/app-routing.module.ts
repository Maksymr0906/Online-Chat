import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';
import { AddChatComponent } from './features/chat/add-chat/add-chat.component';
import { DashboardComponent } from './features/dashboard/dashboard.component';
import { ChatRoomComponent } from './features/chat/chat-room/chat-room.component';
import { ParticipatingChatsListComponent } from './features/chat/participating-chats-list/participating-chats-list.component';
import { CreatedChatsListComponent } from './features/chat/created-chats-list/created-chats-list.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: ':userId',
    component: DashboardComponent
  },
  {
    path: ':userId/add-chat',
    component: AddChatComponent
  },
  {
    path: ':userId/chats/participating',
    component: ParticipatingChatsListComponent
  },
  {
    path: ':userId/chats/created',
    component: CreatedChatsListComponent
  },
  {
    path: ':userId/chats/:chatId',
    component: ChatRoomComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
