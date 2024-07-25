import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';
import { ChatListComponent } from './features/chat/chat-list/chat-list.component';
import { AddChatComponent } from './features/chat/add-chat/add-chat.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'chats',
    component: ChatListComponent
  },
  {
    path: 'add-chat',
    component: AddChatComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
