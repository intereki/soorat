import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BazarListPage } from './bazar-list.page';

describe('BazarListPage', () => {
  let component: BazarListPage;
  let fixture: ComponentFixture<BazarListPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BazarListPage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BazarListPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
