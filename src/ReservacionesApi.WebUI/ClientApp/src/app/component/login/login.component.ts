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
export class LoginComponent implements OnInit {
	public ApiResponse = {} as UserResponse<UserLoginResponse>;

	private userService = inject(UserService);

	public user: UserLoginRequest = {
		passwordHash: 'index#123',
		email: 'chismaquis@hotmail.com',
	};

	ngOnInit(): void {
		this.UserLogin(this.user);
		console.log(this.ApiResponse);
	}

	public UserLogin(user: UserLoginRequest) {
		this.userService.LoginAsync(user).subscribe((response) => {
			this.ApiResponse = response;
			console.log(this.ApiResponse);
		});
	}
}
