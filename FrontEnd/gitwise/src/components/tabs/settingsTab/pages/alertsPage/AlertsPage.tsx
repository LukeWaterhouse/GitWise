import React from "react";
import { Box, Typography } from "@mui/material";

const AlertsTab: React.FC = () => (
	<Box>
		<Typography variant="h5" sx={{ mb: 2 }}>
			Alerts
		</Typography>
		<Typography variant="body2" color="textSecondary">
			Manage your alert settings.
		</Typography>
	</Box>
);

export default AlertsTab;
