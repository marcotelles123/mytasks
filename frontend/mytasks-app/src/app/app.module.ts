import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MytasksListComponent } from './mytasks-list/mytasks-list.component';
import { MytasksCreateComponent } from './mytasks-create/mytasks-create.component';
import { HttpClientModule } from '@angular/common/http';
import { MyTasksService } from './mytasks-service/mytasks.service';
import { MytasksUpdateComponent } from './mytasks-update/mytasks-update.component';

@NgModule({
  declarations: [
    AppComponent,
    MytasksListComponent,
    MytasksCreateComponent,
    MytasksUpdateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule, 
    ReactiveFormsModule,
  ],
  providers: [MyTasksService],
  bootstrap: [AppComponent]
})
export class AppModule { }
