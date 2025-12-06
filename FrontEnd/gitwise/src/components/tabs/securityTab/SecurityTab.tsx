import PersonIcon from "@mui/icons-material/Person";
import LockIcon from "@mui/icons-material/Lock";
import HistoryIcon from "@mui/icons-material/History";
import React, { useState } from "react";
import { Box } from "@mui/material";
import SectionTabs, { Section } from "../../common/SectionTabs";


import UsersPage from "./pages/usersPage/UsersPage";
import PermissionsPage from "./pages/permissionsPage/PermissionsPage";


const sectionComponents: Record<string, React.ReactNode> = {
	users: <UsersPage />,
	permissions: <PermissionsPage />,
	// audit: <AuditPage />,
};

const securitySections: Section[] = [
	{ key: "users", label: "Users", icon: <PersonIcon /> },
	{ key: "permissions", label: "Permissions", icon: <LockIcon /> },
	{ key: "audit", label: "Audit", icon: <HistoryIcon /> },
];

const SecurityTab: React.FC = () => {
	const [selected, setSelected] = useState(0);

	const handleTabChange = (event: React.SyntheticEvent, newValue: number) => {
		setSelected(newValue);
	};

	return (
		<Box sx={{ display: "flex", flexDirection: "column", minHeight: "100%" }}>
			<SectionTabs
				sections={securitySections}
				selected={selected}
				onChange={handleTabChange}
			/>
			<Box
				component="main"
				sx={{
					flex: 1,
					p: 4,
					backgroundColor: "#fff",
					overflowY: "auto",
				}}
			>
				{sectionComponents[securitySections[selected].key]}
			</Box>
		</Box>
	);
};

export default SecurityTab;
