import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FeeditemComponent } from './feeditem.component';

describe('FeeditemComponent', () => {
  let component: FeeditemComponent;
  let fixture: ComponentFixture<FeeditemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FeeditemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FeeditemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
