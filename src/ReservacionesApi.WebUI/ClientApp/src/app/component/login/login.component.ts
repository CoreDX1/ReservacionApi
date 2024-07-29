import { Component, inject, OnInit } from '@angular/core';
import { UserLoginResponse, UserResponse } from '../../model/dto/user/Response/UserResponse';
import { UserService } from '../../services/user.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserLoginRequest } from '../../model/dto/user/Request/UserLoginRequest';

@Component({
	selector: 'app-login',
	standalone: true,
	imports: [ReactiveFormsModule, FormsModule],
	templateUrl: './login.component.html',
})
export class LoginComponent {
	public ApiResponse = {} as UserResponse<UserLoginResponse>;
	public IsErrorMessage = false;

	private userService = inject(UserService);

	public user: UserLoginRequest = {
		passwordHash: '',
		email: '',
	};

	public UserLogin() {
		this.userService.LoginAsync(this.user).subscribe((response) => {
			this.ApiResponse = response;
			this.IsErrorMessage = this.ApiResponse.errors.length > 0;
			console.log(this.ApiResponse);
		});
	}
}
