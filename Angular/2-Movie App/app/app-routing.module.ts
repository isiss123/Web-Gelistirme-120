import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MoviesComponent} from './movies/movies.component'

const routes: Routes = [
  {path:'',redirectTo:'/dashboard',pathMatch:'full'}, // eger url girilmedise DASHBOARD gosterilir
  {path:'movies',component: MoviesComponent},
  {path:'dashboard',component: DashboardComponent},
]
@NgModule({
  exports:[RouterModule],
  imports: [RouterModule.forRoot(routes)]
})
export class AppRoutingModule { }
