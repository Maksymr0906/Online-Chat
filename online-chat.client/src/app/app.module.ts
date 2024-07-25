import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './features/home/home.component';
import { ChatListComponent } from './features/chat/chat-list/chat-list.component';
import { AddChatComponent } from './features/chat/add-chat/add-chat.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ChatListComponent,
    AddChatComponent,
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
