import { NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
	selector: 'app-menu',
	standalone: true,
	imports: [NgIf],
	templateUrl: './menu.component.html',
})
export class MenuComponent {
	menuOpen = false;

	constructor(private router: Router) {}
	readonly link = MenuRoutes;

	navegar(path: string) {
		this.router.navigate([path]);
	}

	toggleMunu() {
		this.menuOpen = !this.menuOpen;
	}
}

export enum MenuRoutes {
	Home = '/home',
	Login = '/login',
	Admin = '/admin',
	Men = '/men',
	Women = '/women',
	Kids = '/kids',
}
