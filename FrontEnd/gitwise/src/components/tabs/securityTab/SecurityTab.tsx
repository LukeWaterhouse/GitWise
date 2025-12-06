
import React, { useState } from "react";
import TabbedSections, { Section } from "../../common/TabbedSections";
import PersonIcon from "@mui/icons-material/Person";
import LockIcon from "@mui/icons-material/Lock";
import HistoryIcon from "@mui/icons-material/History";
import UsersPage from "./pages/usersPage/UsersPage";
import PermissionsPage from "./pages/permissionsPage/PermissionsPage";

const sectionComponents: Record<string, React.ReactNode> = {
	users: <UsersPage />,
	permissions: <PermissionsPage />,
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
	    <TabbedSections
	      sections={securitySections}
	      selected={selected}
	      onChange={handleTabChange}
	      sectionComponents={sectionComponents}
	    />
	  );
};

export default SecurityTab;
