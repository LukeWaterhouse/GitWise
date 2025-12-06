
import React from "react";
import { Tabs, Tab, Paper, Box } from "@mui/material";

export interface Section {
  key: string;
  label: string;
  icon?: React.ReactNode;
}

interface TabbedSectionsProps {
  sections: Section[];
  selected: number;
  onChange: (event: React.SyntheticEvent, newValue: number) => void;
  sectionComponents: Record<string, React.ReactNode>;
}

const TabbedSections: React.FC<TabbedSectionsProps> = ({
  sections,
  selected,
  onChange,
  sectionComponents,
}) => (
  <Box sx={{ display: "flex", flexDirection: "column", minHeight: "100%" }}>
    <Paper
      elevation={0}
      sx={{
        borderBottom: "1px solid #e0e0e0",
        backgroundColor: "#fff",
        mb: 0,
      }}
    >
      <Tabs
        value={selected}
        onChange={onChange}
        variant="scrollable"
        scrollButtons="auto"
        centered
        sx={{
          display: 'flex',
          justifyContent: 'center',
          "& .MuiTabs-flexContainer": {
            justifyContent: 'center',
          },
          "& .MuiTab-root": {
            minHeight: "60px",
            minWidth: "60px",
            display: "flex",
            alignItems: "center",
            justifyContent: "center",
            textTransform: "none",
          },
          "& .MuiTab-iconWrapper": {
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center',
            width: '100%',
          },
          "& .MuiTabs-indicator": {
            height: "3px",
            backgroundColor: "#0066ff",
          },
        }}
      >
        {sections.map((section) => {
          const icon = section.icon ? (
            <Box sx={{ fontSize: "24px", display: "flex", alignItems: "center", justifyContent: "center", width: '100%' }}>{section.icon}</Box>
          ) : undefined;
          return (
            <Tab
              key={section.key}
              {...(icon ? { icon } : {})}
              aria-label={section.label}
            />
          );
        })}
      </Tabs>
    </Paper>
    <Box
      component="main"
      sx={{
        flex: 1,
        p: 4,
        backgroundColor: "#fff",
        overflowY: "auto",
      }}
    >
      {sectionComponents[sections[selected].key]}
    </Box>
  </Box>
);

export default TabbedSections;
