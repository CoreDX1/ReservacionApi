import { Component } from '@angular/core';
import { NavigationStart, Router, RouterOutlet } from '@angular/router';
import { MenuComponent } from './component/menu/menu.component';
import { FooterComponent } from './component/footer/footer.component';
import { NgIf } from '@angular/common';

@Component({
	selector: 'app-root',
	standalone: true,
	imports: [RouterOutlet, MenuComponent, FooterComponent, NgIf],
	templateUrl: './app.component.html',
})
export class AppComponent {
	showHeader = true;
	showFooter = true;

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
			if (event instanceof NavigationStart) {
				// TODO: Implementar spinner de carga
				for (const route of this.excludeRoutes) {
					if (event.url == route.path) {
						this.showHeader = route.header;
						this.showFooter = route.footer;
					}
				}
			}
		});
	}
}
