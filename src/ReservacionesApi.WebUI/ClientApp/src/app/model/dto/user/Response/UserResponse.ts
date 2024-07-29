export interface UserResponse<T> {
	data: T;
	metadata: Metadata;
	errors: string[];
	loginErrors: LoginErrors;
}

export interface UserLoginResponse {
	id: number;
	name: string;
	email: string;
	fullName: string;
	phoneNumber: string;
}

interface Metadata {
	statusCode: number;
	message: string;
}

interface LoginErrors {
	emailErorrs: Array<string>;
	passwordErorrs: Array<string>;
}
