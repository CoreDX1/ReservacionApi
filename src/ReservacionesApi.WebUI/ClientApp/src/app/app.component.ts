import { Component } from '@angular/core';
import { NavigationEnd, NavigationStart, Router, RouterOutlet } from '@angular/router';
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
	public title: string = 'Hola mundo 2222';

	public showHeader: boolean = true;
	public showFooter: boolean = true;

	private readonly excludeRoutes = ['/login', '/admin'];

	constructor(private router: Router) {
		router.events.subscribe((event) => {
			if (event instanceof NavigationStart) {
				// TODO: Implementar spinner de carga
				for (const route of this.excludeRoutes) {
					if (event.url.includes(route)) {
						this.showHeader = false;
						this.showFooter = false;
					}
				}
			}
		});
	}
}
