import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './features/home/home.component';
import { ChatListComponent } from './features/chat/chat-list/chat-list.component';
import { AddChatComponent } from './features/chat/add-chat/add-chat.component';
import { DashboardComponent } from './features/dashboard/dashboard.component';
import { ChatRoomComponent } from './features/chat/chat-room/chat-room.component';
import { MessageComponent } from './features/message/message/message.component';
import { CreatedChatsListComponent } from './features/chat/created-chats-list/created-chats-list.component';
import { ParticipatingChatsListComponent } from './features/chat/participating-chats-list/participating-chats-list.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ChatListComponent,
    AddChatComponent,
    DashboardComponent,
    ChatRoomComponent,
    MessageComponent,
    CreatedChatsListComponent,
    ParticipatingChatsListComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
