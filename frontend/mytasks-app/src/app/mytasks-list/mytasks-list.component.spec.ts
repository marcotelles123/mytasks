import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MytasksListComponent } from './mytasks-list.component';

describe('MytasksListComponent', () => {
  let component: MytasksListComponent;
  let fixture: ComponentFixture<MytasksListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MytasksListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MytasksListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
