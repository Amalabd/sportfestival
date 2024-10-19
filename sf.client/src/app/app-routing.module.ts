import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {ClassListComponent} from './sf/class/list/class-list.component';
import {AppPaths} from './app-paths';
import {ClassDetailComponent} from "./sf/class/detail/class-detail.component";
import {HomeComponent} from "./common/home/home.component";
import { StudentPageComponent } from './student-page/student-page.component';
import { TeacherPageComponent } from './teacher-page/teacher-page.component';
import { MainLayoutComponent } from './main-layout/main-layout.component';

const routes: Routes = [
    {path: '', redirectTo: AppPaths.mainLayout, pathMatch: 'full'},
    // {path: '**', redirectTo: AppPaths.home},
    {path: AppPaths.home, component: HomeComponent, pathMatch: 'full'},
    {path: AppPaths.classBase, redirectTo: AppPaths.classBase + AppPaths.list, pathMatch: 'full'},
    {path: AppPaths.classBase + AppPaths.list, component: ClassListComponent},
    {path: AppPaths.classBase + AppPaths.detail, component: ClassDetailComponent},
    // {path: AppPaths.schoolBase, redirectTo: AppPaths.schoolBase + AppPaths.list, pathMatch: 'full'},
    // {path: AppPaths.schoolBase + AppPaths.list, component: SchoolListComponent}
    { path: 'studentPage', component: StudentPageComponent },
    {path: AppPaths.teacherPage, component:TeacherPageComponent, pathMatch:'full'},
    {path: AppPaths.mainLayout,component: MainLayoutComponent, pathMatch:'full',
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {
}
