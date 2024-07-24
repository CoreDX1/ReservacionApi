export interface UserResponse<T> {
	data: T;
	metadata: Metadata;
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
