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
  Business as BusinessIcon
} from '@mui/icons-material';
import { Tenant } from '../types/tenant';

interface TenantsTableProps {
  tenants: Tenant[];
  loading?: boolean;
  onEdit?: (tenantId: string) => void;
  onDelete: (tenantId: string) => void;
}

const TenantsTable: React.FC<TenantsTableProps> = ({
  tenants,
  loading = false,
  onEdit,
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