import React from "react";
import {
	Drawer,
	List,
	ListItem,
	ListItemIcon,
	Box,
} from "@mui/material";
import { useNavigate, useLocation } from "react-router-dom";
import DashboardIcon from "@mui/icons-material/Dashboard";
import SettingsIcon from "@mui/icons-material/Settings";
import SecurityIcon from "@mui/icons-material/Security";
import { ROUTES } from "../../constants/routes";
import { DRAWER_WIDTH, TOP_NAV_HEIGHT } from "../../constants";

const NAV_ITEMS = [
	{ key: "dashboard", label: "Dashboard", icon: <DashboardIcon />, path: ROUTES.DASHBOARD },
	{ key: "settings", label: "Settings", icon: <SettingsIcon />, path: ROUTES.SETTINGS },
	{ key: "security", label: "Security", icon: <SecurityIcon />, path: ROUTES.SECURITY },
];

export const Sidebar: React.FC = () => {
	const navigate = useNavigate();
	const location = useLocation();

	   return (
		   <Drawer
			   variant="permanent"
			   sx={(theme) => ({
				   width: DRAWER_WIDTH,
				   flexShrink: 0,
				   position: 'fixed',
				   top: `${TOP_NAV_HEIGHT}px`,
				   height: `calc(100vh - ${TOP_NAV_HEIGHT}px)`,
				   "& .MuiDrawer-paper": {
					   width: DRAWER_WIDTH,
					   boxSizing: "border-box",
					   backgroundColor: theme.palette.background.paper,
					   borderRight: `1px solid ${theme.palette.divider}`,
					   position: 'fixed',
					   top: `${TOP_NAV_HEIGHT}px`,
					   height: `calc(100vh - ${TOP_NAV_HEIGHT}px)`,
				   },
			   })}
		   >
			<Box sx={{ display: "flex", flexDirection: "column", height: `calc(100vh - ${TOP_NAV_HEIGHT}px)` }}>
				<List sx={{ flex: 1, py: 2 }}>
					{NAV_ITEMS.map((item) => (
						<ListItem
							key={item.key}
							onClick={() => navigate(item.path)}
							sx={(theme) => ({
								justifyContent: "center",
								py: 2,
								px: 1,
								cursor: "pointer",
								backgroundColor:
									location.pathname === item.path
										? theme.palette.primary.light
										: "transparent",
								color:
									location.pathname === item.path
										? theme.palette.primary.main
										: theme.palette.text.secondary,
								"&:hover": {
									backgroundColor: theme.palette.action.hover,
								},
								mb: 1,
							})}
							title={item.label}
						>
							<ListItemIcon
								sx={{
									minWidth: "auto",
									color: "inherit",
									justifyContent: "center",
									fontSize: "24px",
								}}
							>
								{item.icon}
							</ListItemIcon>
						</ListItem>
					))}
				</List>
			</Box>
		</Drawer>
	);
};
