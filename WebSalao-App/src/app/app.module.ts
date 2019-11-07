import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule, TooltipModule, ModalModule, BsDatepickerModule, TabsModule } from 'ngx-bootstrap';
import { AppRoutingModule } from './routes/app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxMaskModule } from 'ngx-mask';
import { NgxCurrencyModule } from 'ngx-currency';
import { ToastrModule } from 'ngx-toastr';

import { EventoService } from './services/evento.service';
import { ProdutoService } from './services/_administrativo/produto.service';

import { AppComponent } from './app.component';
import { NavComponent } from './components/nav/nav.component';
import { EventosComponent } from './components/eventos/eventos.component';
import { EventoEditComponent } from './components/eventos/eventoEdit/eventoEdit.component';
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ContatosComponent } from './components/contatos/contatos.component';
import { TituloComponent } from './components/titulo/titulo.component';

import { DateTimeFormatPipePipe } from './pipes/DateTimeFormatPipe.pipe';
import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';
import { AuthInterceptor } from './auth/auth.interceptor';
import { CadastoComponent } from './components/Administrativo/cadasto/cadasto.component';
import { ClientesComponent } from './components/Administrativo/cadasto/clientes/clientes.component';
import { ProdutosComponent } from './components/Administrativo/cadasto/produtos/produtos.component';
import { FornecedoresComponent } from './components/Administrativo/cadasto/fornecedores/fornecedores.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    EventosComponent,
    EventoEditComponent,
    PalestrantesComponent,
    DashboardComponent,
    ContatosComponent,
    TituloComponent,
    UserComponent,
    LoginComponent,
    RegistrationComponent,
    DateTimeFormatPipePipe,
    CadastoComponent,
    ClientesComponent,
    ProdutosComponent,
    FornecedoresComponent
  ],
  imports: [
    BrowserModule,
    BsDropdownModule.forRoot(),
    BsDatepickerModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    TabsModule.forRoot(),
    NgxMaskModule.forRoot(),
    NgxCurrencyModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 3000,
      preventDuplicates: true,
      progressBar: true
    }),
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    EventoService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },

    ProdutoService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
