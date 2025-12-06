import React from "react";
import { Box, Typography } from "@mui/material";
import { APP_NAME } from "../../constants/config";

const COPYRIGH_YEAR = 2024;

export const Footer: React.FC = () => {
	return (
		<Box
			component="footer"
			sx={{
				backgroundColor: "#f5f5f5",
				borderTop: "1px solid #e0e0e0",
				py: 2,
				px: 4,
				textAlign: "center",
			}}
		>
			<Typography variant="body2" color="textSecondary">
				© {COPYRIGH_YEAR} {APP_NAME}. All rights reserved.
			</Typography>
		</Box>
	);
};
