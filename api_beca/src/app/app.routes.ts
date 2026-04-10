import { Routes } from '@angular/router';
import { PortadaComponent } from './pages/portada/portada';
import { LoginComponent } from './pages/login/login';
import { RegistroComponent } from './pages/registro/registro';
import { ConvocatoriaComponent } from './pages/convocatoria/convocatoria';
import { SolicitudComponent } from './pages/solicitud/solicitud';


export const routes: Routes = [

  { path: '', component: PortadaComponent },

  { path: 'login', component: LoginComponent },

  { path: 'registro', component: RegistroComponent },

  { path: 'convocatoria', component: ConvocatoriaComponent },

  
  { path: 'solicitud', component: SolicitudComponent },


  { path: 'admin', loadComponent: () => import('./pages/administrador/administrador').then(m => m.AdministradorComponent) },

  { path: 'estudiante', loadComponent: () => import('./pages/estudiante/estudiante').then(m => m.EstudianteComponent) },

  { path: '**', redirectTo: '', pathMatch: 'full' }

];