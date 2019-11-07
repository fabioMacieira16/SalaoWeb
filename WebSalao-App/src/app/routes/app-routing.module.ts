import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../auth/auth.guard';
import { UserComponent } from '../components/user/user.component';
import { LoginComponent } from '../components/user/login/login.component';
import { RegistrationComponent } from '../components/user/registration/registration.component';
import { ProdutosComponent } from '../components/Administrativo/cadasto/produtos/produtos.component';
import { EventosComponent } from '../components/eventos/eventos.component';
import { EventoEditComponent } from '../components/eventos/eventoEdit/eventoEdit.component';
import { PalestrantesComponent } from '../components/palestrantes/palestrantes.component';
import { DashboardComponent } from '../components/dashboard/dashboard.component';
import { ContatosComponent } from '../components/contatos/contatos.component';

const routes: Routes = [
  {
    path: 'user',
    component: UserComponent,
    children: [{ path: 'login', component: LoginComponent }, { path: 'registration', component: RegistrationComponent }]
  },
  { path: 'produtos', component: ProdutosComponent, canActivate: [AuthGuard] },
  { path: 'eventos', component: EventosComponent, canActivate: [AuthGuard] },
  { path: 'evento/:id/edit', component: EventoEditComponent, canActivate: [AuthGuard] },
  { path: 'palestrantes', component: PalestrantesComponent, canActivate: [AuthGuard] },
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] },
  { path: 'contatos', component: ContatosComponent, canActivate: [AuthGuard] },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
