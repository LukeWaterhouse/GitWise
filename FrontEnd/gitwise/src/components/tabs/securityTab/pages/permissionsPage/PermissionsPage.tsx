import React from "react";
import { Box, Typography } from "@mui/material";

const PermissionsPage: React.FC = () => (
  <Box>
    <Typography variant="h5" sx={{ mb: 2 }}>
      Permissions
    </Typography>
    <Typography variant="body2" color="textSecondary">
      Configure permissions for users and roles here.
    </Typography>
  </Box>
);

export default PermissionsPage;
