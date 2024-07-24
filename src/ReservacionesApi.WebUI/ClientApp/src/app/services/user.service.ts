import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserLoginRequest } from '../model/dto/user/Request/UserLoginRequest';
import { UserLoginResponse, UserResponse } from '../model/dto/user/Response/UserResponse';
import { Observable } from 'rxjs';

@Injectable({
	providedIn: 'root',
})
export class UserService {
	private readonly url = 'http://localhost:5030/api/user';

	constructor(private http: HttpClient) {}

	/**
	 * Realiza el login de un usuario.
	 * @param user Datos del usuario para login.
	 * @returns Observable con la respuesta del servidor.
	 */
	public LoginAsync(user: UserLoginRequest): Observable<UserResponse<UserLoginResponse>> {
		const url = `${this.url}/login`;
		const response = this.http.post<UserResponse<UserLoginResponse>>(url, user);

		return response;
	}
}
