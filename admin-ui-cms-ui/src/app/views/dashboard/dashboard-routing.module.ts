import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './dashboard.component';
import {AuthGuard} from 'src/app/shared/auth.guard';
const routes: Routes = [
  {
    path: 'dashboard',
    component: DashboardComponent,
    data: {
      title: `Trang chủ`,
      requiredPolicy: "Permisssions.Dashboard.View",
    },
    canActivate: [AuthGuard]
    
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule {
}
