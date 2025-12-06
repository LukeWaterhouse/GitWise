import React, { useState } from "react";
import TabbedSections from "../../common/TabbedSections";
import { Section } from "../../common/SectionTabs";
import PersonIcon from "@mui/icons-material/Person";
import FolderIcon from "@mui/icons-material/Folder";
import MailIcon from "@mui/icons-material/Mail";
import NotificationsIcon from "@mui/icons-material/Notifications";
import GeneralTab from "./pages/generalPage/GeneralPage";
import SpacesTab from "./pages/spacesPage/SpacesPage";
import DigestsTab from "./pages/digestsPage/DigestsPage";
import AlertsTab from "./pages/alertsPage/AlertsPage";

const settingsSections: Section[] = [
	{ key: "general", label: "General", icon: <PersonIcon /> },
	{ key: "spaces", label: "Spaces and work items", icon: <FolderIcon /> },
	{ key: "digests", label: "Digests", icon: <MailIcon /> },
	{ key: "alerts", label: "Alerts", icon: <NotificationsIcon /> },
];

const sectionComponents: Record<string, React.ReactNode> = {
       general: <GeneralTab />,
       spaces: <SpacesTab />,
       digests: <DigestsTab />,
       alerts: <AlertsTab />,
};

const SettingsPage: React.FC = () => {
	const [selected, setSelected] = useState(0);

	const handleTabChange = (event: React.SyntheticEvent, newValue: number) => {
		setSelected(newValue);
	};

	  return (
	    <TabbedSections
	      sections={settingsSections}
	      selected={selected}
	      onChange={handleTabChange}
	      sectionComponents={sectionComponents}
	    />
	  );
};

export default SettingsPage;