import { Component, inject } from '@angular/core';
import { UserLoginResponse, UserResponse } from '../../../model/dto/user/Response/UserResponse';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserLoginRequest } from '../../model/UserLoginRequest';
import { UserService } from '../../../product/data/services/user.service';

interface Diccionary<T> {
	[key: number]: T;
}

@Component({
	selector: 'app-login',
	standalone: true,
	imports: [ReactiveFormsModule, FormsModule],
	templateUrl: './login.component.html',
})
export class LoginComponent {
	public ApiResponse = {} as UserResponse<UserLoginResponse>;

	public IsErrorMessage = false;
	public IsSuccessMessage = false;

	// TODO: Injecion de dependencias
	private userService = inject(UserService);

	public user = {} as UserLoginRequest;

	public UserLogin(): void {
		this.userService.LoginAsync(this.user).subscribe((response) => {
			this.ApiResponse = response;
			this.DiccionaryStatusCode[this.ApiResponse.metadata.statusCode]();
		});
	}

	// TODO: Implementando un diccionario de status codes
	private DiccionaryStatusCode: Diccionary<() => void> = {
		200: () => {
			this.IsSuccessMessage = true;
		},
		401: () => {
			this.IsErrorMessage = true;
		},
	};
}
