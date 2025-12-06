import React from "react";
import { useMsal } from "@azure/msal-react";
import { Box } from "@mui/material";

function SignInPage() {
	const { instance } = useMsal();

	const handleSignIn = async () => {
		try {
			await instance.loginRedirect();
		} catch (error) {
			console.error("Login error:", error);
		}
	};

	return (
		<Box
			sx={{
				display: "flex",
				alignItems: "center",
				justifyContent: "center",
				minHeight: "100%",
				backgroundColor: "#fff",
			}}
		></Box>
	);
}

export default SignInPage;
