import { Component } from '@angular/core';
import { MyTask } from './mytask.model';
import { MyTasksService } from '../mytasks-service/mytasks.service';
import { Subject, takeUntil } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-mytasks-list',
  templateUrl: './mytasks-list.component.html',
  styleUrl: './mytasks-list.component.css'
})
export class MytasksListComponent {
  tasks: MyTask[] = [];
  constructor(private myTasksService: MyTasksService, private router: Router) {}
  private destroy$ = new Subject<void>();
  isDone: boolean = true;

  ngOnInit() {
    this.myTasksService.getTasks().subscribe({
      next: response => {
       this.tasks = response;
      },
      error: error => {
        console.error('Error on getall MyTask:', error);
      }
    });
  }

  deleteTask(id: number|undefined) {
    this.myTasksService.deleteMyTask(id)
    .pipe(
      takeUntil(this.destroy$),
    )
    .subscribe({
      next: response => {
        console.log('MyTask was deleted:', response);
        this.myTasksService.getTasks().subscribe(tasks => {
          this.tasks = tasks;
        });
      },
      error: error => {
        console.error('Error on delete MyTask:', error);
      }
    });
  }

  markAsDone(id: number|undefined) {
    this.myTasksService.markAsDone(id, this.isDone)
    .pipe(
      takeUntil(this.destroy$),
    )
    .subscribe({
      next: response => {
        console.log('MyTask was deleted:', response);
        this.myTasksService.getTasks().subscribe(tasks => {
          this.tasks = tasks;
        });
      },
      error: error => {
        console.error('Error on delete MyTask:', error);
      }
    });
  }
}
