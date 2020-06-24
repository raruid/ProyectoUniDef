import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { UsersComponent } from './users/users.component';
import { EventosComponent } from './eventos/eventos.component';
import { TenantsComponent } from './tenants/tenants.component';
import { RolesComponent } from 'app/roles/roles.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { CatalogoComponent } from './catalogo/catalogo.component';
import { ExtUserProfileComponent } from './ext-user.profile/ext-user-profile.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                    { path: 'home', component: HomeComponent,  canActivate: [AppRouteGuard] },
                    { path: 'usuarios', component: UsersComponent, data: { permission: 'Pages.Users' }, canActivate: [AppRouteGuard] },
                    { path: 'roles', component: RolesComponent, data: { permission: 'Pages.Roles' }, canActivate: [AppRouteGuard] },
                    { path: 'tenants', component: TenantsComponent, data: { permission: 'Pages.Tenants' }, canActivate: [AppRouteGuard] },
                    { path: 'catalogo/evento/:id', component: EventosComponent, data: { permission: 'Pages.Eventos' }},
                    { path: 'usuarios/:id', component: ExtUserProfileComponent, data: { permission: 'Pages.Users' }},
                    { path: 'perfil', component: UserProfileComponent, data: { permission: 'Pages.Users' }},
                    { path: 'catalogo', component: CatalogoComponent, data: { permission: 'Pages.Users' }},
                    { path: 'about', component: AboutComponent },
                    { path: 'update-password', component: ChangePasswordComponent }
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
