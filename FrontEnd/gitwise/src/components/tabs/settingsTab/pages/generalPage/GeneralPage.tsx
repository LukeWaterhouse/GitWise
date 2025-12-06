import React from "react";
import { Box, Typography } from "@mui/material";

const GeneralTab: React.FC = () => (
	<Box>
		<Typography variant="h5" sx={{ mb: 2 }}>
			General Settings
		</Typography>
		<Typography variant="body2" color="textSecondary">
			Configure your general account settings here.
		</Typography>
	</Box>
);

export default GeneralTab;
