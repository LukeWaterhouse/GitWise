
import React, { useState } from "react";
import "../Styles/SideNavBar.css";

const settingsSections = [
	{ key: "general", label: "General" },
	{ key: "spaces", label: "Spaces and work items" },
	{ key: "digests", label: "Digests" },
	{ key: "alerts", label: "Alerts" },
];

const sectionContent: Record<string, React.ReactNode> = {
		general: (
			<>
				<h2>General</h2>
			</>
		),
	spaces: <h2>Spaces and work items</h2>,
	digests: <h2>Digests</h2>,
	alerts: <h2>Alerts</h2>,
};

const SettingsPage: React.FC = () => {
	const [selected, setSelected] = useState("general");

	return (
							<div style={{
								width: "100vw",
								height: "100vh",
								background: "#f5f6fa",
								position: "fixed",
								top: 56,
								left: 70,
								margin: 0,
								padding: 0,
								zIndex: 0
							}}>
							{/* Sub-sidebar */}
							<div
								className="sidebar-nav"
								style={{
									position: "fixed",
									top: 56,
									left: 70,
									width: 220,
									height: "calc(100vh - 56px)",
									zIndex: 2,
									paddingTop: 32,
									display: "flex",
									flexDirection: "column"
								}}
							>
								<div style={{ fontWeight: 700, fontSize: 18, marginLeft: 24, marginBottom: 32, color: "#222" }}>Personal settings</div>
								{settingsSections.map((section) => (
									<div
										key={section.key}
										className={`nav-item settings-sub-sidebar-item${selected === section.key ? " active" : ""}`}
										style={{
											width: "100%",
											padding: "12px 24px",
											fontWeight: selected === section.key ? 600 : 400,
											color: selected === section.key ? "#0066ff" : "#444"
										}}
										onClick={() => setSelected(section.key)}
									>
										{section.label}
									</div>
								))}
							</div>
							{/* Main content */}
									<div style={{
										position: "fixed",
										top: 56,
										left: 290,
										right: 0,
										bottom: 0,
										overflowY: "auto",
										padding: "48px 48px 0 48px",
										background: "#f5f6fa",
										zIndex: 1
									}}>
										<div style={{ fontSize: 14, color: "#888", marginBottom: 8 }}>
											Personal settings / {settingsSections.find(s => s.key === selected)?.label}
										</div>
										{sectionContent[selected]}
									</div>
						</div>
	);
};

export default SettingsPage;
