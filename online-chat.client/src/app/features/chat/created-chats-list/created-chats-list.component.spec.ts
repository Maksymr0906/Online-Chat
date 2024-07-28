import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatedChatsListComponent } from './created-chats-list.component';

describe('CreatedChatsListComponent', () => {
  let component: CreatedChatsListComponent;
  let fixture: ComponentFixture<CreatedChatsListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CreatedChatsListComponent]
    });
    fixture = TestBed.createComponent(CreatedChatsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
