
import { Routes } from '@angular/router';
import { PortadaComponent } from './pages/portada/portada';
import { LoginComponent } from './pages/login/login';
import { RegistroComponent } from './pages/registro/registro';
import { ConvocatoriaComponent } from './pages/convocatoria/convocatoria';
import { ReporteService} from './pages/reportes/reportes';

export const routes: Routes = [
 
  { 
    path: '', component: PortadaComponent
   },
  

  { 
    path: 'login', component: LoginComponent 
  },
  { 
    path: 'registro', component: RegistroComponent
   },
  

  { 
    path: 'convocatoria', component: ConvocatoriaComponent 
  },
  { 
    path: 'reporte', component: ReporteService
   },

  
  { 
    path: '**', redirectTo: '', pathMatch: 'full' 
  }
];