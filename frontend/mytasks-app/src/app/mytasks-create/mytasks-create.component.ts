import { Component } from '@angular/core';
import { MyTask } from '../mytasks-list/mytask.model';
import { MyTasksService } from '../mytasks-service/mytasks.service';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-mytasks-create',
  templateUrl: './mytasks-create.component.html',
  styleUrl: './mytasks-create.component.css'
})
export class MytasksCreateComponent {
  title: string = '';
  description: string = '';
  taskForm: FormGroup;
  
  constructor(private myTasksService: MyTasksService, private router: Router) {
    this.taskForm = new FormGroup({
      title: new FormControl('', Validators.required)
    });
  }
  private destroy$ = new Subject<void>();
  
  salvar() {
    const task: MyTask = {
      id: undefined,
      title: this.title,
      description: this.description,
      done: false
    };
  
    this.myTasksService.saveMyTask(task)
    .pipe(
      takeUntil(this.destroy$),
    )
    .subscribe({
      next: response => {
        console.log('MyTask was saved:', response);
        this.router.navigate(['/mystaskslist']);
      },
      error: error => {
        console.error('Error on saving MyTask:', error);
      }
    });
  }
}
