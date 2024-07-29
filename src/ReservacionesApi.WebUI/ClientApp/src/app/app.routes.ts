import { provideRouter, Routes } from '@angular/router';
import { PageNotFoundComponent } from './common/component/page-not-found/page-not-found.component';
import { HomeComponent } from './common/component/home/home.component';
import { LoginComponent } from './login/component/login/login.component';

export const routes: Routes = [
	{
		path: 'login',
		component: LoginComponent,
	},
	{
		path: 'home',
		component: HomeComponent,
	},
	{
		path: '',
		redirectTo: '/home',
		pathMatch: 'full',
	},
	{
		path: '**',
		component: PageNotFoundComponent,
	},
];

export const appRoutes = provideRouter(routes);
