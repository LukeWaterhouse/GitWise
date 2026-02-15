import React, { useState } from 'react';
import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  Chip,
  IconButton,
  Menu,
  MenuItem,
  Typography,
  Box,
  Tooltip,
  Dialog,
  DialogTitle,
  DialogContent,
  DialogContentText,
  DialogActions,
  Button
} from '@mui/material';
import {
  MoreVert as MoreVertIcon,
  Business as BusinessIcon,
  Email as EmailIcon,
  People as PeopleIcon
} from '@mui/icons-material';
import { Tenant } from '../types/tenant';

interface TenantsTableProps {
  tenants: Tenant[];
  loading?: boolean;
  onStatusChange: (tenantId: string, status: Tenant['status']) => void;
  onDelete: (tenantId: string) => void;
}

const TenantsTable: React.FC<TenantsTableProps> = ({
  tenants,
  loading = false,
  onStatusChange,
  onDelete
}) => {
  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
  const [selectedTenant, setSelectedTenant] = useState<Tenant | null>(null);
  const [deleteDialogOpen, setDeleteDialogOpen] = useState(false);
  const [tenantToDelete, setTenantToDelete] = useState<Tenant | null>(null);

  const handleMenuClick = (event: React.MouseEvent<HTMLElement>, tenant: Tenant) => {
    setAnchorEl(event.currentTarget);
    setSelectedTenant(tenant);
  };

  const handleMenuClose = () => {
    setAnchorEl(null);
    setSelectedTenant(null);
  };

  const handleStatusChange = (status: Tenant['status']) => {
    if (selectedTenant) {
      onStatusChange(selectedTenant.id, status);
    }
    handleMenuClose();
  };

  const handleDeleteClick = () => {
    setTenantToDelete(selectedTenant);
    setDeleteDialogOpen(true);
    handleMenuClose();
  };

  const handleDeleteConfirm = () => {
    if (tenantToDelete) {
      onDelete(tenantToDelete.id);
    }
    setDeleteDialogOpen(false);
    setTenantToDelete(null);
  };

  const handleDeleteCancel = () => {
    setDeleteDialogOpen(false);
    setTenantToDelete(null);
  };

  const getStatusColor = (status: Tenant['status']) => {
    switch (status) {
      case 'active':
        return 'success';
      case 'inactive':
        return 'error';
      case 'pending':
        return 'warning';
      default:
        return 'default';
    }
  };

  const getPlanColor = (plan: Tenant['plan']) => {
    switch (plan) {
      case 'basic':
        return 'default';
      case 'premium':
        return 'primary';
      case 'enterprise':
        return 'secondary';
      default:
        return 'default';
    }
  };

  const formatDate = (date: Date) => {
    return new Intl.DateTimeFormat('en-US', {
      year: 'numeric',
      month: 'short',
      day: 'numeric',
      hour: '2-digit',
      minute: '2-digit'
    }).format(date);
  };

  if (loading) {
    return (
      <Box display="flex" justifyContent="center" alignItems="center" minHeight="300px">
        <Typography>Loading tenants...</Typography>
      </Box>
    );
  }

  if (tenants.length === 0) {
    return (
      <Box display="flex" flexDirection="column" alignItems="center" justifyContent="center" minHeight="300px">
        <BusinessIcon sx={{ fontSize: 64, color: 'text.secondary', mb: 2 }} />
        <Typography variant="h6" color="text.secondary">
          No tenants found
        </Typography>
        <Typography variant="body2" color="text.secondary">
          Add your first tenant to get started
        </Typography>
      </Box>
    );
  }

  return (
    <>
      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Tenant</TableCell>
              <TableCell>Company</TableCell>
              <TableCell>Status</TableCell>
              <TableCell>Plan</TableCell>
              <TableCell>Users</TableCell>
              <TableCell>Created</TableCell>
              <TableCell>Last Login</TableCell>
              <TableCell align="right">Actions</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {tenants.map((tenant) => (
              <TableRow key={tenant.id} hover>
                <TableCell>
                  <Box>
                    <Typography variant="subtitle2">
                      {tenant.name}
                    </Typography>
                    <Box display="flex" alignItems="center" mt={0.5}>
                      <EmailIcon sx={{ fontSize: 14, color: 'text.secondary', mr: 0.5 }} />
                      <Typography variant="caption" color="text.secondary">
                        {tenant.email}
                      </Typography>
                    </Box>
                  </Box>
                </TableCell>
                
                <TableCell>
                  <Box display="flex" alignItems="center">
                    <BusinessIcon sx={{ fontSize: 16, color: 'text.secondary', mr: 1 }} />
                    <Typography variant="body2">
                      {tenant.company}
                    </Typography>
                  </Box>
                </TableCell>
                
                <TableCell>
                  <Chip
                    label={tenant.status}
                    color={getStatusColor(tenant.status) as any}
                    size="small"
                    variant="outlined"
                  />
                </TableCell>
                
                <TableCell>
                  <Chip
                    label={tenant.plan.toUpperCase()}
                    color={getPlanColor(tenant.plan) as any}
                    size="small"
                  />
                </TableCell>
                
                <TableCell>
                  <Box display="flex" alignItems="center">
                    <PeopleIcon sx={{ fontSize: 16, color: 'text.secondary', mr: 0.5 }} />
                    <Typography variant="body2">
                      {tenant.currentUsers}/{tenant.maxUsers}
                    </Typography>
                  </Box>
                </TableCell>
                
                <TableCell>
                  <Typography variant="body2">
                    {formatDate(tenant.createdAt)}
                  </Typography>
                </TableCell>
                
                <TableCell>
                  <Typography variant="body2" color={tenant.lastLogin ? 'text.primary' : 'text.secondary'}>
                    {tenant.lastLogin ? formatDate(tenant.lastLogin) : 'Never'}
                  </Typography>
                </TableCell>
                
                <TableCell align="right">
                  <Tooltip title="More actions">
                    <IconButton
                      onClick={(e) => handleMenuClick(e, tenant)}
                      size="small"
                    >
                      <MoreVertIcon />
                    </IconButton>
                  </Tooltip>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>

      <Menu
        anchorEl={anchorEl}
        open={Boolean(anchorEl)}
        onClose={handleMenuClose}
      >
        {selectedTenant?.status !== 'active' && (
          <MenuItem onClick={() => handleStatusChange('active')}>
            Activate
          </MenuItem>
        )}
        {selectedTenant?.status !== 'inactive' && (
          <MenuItem onClick={() => handleStatusChange('inactive')}>
            Deactivate
          </MenuItem>
        )}
        {selectedTenant?.status !== 'pending' && (
          <MenuItem onClick={() => handleStatusChange('pending')}>
            Set to Pending
          </MenuItem>
        )}
        <MenuItem onClick={handleDeleteClick} sx={{ color: 'error.main' }}>
          Delete
        </MenuItem>
      </Menu>

      <Dialog
        open={deleteDialogOpen}
        onClose={handleDeleteCancel}
      >
        <DialogTitle>
          Delete Tenant
        </DialogTitle>
        <DialogContent>
          <DialogContentText>
            Are you sure you want to delete <strong>{tenantToDelete?.name}</strong> from <strong>{tenantToDelete?.company}</strong>?
            This action cannot be undone.
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleDeleteCancel}>Cancel</Button>
          <Button onClick={handleDeleteConfirm} color="error" variant="contained">
            Delete
          </Button>
        </DialogActions>
      </Dialog>
    </>
  );
};

export default TenantsTable;