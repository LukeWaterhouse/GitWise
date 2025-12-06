import { useState, useCallback } from "react";
import { User, CreateUserInput } from "../types/user.types";

const INITIAL_USERS: User[] = [
	{
		id: 1,
		name: "Dylan Williams",
		username: "dwilliams@fluence.app",
		email: "dwilliams@fluencetech.com",
		status: "Enabled",
		role: "Admin",
	},
	{
		id: 2,
		name: "Gail Smith",
		username: "gsmith@fluence.app",
		email: "gail.smith@anaplan.com",
		status: "Enabled",
		role: "Admin",
	},
	{
		id: 3,
		name: "Luke Waterhouse",
		username: "luke.waterhouse@fluence.app",
		email: "luke.waterhouse@anaplan.com",
		status: "Enabled",
		role: "Admin",
	},
];

export const useUsers = () => {
	const [users, setUsers] = useState<User[]>(INITIAL_USERS);
	const [loading, setLoading] = useState(false);
	const [error, setError] = useState<string | null>(null);

	const addUser = useCallback((newUserInput: CreateUserInput) => {
		try {
			setLoading(true);
			const newUser: User = {
				id: Math.max(...users.map(u => u.id), 0) + 1,
				name: newUserInput.email.split("@")[0],
				username: newUserInput.email.split("@")[0],
				email: newUserInput.email,
				status: "Enabled",
				role: newUserInput.role,
			};
			setUsers(prev => [...prev, newUser]);
			setError(null);
			return newUser;
		} catch (err) {
			const errorMessage = err instanceof Error ? err.message : "Failed to add user";
			setError(errorMessage);
			throw err;
		} finally {
			setLoading(false);
		}
	}, [users]);

	const deleteUser = useCallback((id: number) => {
		setUsers(prev => prev.filter(user => user.id !== id));
	}, []);

	const updateUser = useCallback((id: number, updates: Partial<User>) => {
		setUsers(prev =>
			prev.map(user => (user.id === id ? { ...user, ...updates } : user))
		);
	}, []);

	return {
		users,
		loading,
		error,
		addUser,
		deleteUser,
		updateUser,
	};
};
