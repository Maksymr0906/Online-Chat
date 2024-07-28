import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParticipatingChatsListComponent } from './participating-chats-list.component';

describe('ParticipatingChatsListComponent', () => {
  let component: ParticipatingChatsListComponent;
  let fixture: ComponentFixture<ParticipatingChatsListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ParticipatingChatsListComponent]
    });
    fixture = TestBed.createComponent(ParticipatingChatsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
