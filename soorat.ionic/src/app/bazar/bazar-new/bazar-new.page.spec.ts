import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BazarNewPage } from './bazar-new.page';

describe('BazarNewPage', () => {
  let component: BazarNewPage;
  let fixture: ComponentFixture<BazarNewPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BazarNewPage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BazarNewPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
