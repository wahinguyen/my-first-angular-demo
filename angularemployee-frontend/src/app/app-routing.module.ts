import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { DepartmentListComponent } from "./department-list/department-list.component";
import { EmployeesComponent } from "./employees/employees.component";
import { HomeComponent } from "./home/home.component";

//const departmentsModule = () => import('./departments/departments.module').then(x => x.DepartmentsModule);

const appRoutes:Routes = [
    {path: '', component: HomeComponent},
    {path: 'employees', component: EmployeesComponent},
    {path: 'departments', component: DepartmentListComponent},
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule {

}