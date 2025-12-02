import React from "react";
import {
    MsalProvider,
    AuthenticatedTemplate,
    UnauthenticatedTemplate,
    useMsal
} from "@azure/msal-react";
import { IPublicClientApplication } from "@azure/msal-browser";

import { Container, Button } from "react-bootstrap";
import { PageLayout } from "./Components/PageLayout";
import { IdTokenData } from "./Components/DataDisplay";
import { loginRequest } from "./Auth/AuthConfig";

import "./Styles/App.css";

const MainContent: React.FC = () => {
    const { instance } = useMsal();
    const activeAccount = instance.getActiveAccount();

    const handleRedirect = () => {
        instance
            .loginRedirect({
                ...loginRequest,
                prompt: "create",
            })
            .catch((error) => console.log(error));
    };

    return (
        <div className="App">
            <AuthenticatedTemplate>
                {activeAccount && (
                    <Container>
                        <IdTokenData idTokenClaims={activeAccount.idTokenClaims as Record<string, unknown>} />
                    </Container>
                )}
            </AuthenticatedTemplate>

            <UnauthenticatedTemplate>
                <Button
                    className="signInButton"
                    onClick={handleRedirect}
                    variant="primary"
                >
                    Sign up
                </Button>
            </UnauthenticatedTemplate>
        </div>
    );
};

interface AppProps {
    instance: IPublicClientApplication;
}

const App: React.FC<AppProps> = ({ instance }) => {
    return (
        <MsalProvider instance={instance}>
            <PageLayout>
                <MainContent />
            </PageLayout>
        </MsalProvider>
    );
};

export default App;
