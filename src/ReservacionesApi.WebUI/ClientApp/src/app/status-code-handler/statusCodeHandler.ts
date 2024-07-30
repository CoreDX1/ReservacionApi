interface Diccionary<T> {
	[key: number]: T;
}

export class StatusCodeHandler {
	public static DiccionaryStatusCode: Diccionary<() => void> = {
		200: () => {
			console.log('Success');
		},
		401: () => {
			console.log('Unauthorized');
		},
	};
}
