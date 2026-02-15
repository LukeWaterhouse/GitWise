import React, { useState } from 'react';
import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
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
  People as PeopleIcon,
  ContentCopy as ContentCopyIcon
} from '@mui/icons-material';
import { Tenant } from '../types/tenant';

interface TenantsTableProps {
  tenants: Tenant[];
  loading?: boolean;
  onEdit?: (tenantId: string) => void;
  onManageUsers: (tenant: Tenant) => void;
  onDelete: (tenantId: string) => void;
  onCopyId?: (id: string, tenantName: string) => void;
}

const TenantsTable: React.FC<TenantsTableProps> = ({
  tenants,
  loading = false,
  onEdit,
  onManageUsers,
  onDelete,
  onCopyId
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

  const handleCopyId = async (id: string, tenantName: string) => {
    try {
      await navigator.clipboard.writeText(id);
      if (onCopyId) {
        onCopyId(id, tenantName);
      }
    } catch (err) {
      console.error('Failed to copy tenant ID:', err);
    }
  };

  const handleEditClick = () => {
    if (selectedTenant && onEdit) {
      onEdit(selectedTenant.id);
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
              <TableCell>Name</TableCell>
              <TableCell>Tenant ID</TableCell>
              <TableCell>Users</TableCell>
              <TableCell align="right">Actions</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {tenants.map((tenant) => (
              <TableRow key={tenant.id} hover>
                <TableCell>
                  <Typography variant="body2">
                    {tenant.name}
                  </Typography>
                </TableCell>
                
                <TableCell>
                  <Box display="flex" alignItems="center" gap={1}>
                    <Typography 
                      variant="body2" 
                      sx={{ 
                        fontFamily: 'monospace', 
                        fontSize: '0.75rem',
                        color: 'text.secondary',
                        maxWidth: '200px',
                        overflow: 'hidden',
                        textOverflow: 'ellipsis'
                      }}
                    >
                      {tenant.id}
                    </Typography>
                    <Tooltip title="Copy Tenant ID">
                      <IconButton
                        size="small"
                        onClick={() => handleCopyId(tenant.id, tenant.name)}
                        sx={{ ml: 0.5 }}
                      >
                        <ContentCopyIcon fontSize="small" />
                      </IconButton>
                    </Tooltip>
                  </Box>
                </TableCell>
                
                <TableCell>
                  <Button
                    variant="outlined"
                    size="small"
                    startIcon={<PeopleIcon />}
                    onClick={() => onManageUsers(tenant)}
                    sx={{ textTransform: 'none' }}
                  >
                    Manage Users
                  </Button>
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
        {onEdit && (
          <MenuItem onClick={handleEditClick}>
            Edit
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
            Are you sure you want to delete <strong>{tenantToDelete?.name}</strong>?
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