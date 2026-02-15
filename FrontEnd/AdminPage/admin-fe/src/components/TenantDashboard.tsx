import React, { useState, useEffect } from 'react';
import {
  Container,
  Typography,
  Button,
  Box,
  Paper,
  Alert,
  Snackbar,
  CircularProgress,
  Fab
} from '@mui/material';
import {
  Add as AddIcon,
  Refresh as RefreshIcon
} from '@mui/icons-material';
import { Tenant, CreateTenantData } from '../types/tenant';
import { tenantService } from '../services/tenantService';
import TenantsTable from './TenantsTable';
import AddTenantDialog from './AddTenantDialog';

const TenantDashboard: React.FC = () => {
  const [tenants, setTenants] = useState<Tenant[]>([]);
  const [loading, setLoading] = useState(true);
  const [addDialogOpen, setAddDialogOpen] = useState(false);
  const [snackbar, setSnackbar] = useState<{
    open: boolean;
    message: string;
    severity: 'success' | 'error' | 'info' | 'warning';
  }>({
    open: false,
    message: '',
    severity: 'info'
  });

  const loadTenants = async () => {
    try {
      setLoading(true);
      const data = await tenantService.getTenants();
      setTenants(data);
    } catch (error) {
      console.error('Failed to load tenants:', error);
      const errorMessage = error instanceof Error ? error.message : 'Failed to load tenants';
      showSnackbar(errorMessage, 'error');
      // Set empty array on error to avoid showing stale data
      setTenants([]);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadTenants();
  }, []);

  const showSnackbar = (message: string, severity: 'success' | 'error' | 'info' | 'warning') => {
    setSnackbar({ open: true, message, severity });
  };

  const handleCloseSnackbar = () => {
    setSnackbar(prev => ({ ...prev, open: false }));
  };

  const handleCreateTenant = async (tenantData: CreateTenantData) => {
    try {
      const newTenant = await tenantService.createTenant(tenantData);
      setTenants(prev => [...prev, newTenant]);
      showSnackbar(`Tenant ${newTenant.name} created successfully!`, 'success');
    } catch (error) {
      console.error('Failed to create tenant:', error);
      const errorMessage = error instanceof Error ? error.message : 'Failed to create tenant';
      showSnackbar(errorMessage, 'error');
      throw error;
    }
  };

  const handleStatusChange = async (tenantId: string) => {
    // Placeholder for future edit functionality
    showSnackbar('Edit functionality not implemented yet', 'info');
  };

  const handleDeleteTenant = async (tenantId: string) => {
    try {
      await tenantService.deleteTenant(tenantId);
      setTenants(prev => prev.filter(tenant => tenant.id !== tenantId));
      showSnackbar('Tenant deleted successfully', 'success');
    } catch (error) {
      console.error('Failed to delete tenant:', error);
      const errorMessage = error instanceof Error ? error.message : 'Failed to delete tenant';
      showSnackbar(errorMessage, 'error');
    }
  };

  const getStatsData = () => {
    const totalTenants = tenants.length;
    
    return {
      totalTenants
    };
  };

  const stats = getStatsData();

  return (
    <Container maxWidth="xl" sx={{ py: 4 }}>
      {/* Header */}
      <Box display="flex" justifyContent="space-between" alignItems="center" mb={4}>
        <Box>
          <Typography variant="h4" component="h1" gutterBottom>
            Tenant Management
          </Typography>
          <Typography variant="body1" color="text.secondary">
            Manage your tenants, monitor usage, and control access
          </Typography>
        </Box>
        <Box display="flex" gap={2}>
          <Button
            variant="outlined"
            startIcon={<RefreshIcon />}
            onClick={loadTenants}
            disabled={loading}
          >
            Refresh
          </Button>
          <Button
            variant="contained"
            startIcon={<AddIcon />}
            onClick={() => setAddDialogOpen(true)}
          >
            Add Tenant
          </Button>
        </Box>
      </Box>

      {/* Stats Cards */}
      <Box display="flex" gap={2} mb={4} flexWrap="wrap">
        <Paper sx={{ p: 3, minWidth: 200, flex: 1 }}>
          <Typography variant="h3" color="primary" gutterBottom>
            {stats.totalTenants}
          </Typography>
          <Typography variant="body2" color="text.secondary">
            Total Tenants
          </Typography>
        </Paper>
      </Box>

      {/* Tenants Table */}
      <Paper sx={{ p: 0, overflow: 'hidden' }}>
        <Box p={3} borderBottom="1px solid" borderColor="divider">
          <Typography variant="h6">
            All Tenants ({tenants.length})
          </Typography>
        </Box>
        <TenantsTable
          tenants={tenants}
          loading={loading}
          onEdit={handleStatusChange}
          onDelete={handleDeleteTenant}
        />
      </Paper>

      {/* Add Tenant Dialog */}
      <AddTenantDialog
        open={addDialogOpen}
        onClose={() => setAddDialogOpen(false)}
        onSubmit={handleCreateTenant}
      />

      {/* Floating Action Button for Mobile */}
      <Fab
        color="primary"
        aria-label="add tenant"
        sx={{
          position: 'fixed',
          bottom: 16,
          right: 16,
          display: { xs: 'flex', md: 'none' }
        }}
        onClick={() => setAddDialogOpen(true)}
      >
        <AddIcon />
      </Fab>

      {/* Snackbar for notifications */}
      <Snackbar
        open={snackbar.open}
        autoHideDuration={6000}
        onClose={handleCloseSnackbar}
        anchorOrigin={{ vertical: 'bottom', horizontal: 'right' }}
      >
        <Alert 
          onClose={handleCloseSnackbar} 
          severity={snackbar.severity}
          variant="filled"
        >
          {snackbar.message}
        </Alert>
      </Snackbar>
    </Container>
  );
};

export default TenantDashboard;