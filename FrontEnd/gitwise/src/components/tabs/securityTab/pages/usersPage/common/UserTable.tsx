import React from "react";
import {
	Table,
	TableBody,
	TableCell,
	TableContainer,
	TableHead,
	TableRow,
	Paper,
	Chip,
} from "@mui/material";
import { User } from "../../../../../../types/user.types";

interface UserTableProps {
	users: User[];
}

export const UserTable: React.FC<UserTableProps> = ({ users }) => {
	return (
		<TableContainer component={Paper}>
			<Table>
				<TableHead>
					<TableRow sx={{ backgroundColor: "#f5f5f5" }}>
						<TableCell sx={{ fontWeight: 600 }}>Email</TableCell>
						<TableCell sx={{ fontWeight: 600 }}>Status</TableCell>
						<TableCell sx={{ fontWeight: 600 }}>Role</TableCell>
					</TableRow>
				</TableHead>
				<TableBody>
					{users.map((user) => (
						<TableRow key={user.id}>
							<TableCell>{user.email}</TableCell>
							<TableCell>
								<Chip
									label={user.status}
									color="success"
									size="small"
									variant="outlined"
								/>
							</TableCell>
							<TableCell>{user.role}</TableCell>
						</TableRow>
					))}
				</TableBody>
			</Table>
		</TableContainer>
	);
};
