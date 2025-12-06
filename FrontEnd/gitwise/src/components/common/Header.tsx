import React from "react";
import { AppBar, Toolbar, Box, Button, Typography } from "@mui/material";
import LogoutIcon from "@mui/icons-material/Logout";
import LoginIcon from "@mui/icons-material/Login";
import { useMsal } from "@azure/msal-react";
import { TOP_NAV_HEIGHT } from "../../constants";

export const Header: React.FC = () => {
	const { instance, accounts } = useMsal();

	const handleSignIn = () => {
		instance.loginRedirect();
	};

	const handleSignOut = () => {
		instance.logout();
	};

	const isAuthenticated = accounts.length > 0;

	return (
		<AppBar
			position="fixed"
			sx={(theme) => ({
				height: TOP_NAV_HEIGHT,
				backgroundColor: theme.palette.primary.main,
				boxShadow: theme.shadows[2],
			})}
		>
			<Toolbar sx={{ display: "flex", justifyContent: "space-between" }}>
				<Typography variant="h6" sx={{ fontWeight: (theme) => theme.typography.fontWeightBold }}>
					GitWise
				</Typography>

				<Box sx={{ display: "flex", gap: 2, alignItems: "center" }}>
					{isAuthenticated && (
						<Typography
							variant="body2"
							sx={(theme) => ({
								color: theme.palette.common.white,
								fontSize: theme.typography.pxToRem(14),
							})}
						>
							{accounts[0]?.name}
						</Typography>
					)}

					{isAuthenticated ? (
						<Button
							color="inherit"
							startIcon={<LogoutIcon />}
							onClick={handleSignOut}
							sx={(theme) => ({
								textTransform: "none",
								fontSize: theme.typography.pxToRem(14),
								"&:hover": {
									backgroundColor: theme.palette.action.hover,
								},
							})}
						>
							Sign Out
						</Button>
					) : (
						<Button
							color="inherit"
							startIcon={<LoginIcon />}
							onClick={handleSignIn}
							sx={(theme) => ({
								textTransform: "none",
								fontSize: theme.typography.pxToRem(14),
								"&:hover": {
									backgroundColor: theme.palette.action.hover,
								},
							})}
						>
							Sign In
						</Button>
					)}
				</Box>
			</Toolbar>
		</AppBar>
	);
};
