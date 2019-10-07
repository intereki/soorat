import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BazarDetailPage } from './bazar-detail.page';

describe('BazarDetailPage', () => {
  let component: BazarDetailPage;
  let fixture: ComponentFixture<BazarDetailPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BazarDetailPage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BazarDetailPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
