export interface User {
	id: number;
	name: string;
	username: string;
	email: string;
	status: "Enabled" | "Disabled";
	role: "User" | "Admin";
}

export interface CreateUserInput {
	email: string;
	role: "User" | "Admin";
}

export interface UpdateUserInput extends Partial<CreateUserInput> {
	id: number;
}
