import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MyTasksService } from '../mytasks-service/mytasks.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-mytasks-update',
  templateUrl: './mytasks-update.component.html',
  styleUrl: './mytasks-update.component.css'
})
export class MytasksUpdateComponent {
  taskId!: number;
  task: any;
  taskForm!: FormGroup;

  constructor(private route: ActivatedRoute, private taskService: MyTasksService, private router: Router) { }

  ngOnInit() {
    this.taskForm = new FormGroup({
      title: new FormControl('', Validators.required)
    });

    this.route.params.subscribe(params => {
      this.taskId = +params['id'];
      
      this.taskService.getMyTaskById(this.taskId).subscribe(task => {
        this.task = task;
        this.taskForm.patchValue(this.task);
      });
    });
    
  }

  onSubmit() {
    if (this.taskForm.valid) {
      const updatedTask = { ...this.task, ...this.taskForm.value };
      this.taskService.updateMyTask(updatedTask).subscribe(() => {
       console.log("Saved sucessfully!");
       this.router.navigate(['/mystaskslist']);
      });
    }
  }
}
