import { useState } from "react";
import { Box, Tabs, Tab, Typography } from "@mui/material";
import PersonIcon from "@mui/icons-material/Person";
import FolderIcon from "@mui/icons-material/Folder";
import MailIcon from "@mui/icons-material/Mail";
import NotificationsIcon from "@mui/icons-material/Notifications";

const SETTINGS_SECTIONS = [
	{ key: "general", label: "General", icon: <PersonIcon /> },
	{ key: "spaces", label: "Spaces and work items", icon: <FolderIcon /> },
	{ key: "digests", label: "Digests", icon: <MailIcon /> },
	{ key: "alerts", label: "Alerts", icon: <NotificationsIcon /> },
];

const SECTION_CONTENT: Record<string, React.ReactNode> = {
	general: (
		<Box>
			<Typography variant="h5" sx={{ mb: 2 }}>
				General Settings
			</Typography>
			<Typography variant="body2" color="textSecondary">
				Configure your general account settings here.
			</Typography>
		</Box>
	),
	spaces: (
		<Box>
			<Typography variant="h5" sx={{ mb: 2 }}>
				Spaces and work items
			</Typography>
			<Typography variant="body2" color="textSecondary">
				Manage your spaces and work items.
			</Typography>
		</Box>
	),
	digests: (
		<Box>
			<Typography variant="h5" sx={{ mb: 2 }}>
				Digests
			</Typography>
			<Typography variant="body2" color="textSecondary">
				Configure your digest preferences.
			</Typography>
		</Box>
	),
	alerts: (
		<Box>
			<Typography variant="h5" sx={{ mb: 2 }}>
				Alerts
			</Typography>
			<Typography variant="body2" color="textSecondary">
				Manage your alert settings.
			</Typography>
		</Box>
	),
};

export const SettingsTabs = () => {
	const [selected, setSelected] = useState(0);

	const handleTabChange = (event: React.SyntheticEvent, newValue: number) => {
		setSelected(newValue);
	};

	return (
		<Box sx={{ display: "flex", flexDirection: "column", minHeight: "100%" }}>
			<Box
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
					{SETTINGS_SECTIONS.map((section) => (
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
			</Box>

			<Box
				component="main"
				sx={{
					flex: 1,
					p: 4,
					backgroundColor: "#fff",
					overflowY: "auto",
				}}
			>
				{SECTION_CONTENT[SETTINGS_SECTIONS[selected].key]}
			</Box>
		</Box>
	);
};
