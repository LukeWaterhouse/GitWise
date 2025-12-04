import React from "react";
import { useNavigate } from "react-router-dom";
import "../Styles/SideNavBar.css";

export interface NavItem {
    icon: React.ReactNode;
    label: string;
    route?: string;
    onClick?: () => void;
}

interface SidebarNavProps {
    active?: string;
}

const SidebarNav: React.FC<SidebarNavProps> = ({ active }) => {
    const navigate = useNavigate();
    const items: NavItem[] = [
        { icon: "🏠", label: "Home", route: "/" },
        { icon: "📊", label: "Dashboard", route: "/dashboard" },
        { icon: "⚙️", label: "Settings", route: "/settings" },
    ];

    return (
        <div className="sidebar-nav">
            <div className="sidebar-nav-content">
                {items.map((item) => (
                    <div
                        key={item.label}
                        className={`nav-item ${active === item.label ? "active" : ""}`}
                        onClick={() => item.route && navigate(item.route)}
                    >
                        <div className="nav-icon">{item.icon}</div>
                        <div className="nav-label">{item.label}</div>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default SidebarNav;
