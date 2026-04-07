import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PhographerManagerComponent } from './phographer-manager.component';

describe('PhographerManagerComponent', () => {
  let component: PhographerManagerComponent;
  let fixture: ComponentFixture<PhographerManagerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PhographerManagerComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PhographerManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
