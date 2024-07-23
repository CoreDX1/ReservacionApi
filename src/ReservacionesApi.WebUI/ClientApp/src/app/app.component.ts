import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MenuComponent } from './component/menu/menu.component';
import { FooterComponent } from './component/footer/footer.component';

@Component({
	selector: 'app-root',
	standalone: true,
	imports: [RouterOutlet, MenuComponent, FooterComponent],
	templateUrl: './app.component.html',
})
export class AppComponent {
	public title: string = 'Hola mundo 2222';
}
