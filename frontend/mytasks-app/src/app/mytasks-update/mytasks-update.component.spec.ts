import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MytasksUpdateComponent } from './mytasks-update.component';

describe('MytasksUpdateComponent', () => {
  let component: MytasksUpdateComponent;
  let fixture: ComponentFixture<MytasksUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MytasksUpdateComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MytasksUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
