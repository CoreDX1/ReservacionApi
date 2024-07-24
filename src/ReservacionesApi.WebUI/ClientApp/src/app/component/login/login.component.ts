import { Component, inject } from '@angular/core';
import { UserLoginResponse, UserResponse } from '../../model/dto/user/Response/UserResponse';
import { UserService } from '../../services/user.service';

@Component({
	selector: 'app-login',
	standalone: true,
	imports: [],
	templateUrl: './login.component.html',
})
export class LoginComponent {
	public ApiResponse = {} as UserResponse<UserLoginResponse>;

	private userService = inject(UserService);
}
