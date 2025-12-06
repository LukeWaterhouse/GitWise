import React from "react";
import { createRoot } from "react-dom/client";
import App from "./App";
import {
    PublicClientApplication,
    EventType,
    AuthenticationResult
} from "@azure/msal-browser";
import { msalConfig } from "./Auth/AuthConfig";

import "bootstrap/dist/css/bootstrap.min.css";
import "./styles/index.css";

/**
 * Instantiate MSAL outside of the React tree.
 */
const msalInstance = new PublicClientApplication(msalConfig);

// Choose the first account if none is active
const allAccounts = msalInstance.getAllAccounts();

if (!msalInstance.getActiveAccount() && allAccounts.length > 0) {
    msalInstance.setActiveAccount(allAccounts[0]); // FIXED: previously referenced getActiveAccount()[0]
}

// Listen for login events and set active account
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
        <App instance={msalInstance} />
    </React.StrictMode>
);
