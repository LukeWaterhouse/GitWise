import React from "react";
import {
    MsalProvider,
    AuthenticatedTemplate,
    UnauthenticatedTemplate,
    useMsal
} from "@azure/msal-react";
import { IPublicClientApplication } from "@azure/msal-browser";

import { PageLayout } from "./Components/PageLayout";

import "./Styles/App.css";

import LandingPage from "./Pages/OverviewPage";
import SignInPage from "./Pages/SignInPage";
import SettingsPage from "./Pages/SettingsPage";
import { BrowserRouter as Router, Routes, Route, Navigate } from "react-router-dom";


const MainContent: React.FC = () => {
    return (
        <div className="App">
            <AuthenticatedTemplate>
                <Routes>
                    <Route path="/" element={<LandingPage />} />
                    <Route path="/settings/*" element={<SettingsPage />} />
                    <Route path="*" element={<Navigate to="/" replace />} />
                </Routes>
            </AuthenticatedTemplate>
            <UnauthenticatedTemplate>
                <SignInPage />
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
            <Router>
                <PageLayout>
                    <MainContent />
                </PageLayout>
            </Router>
        </MsalProvider>
    );
};

export default App;
