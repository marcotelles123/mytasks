import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MytasksListComponent } from './mytasks-list/mytasks-list.component';
import { MytasksCreateComponent } from './mytasks-create/mytasks-create.component';
import { MytasksUpdateComponent } from './mytasks-update/mytasks-update.component';

const routes: Routes = [
  { path: '', redirectTo: 'mystaskslist', pathMatch: 'full' },
  { path: 'mystaskslist', component: MytasksListComponent },
  { path: 'mystaskscreate', component: MytasksCreateComponent },
  { path: 'mytasksupdate/:id', component: MytasksUpdateComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
