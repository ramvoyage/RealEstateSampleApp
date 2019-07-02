import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddComponent } from './RealEstate/add/add.component';
import { EditComponent } from './RealEstate/edit/edit.component';

const routes: Routes = [
  { path: '', redirectTo: '/RealEstates', pathMatch: 'full' },
  { path: 'RealEstates/Create', component: AddComponent },  
  { path: 'RealEstates/Edit/:id', component: EditComponent },
  { path: 'RealEstate', redirectTo: '/RealEstates' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
