import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MyTask } from '../mytasks-list/mytask.model'; 

@Injectable({
  providedIn: 'root'
})
export class MyTasksService {
  private apiUrl = 'http://localhost:7173/MyTasks/'; 
  //private apiUrl = 'http://localhost:8080/MyTasks/'; 

  constructor(private http: HttpClient) { }

  getTasks(): Observable<MyTask[]> {
    return this.http.get<MyTask[]>(this.apiUrl+'GetAllTasks');
  }

  saveMyTask(task: MyTask): Observable<any> {
    return this.http.post<any>(this.apiUrl+'Create', task);
  }

  deleteMyTask(id: number|undefined): Observable<any> {
    return this.http.delete<any>(this.apiUrl+'Delete/'+id);
  }

  markAsDone(id: number|undefined, isDone:boolean|undefined): Observable<any> {
    return this.http.patch<any>(this.apiUrl+'markAsDone/'+id, {"Done": isDone});
  }

  getMyTaskById(id: number): Observable<MyTask> {
    return this.http.get<MyTask>(this.apiUrl+'GetById/'+id);
  }

  updateMyTask(task: MyTask): Observable<MyTask> {
    return this.http.put<any>(this.apiUrl+'Update', task);
  }
}