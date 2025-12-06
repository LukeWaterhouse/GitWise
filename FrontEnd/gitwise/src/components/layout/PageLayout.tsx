import React from "react";
import { Box, useTheme } from "@mui/material";
import { Header, Sidebar, Footer } from "../common";
import { DRAWER_WIDTH, TOP_NAV_HEIGHT } from "../../constants";

export const PageLayout: React.FC<{ children: React.ReactNode }> = ({ children }) => {
	const theme = useTheme();

	   return (
		   <Box sx={{ display: "flex", height: "100vh", flexDirection: "column" }}>
			   <Header />
			   <Box sx={{ display: "flex", flex: 1, overflow: "hidden", paddingTop: `${TOP_NAV_HEIGHT}px` }}>
				   <Box sx={{ width: DRAWER_WIDTH, flexShrink: 0 }}>
					   <Sidebar />
				   </Box>
				   <Box
					   component="main"
					   sx={{
						   flex: 1,
						   display: "flex",
						   flexDirection: "column",
						   overflow: "auto",
						   backgroundColor: theme.palette.background.default,
					   }}
				   >
					   <Box sx={{ flex: 1, overflow: "auto" }}>{children}</Box>
					   <Footer />
				   </Box>
			   </Box>
		   </Box>
	   );
};
