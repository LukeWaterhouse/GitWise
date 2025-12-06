import React from "react";
import { createRoot } from "react-dom/client";
import App from "./App";
import { ThemeProvider } from "@mui/material/styles";
import { theme } from "./theme/theme";
import {
    PublicClientApplication,
    EventType,
    AuthenticationResult
} from "@azure/msal-browser";
import { msalConfig } from "./auth/AuthConfig";

import "bootstrap/dist/css/bootstrap.min.css";
import "./styles/index.css";


const msalInstance = new PublicClientApplication(msalConfig);

const allAccounts = msalInstance.getAllAccounts();

if (!msalInstance.getActiveAccount() && allAccounts.length > 0) {
    msalInstance.setActiveAccount(allAccounts[0]);
}

msalInstance.addEventCallback((event) => {
    if (
        event.eventType === EventType.LOGIN_SUCCESS &&
        event.payload &&
        (event.payload as AuthenticationResult).account
    ) {
        const account = (event.payload as AuthenticationResult).account!;
        msalInstance.setActiveAccount(account);
    }
});

const container = document.getElementById("root");

if (!container) {
    throw new Error("Root container not found");
}

const root = createRoot(container);

root.render(
    <React.StrictMode>
        <ThemeProvider theme={theme}>
            <App instance={msalInstance} />
        </ThemeProvider>
    </React.StrictMode>
);
