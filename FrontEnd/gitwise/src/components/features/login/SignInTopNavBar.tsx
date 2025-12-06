import { AuthenticatedTemplate, UnauthenticatedTemplate, useMsal } from '@azure/msal-react';
import { AppBar, Toolbar, Button, Box } from '@mui/material';
import { loginRequest } from '../../../Auth/AuthConfig';

export const SignInTopNavBar = () => {
    const { instance } = useMsal();
    
    const handleLoginRedirect = () => {
        instance.loginRedirect(loginRequest).catch((error) => console.log(error));
    };

    const handleLogoutRedirect = () => {
        instance.logoutRedirect().catch((error) => console.log(error));
    };

    return (
        <AppBar position="fixed" sx={{ zIndex: 1300, backgroundColor: '#1976d2' }}>
            <Toolbar>
                <Box
                    component="a"
                    href="/"
                    sx={{
                        color: '#fff',
                        textDecoration: 'none',
                        fontSize: '20px',
                        fontWeight: 600,
                        flexGrow: 1
                    }}
                >
                    Gitwise
                </Box>
                <AuthenticatedTemplate>
                    <Button
                        variant="contained"
                        color="warning"
                        onClick={handleLogoutRedirect}
                        sx={{ ml: 2 }}
                    >
                        Sign out
                    </Button>
                </AuthenticatedTemplate>
                <UnauthenticatedTemplate>
                    <Button
                        variant="contained"
                        color="success"
                        onClick={handleLoginRedirect}
                        sx={{ ml: 2 }}
                    >
                        Sign in
                    </Button>
                </UnauthenticatedTemplate>
            </Toolbar>
        </AppBar>
    );
};
