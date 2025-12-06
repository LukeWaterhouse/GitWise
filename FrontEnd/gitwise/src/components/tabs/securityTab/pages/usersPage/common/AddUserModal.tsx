import React, { useState } from "react";
import {
	Button,
	Modal,
	Paper,
	TextField,
	Select,
	MenuItem,
	FormControl,
	InputLabel,
	Stack,
	Typography,
} from "@mui/material";
import AddIcon from "@mui/icons-material/Add";
import { CreateUserInput } from "../../../../../../types/user.types";

interface AddUserModalProps {
	onAddUser: (user: CreateUserInput) => void;
	loading?: boolean;
}

export const AddUserModal: React.FC<AddUserModalProps> = ({ onAddUser, loading = false }) => {
	const [open, setOpen] = useState(false);
	const [formData, setFormData] = useState<CreateUserInput>({
		email: "",
		role: "User",
	});

	const handleOpen = () => setOpen(true);
	const handleClose = () => {
		setOpen(false);
		setFormData({ email: "", role: "User" });
	};

	const handleSubmit = () => {
		if (formData.email.trim()) {
			onAddUser(formData);
			handleClose();
		}
	};

	return (
		<>
			<Button
				variant="contained"
				color="primary"
				startIcon={<AddIcon />}
				onClick={handleOpen}
			>
				Add User
			</Button>

			<Modal open={open} onClose={handleClose}>
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
							value={formData.email}
							onChange={(e) =>
								setFormData({ ...formData, email: e.target.value })
							}
							variant="outlined"
							disabled={loading}
						/>
						<FormControl fullWidth>
							<InputLabel>Role</InputLabel>
							<Select
								value={formData.role}
								label="Role"
								onChange={(e) =>
									setFormData({ ...formData, role: e.target.value })
								}
								disabled={loading}
							>
								<MenuItem value="User">User</MenuItem>
								<MenuItem value="Admin">Admin</MenuItem>
							</Select>
						</FormControl>
					</Stack>
					<Stack direction="row" spacing={2} sx={{ justifyContent: "flex-end" }}>
						<Button
							variant="outlined"
							onClick={handleClose}
							disabled={loading}
						>
							Cancel
						</Button>
						<Button
							variant="contained"
							color="primary"
							onClick={handleSubmit}
							disabled={loading}
						>
							{loading ? "Adding..." : "Add User"}
						</Button>
					</Stack>
				</Paper>
			</Modal>
		</>
	);
};
