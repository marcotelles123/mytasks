import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MytasksCreateComponent } from './mytasks-create.component';

describe('MytasksCreateComponent', () => {
  let component: MytasksCreateComponent;
  let fixture: ComponentFixture<MytasksCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MytasksCreateComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MytasksCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
