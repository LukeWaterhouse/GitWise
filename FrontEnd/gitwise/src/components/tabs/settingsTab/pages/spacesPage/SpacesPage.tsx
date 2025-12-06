import React from "react";
import { Box, Typography } from "@mui/material";

const SpacesTab: React.FC = () => (
	<Box>
		<Typography variant="h5" sx={{ mb: 2 }}>
			Spaces and work items
		</Typography>
		<Typography variant="body2" color="textSecondary">
			Manage your spaces and work items.
		</Typography>
	</Box>
);

export default SpacesTab;
