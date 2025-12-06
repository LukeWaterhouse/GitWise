import { createTheme } from "@mui/material/styles";

export const theme = createTheme({
	palette: {
		primary: {
			main: "#0066ff",
			light: "#e3f2fd",
		},
		secondary: {
			main: "#1976d2",
		},
		background: {
			default: "#ffffff",
			paper: "#ffffff",
		},
		divider: "#e0e0e0",
	},
	typography: {
		fontFamily: [
			"-apple-system",
			"BlinkMacSystemFont",
			"Segoe UI",
			"Roboto",
			"Oxygen",
			"Ubuntu",
			"Cantarell",
			"Fira Sans",
			"Droid Sans",
			"Helvetica Neue",
			"sans-serif",
		].join(","),
	},
	components: {
		MuiAppBar: {
			styleOverrides: {
				root: {
					backgroundColor: "#1976d2",
					zIndex: 1300,
				},
			},
		},
		MuiDrawer: {
			styleOverrides: {
				paper: {
					backgroundColor: "#ffffff",
					borderRight: "1px solid #e0e0e0",
				},
			},
		},
		MuiButton: {
			styleOverrides: {
				root: {
					textTransform: "none",
				},
			},
		},
	},
});
