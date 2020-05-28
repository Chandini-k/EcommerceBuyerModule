import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BuyitemComponent } from './buyitem.component';

describe('BuyitemComponent', () => {
  let component: BuyitemComponent;
  let fixture: ComponentFixture<BuyitemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BuyitemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BuyitemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
