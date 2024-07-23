import { provideRouter, Routes } from '@angular/router';
import LoginComponent from './component/login/login.component';

export const routes: Routes = [
	{
		path: 'login',
		loadComponent: () => import('./component/login/login.component'),
	},
	{
		path: 'home',
		loadComponent: () => import('./component/home/home.component'),
	},
	{
		path: '',
		redirectTo: 'login',
		pathMatch: 'full',
	},
];

export const appRoutes = provideRouter(routes);
