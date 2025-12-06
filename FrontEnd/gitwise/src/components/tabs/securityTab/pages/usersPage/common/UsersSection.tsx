// Moved from features/users/UsersSection.tsx
import React from "react";
import { Box, Typography } from "@mui/material";
import { useUsers } from "../../../../../../hooks";
import { AddUserModal } from "./AddUserModal";
import { UserTable } from "./UserTable";
import { CreateUserInput } from "../../../../../../types/user.types";

const UsersSection: React.FC = () => {
	const { users, addUser, loading } = useUsers();

	const handleAddUser = (newUser: CreateUserInput) => {
		addUser(newUser);
	};

	return (
		<Box>
			<Box
				sx={{
					display: "flex",
					justifyContent: "space-between",
					alignItems: "center",
					mb: 3,
				}}
			>
				<Typography variant="h6">User Information</Typography>
				<AddUserModal onAddUser={handleAddUser} loading={loading} />
			</Box>
			<UserTable users={users} />
		</Box>
	);
};

export default UsersSection;
