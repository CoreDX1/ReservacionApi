import { Component } from '@angular/core';
import { NavigationEnd, Router, RouterOutlet } from '@angular/router';
import { FooterComponent } from './component/footer/footer.component';
import { NgIf } from '@angular/common';
import { MenuComponent } from './component/menu/menu.component';
import { BehaviorSubject } from 'rxjs';

@Component({
	selector: 'app-root',
	standalone: true,
	imports: [RouterOutlet, FooterComponent, NgIf, MenuComponent],
	templateUrl: './app.component.html',
})
export class AppComponent {
	showHeader = false;
	showFooter = false;

	private readonly excludeRoutes = [
		{
			path: '/login',
			header: false,
			footer: false,
		},
		{
			path: '/admin',
			header: true,
			footer: true,
		},
		{
			path: '/home',
			header: true,
			footer: true,
		},
	];

	constructor(private router: Router) {
		router.events.subscribe((event) => {
			if (event instanceof NavigationEnd) {
				// TODO: Implementar spinner de carga
				const routeConfig = this.excludeRoutes.find((route) => route.path === event.url);

				if (routeConfig) {
					this.showHeader = routeConfig.header;
					this.showFooter = routeConfig.footer;
				}
			}
		});
	}
}
