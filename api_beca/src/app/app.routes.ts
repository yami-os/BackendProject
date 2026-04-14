import { Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login';
import { RegistroComponent } from './pages/registro/registro';
import { PortadaComponent } from './pages/portada/portada';

export const routes: Routes = [


  { path: '', redirectTo: 'portada', pathMatch: 'full' },


  { path: 'portada', component: PortadaComponent },
  { path: 'login', component: LoginComponent },
  { path: 'registro', component: RegistroComponent },


  {
    path: 'admin',
    loadComponent: () => import('./pages/administrador/administrador')
      .then(m => m.AdministradorComponent)
  },

  {
    path: 'solicitudes',
    loadComponent: () => import('./pages/solicitud/solicitud')
      .then(m => m.SolicitudComponent)
  },

  { path: '**', redirectTo: 'portada' }
];