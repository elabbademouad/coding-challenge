import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PreferrdShopsComponent } from './preferrd-shops.component';

describe('PreferrdShopsComponent', () => {
  let component: PreferrdShopsComponent;
  let fixture: ComponentFixture<PreferrdShopsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PreferrdShopsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PreferrdShopsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
