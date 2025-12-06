import React from "react";
import {
    MsalProvider,
    AuthenticatedTemplate,
    UnauthenticatedTemplate,
} from "@azure/msal-react";
import { IPublicClientApplication } from "@azure/msal-browser";

import { Header, Footer } from "./components/common";
import { Sidebar } from "./components/common";

import LandingPage from "./components/tabs/overviewTab/OverviewPage";
import SignInPage from "./components/pages/SignInPage";
import SettingsPage from "./components/tabs/settingsTab/SettingsTab";
import SecurityPage from "./components/tabs/securityTab/SecurityTab";
import { BrowserRouter as Router, Routes, Route, Navigate } from "react-router-dom";
import { Box } from "@mui/material";
import { TOP_NAV_HEIGHT } from "./constants";


const MainContent: React.FC = () => {
    return (
        <div className="App">
            <Routes>
                <Route path="/" element={<LandingPage />} />
                <Route path="/settings/*" element={<SettingsPage />} />
                <Route path="/security/*" element={<SecurityPage />} />
                <Route path="*" element={<Navigate to="/" replace />} />
            </Routes>
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
                    <Box sx={{ display: "flex", height: "100vh", flexDirection: "column" }}>
                        <Header />
                        <Box sx={{ display: "flex", flex: 1, overflow: "hidden" }}>
                            <AuthenticatedTemplate>
                                <Box sx={{ width: "70px", flexShrink: 0, paddingTop: `${TOP_NAV_HEIGHT}px` }}>
                                    <Sidebar />
                                </Box>
                            </AuthenticatedTemplate>
                            <Box
                                component="main"
                                sx={{
                                    flex: 1,
                                    display: "flex",
                                    flexDirection: "column",
                                    overflow: "auto",
                                    backgroundColor: "#fff",
                                    paddingTop: `${TOP_NAV_HEIGHT}px`,
                                }}
                            >
                            <Box sx={{ flex: 1, overflow: "auto" }}>
                                <AuthenticatedTemplate>
                                    <MainContent />
                                </AuthenticatedTemplate>
                                <UnauthenticatedTemplate>
                                    <SignInPage />
                                </UnauthenticatedTemplate>
                            </Box>
                            <AuthenticatedTemplate>
                                <Footer />
                            </AuthenticatedTemplate>
                        </Box>
                    </Box>
                </Box>
            </Router>
        </MsalProvider>
    );
};

export default App;
