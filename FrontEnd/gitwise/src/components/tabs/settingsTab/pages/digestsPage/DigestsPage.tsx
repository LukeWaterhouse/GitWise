import React from "react";
import { Box, Typography } from "@mui/material";

const DigestsTab: React.FC = () => (
	<Box>
		<Typography variant="h5" sx={{ mb: 2 }}>
			Digests
		</Typography>
		<Typography variant="body2" color="textSecondary">
			Configure your digest preferences.
		</Typography>
	</Box>
);

export default DigestsTab;
