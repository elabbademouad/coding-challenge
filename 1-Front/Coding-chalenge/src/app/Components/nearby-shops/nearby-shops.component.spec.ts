import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NearbyShopsComponent } from './nearby-shops.component';

describe('NearbyShopsComponent', () => {
  let component: NearbyShopsComponent;
  let fixture: ComponentFixture<NearbyShopsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NearbyShopsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NearbyShopsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
