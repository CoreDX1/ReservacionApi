export interface UserResponse<T> {
	data: T;
	metadata: Metadata;
	errors: string[];
	loginErrors: LoginErrors;
}

interface Metadata {
	statusCode: number;
	message: string;
}

interface LoginErrors {
	emailErorrs: Array<string>;
	passwordErorrs: Array<string>;
}
