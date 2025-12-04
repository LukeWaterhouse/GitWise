import React, { ReactNode } from "react";
import { AuthenticatedTemplate } from "@azure/msal-react";

import { SignInTopNavBar } from "./SignInTopNavBar";
import SidebarNav from "./SideNavBar";

interface PageLayoutProps {
    children?: ReactNode;
}

export const PageLayout: React.FC<PageLayoutProps> = ({ children }) => {
    return (
        <>
            <SignInTopNavBar />
            <AuthenticatedTemplate>
                <SidebarNav />
            </AuthenticatedTemplate>
            
            <div style={{ marginLeft: "70px" }}>
                <br />
                {children}
                <br />
                <footer>
                    <center>
                        <p>© 2024 GitWise. All rights reserved.</p>
                    </center>
                </footer>
            </div>
        </>
    );
};