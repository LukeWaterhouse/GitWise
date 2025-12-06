import React, { useState } from "react";
import {
	Box,
	Tabs,
	Tab,
	Typography,
	Table,
	TableBody,
	TableCell,
	TableContainer,
	TableHead,
	TableRow,
	Button,
	Modal,
	TextField,
	Select,
	MenuItem,
	FormControl,
	InputLabel,
	Stack,
	Paper,
	Chip,
} from "@mui/material";
import PeopleIcon from "@mui/icons-material/People";
import SecurityIcon from "@mui/icons-material/Security";
import HistoryIcon from "@mui/icons-material/History";
import AddIcon from "@mui/icons-material/Add";

const securitySections = [
	{ key: "users", label: "Users", icon: <PeopleIcon /> },
	{ key: "permissions", label: "Permissions", icon: <SecurityIcon /> },
	{ key: "audit", label: "Audit Log", icon: <HistoryIcon /> },
];

interface User {
	id: number;
	name: string;
	username: string;
	email: string;
	status: string;
	role: string;
}

const UsersSection: React.FC = () => {
	const [users, setUsers] = useState<User[]>([
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
	]);
	const [showAddUser, setShowAddUser] = useState(false);
	const [newUser, setNewUser] = useState({
		email: "",
		role: "User",
	});

	const handleAddUser = () => {
		if (newUser.email) {
			setUsers([
				...users,
				{
					id: users.length + 1,
					name: newUser.email.split("@")[0],
					username: newUser.email.split("@")[0],
					email: newUser.email,
					status: "Enabled",
					role: newUser.role,
				},
			]);
			setNewUser({ email: "", role: "User" });
			setShowAddUser(false);
		}
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
				<Button
					variant="contained"
					color="primary"
					startIcon={<AddIcon />}
					onClick={() => setShowAddUser(true)}
				>
					Add User
				</Button>
			</Box>

			<Modal open={showAddUser} onClose={() => setShowAddUser(false)}>
				<Paper
					sx={{
						position: "absolute",
						top: "50%",
						left: "50%",
						transform: "translate(-50%, -50%)",
						width: "90%",
						maxWidth: "500px",
						p: 4,
					}}
				>
					<Typography variant="h6" sx={{ mb: 3 }}>
						Add New User
					</Typography>
					<Stack spacing={2} sx={{ mb: 3 }}>
						<TextField
							label="Email"
							type="email"
							fullWidth
							value={newUser.email}
							onChange={(e) =>
								setNewUser({ ...newUser, email: e.target.value })
							}
							variant="outlined"
						/>
						<FormControl fullWidth>
							<InputLabel>Role</InputLabel>
							<Select
								value={newUser.role}
								label="Role"
								onChange={(e) =>
									setNewUser({ ...newUser, role: e.target.value })
								}
							>
								<MenuItem value="User">User</MenuItem>
								<MenuItem value="Admin">Admin</MenuItem>
							</Select>
						</FormControl>
					</Stack>
					<Stack direction="row" spacing={2} sx={{ justifyContent: "flex-end" }}>
						<Button
							variant="outlined"
							onClick={() => setShowAddUser(false)}
						>
							Cancel
						</Button>
						<Button
							variant="contained"
							color="primary"
							onClick={handleAddUser}
						>
							Add User
						</Button>
					</Stack>
				</Paper>
			</Modal>

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
		</Box>
	);
};

const sectionContent: Record<string, React.ReactNode> = {
	users: <UsersSection />,
	permissions: (
		<Box>
			<Typography variant="h6">Permissions</Typography>
			<Typography variant="body2" color="textSecondary" sx={{ mt: 1 }}>
				Manage user permissions and access controls.
			</Typography>
		</Box>
	),
	audit: (
		<Box>
			<Typography variant="h6">Audit Log</Typography>
			<Typography variant="body2" color="textSecondary" sx={{ mt: 1 }}>
				View system audit logs and activity history.
			</Typography>
		</Box>
	),
};

const SecurityPage: React.FC = () => {
	const [selected, setSelected] = useState(0);

	const handleTabChange = (event: React.SyntheticEvent, newValue: number) => {
		setSelected(newValue);
	};

	return (
		<Box sx={{ display: "flex", flexDirection: "column", minHeight: "100%" }}>
			<Paper
				elevation={0}
				sx={{
					borderBottom: "1px solid #e0e0e0",
					backgroundColor: "#fff",
					mb: 0,
				}}
			>
				<Tabs
					value={selected}
					onChange={handleTabChange}
					variant="scrollable"
					scrollButtons="auto"
					sx={{
						"& .MuiTab-root": {
							minHeight: "60px",
							display: "flex",
							flexDirection: "column",
							alignItems: "center",
							gap: "8px",
							textTransform: "none",
							fontSize: "14px",
						},
						"& .MuiTabs-indicator": {
							height: "3px",
							backgroundColor: "#0066ff",
						},
					}}
				>
					{securitySections.map((section) => (
						<Tab
							key={section.key}
							label={
								<Box
									sx={{
										display: "flex",
										flexDirection: "column",
										alignItems: "center",
										gap: "4px",
									}}
								>
									<Box sx={{ fontSize: "20px" }}>{section.icon}</Box>
								</Box>
							}
						/>
					))}
				</Tabs>
			</Paper>

			<Box
				component="main"
				sx={{
					flex: 1,
					p: 4,
					backgroundColor: "#fff",
					overflowY: "auto",
				}}
			>
				{sectionContent[securitySections[selected].key]}
			</Box>
		</Box>
	);
};

export default SecurityPage;
