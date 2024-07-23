import { provideRouter, Routes } from '@angular/router';
import LoginComponent from './component/login/login.component';

export const routes: Routes = [
	{
		path: 'login',
		component: LoginComponent,
	},
	{
		path: '',
		redirectTo: 'login',
		pathMatch: 'full',
	},
];

export const appRoutes = provideRouter(routes);
