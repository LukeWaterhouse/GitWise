import React, { useState, useEffect } from 'react';
import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  Button,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  IconButton,
  Typography,
  Box,
  Chip,
  CircularProgress,
  Alert,
  Divider
} from '@mui/material';
import {
  Add as AddIcon,
  Delete as DeleteIcon,
  Person as PersonIcon
} from '@mui/icons-material';
import { Tenant, User, CreateUserData } from '../types/tenant';
import { userService } from '../services/userService';
import AddUserDialog from './AddUserDialog';

interface UserManagementDialogProps {
  open: boolean;
  tenant: Tenant | null;
  onClose: () => void;
}

const UserManagementDialog: React.FC<UserManagementDialogProps> = ({
  open,
  tenant,
  onClose
}) => {
  const [users, setUsers] = useState<User[]>([]);
  const [loading, setLoading] = useState(false);
  const [addUserDialogOpen, setAddUserDialogOpen] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const loadUsers = async () => {
    if (!tenant) return;
    
    try {
      setLoading(true);
      setError(null);
      const data = await userService.getUsersByTenant(tenant.id);
      setUsers(data);
    } catch (error) {
      console.error('Failed to load users:', error);
      setError(error instanceof Error ? error.message : 'Failed to load users');
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    if (open && tenant) {
      loadUsers();
    }
  }, [open, tenant]);

  const handleCreateUser = async (userData: CreateUserData) => {
    try {
      const newUser = await userService.createUser(userData);
      setUsers(prev => [...prev, newUser]);
    } catch (error) {
      console.error('Failed to create user:', error);
      throw error;
    }
  };

  const handleDeleteUser = async (userId: string) => {
    try {
      await userService.deleteUser(userId);
      setUsers(prev => prev.filter(user => user.id !== userId));
    } catch (error) {
      console.error('Failed to delete user:', error);
      setError(error instanceof Error ? error.message : 'Failed to delete user');
    }
  };

  const handleClose = () => {
    setUsers([]);
    setError(null);
    onClose();
  };

  if (!tenant) return null;

  return (
    <>
      <Dialog open={open} onClose={handleClose} maxWidth="md" fullWidth>
        <DialogTitle>
          <Box display="flex" alignItems="center" gap={1}>
            <PersonIcon />
            Users for {tenant.name}
          </Box>
        </DialogTitle>
        
        <DialogContent>
          {error && (
            <Alert severity="error" sx={{ mb: 2 }}>
              {error}
            </Alert>
          )}

          {loading ? (
            <Box display="flex" justifyContent="center" alignItems="center" minHeight="200px">
              <CircularProgress />
            </Box>
          ) : (
            <>
              <Box display="flex" justifyContent="space-between" alignItems="center" mb={2}>
                <Typography variant="h6">
                  Users ({users.length})
                </Typography>
                <Button
                  variant="contained"
                  startIcon={<AddIcon />}
                  onClick={() => setAddUserDialogOpen(true)}
                >
                  Add User
                </Button>
              </Box>
              
              <Divider sx={{ mb: 2 }} />

              {users.length === 0 ? (
                <Box 
                  display="flex" 
                  flexDirection="column" 
                  alignItems="center" 
                  justifyContent="center" 
                  minHeight="200px"
                >
                  <PersonIcon sx={{ fontSize: 48, color: 'text.secondary', mb: 2 }} />
                  <Typography variant="h6" color="text.secondary">
                    No users found
                  </Typography>
                  <Typography variant="body2" color="text.secondary">
                    Add the first user to this tenant
                  </Typography>
                </Box>
              ) : (
                <TableContainer component={Paper} variant="outlined">
                  <Table>
                    <TableHead>
                      <TableRow>
                        <TableCell>Email Address</TableCell>
                        <TableCell>Role</TableCell>
                        <TableCell>EntraID</TableCell>
                        <TableCell align="right">Actions</TableCell>
                      </TableRow>
                    </TableHead>
                    <TableBody>
                      {users.map((user) => (
                        <TableRow key={user.id} hover>
                          <TableCell>
                            <Typography variant="body2">
                              {user.emailAddress}
                            </Typography>
                          </TableCell>
                          
                          <TableCell>
                            <Chip
                              label={user.role === 1 ? 'User' : 'Admin'}
                              color={user.role === 1 ? 'default' : 'primary'}
                              size="small"
                              variant="outlined"
                            />
                          </TableCell>
                          
                          <TableCell>
                            <Typography 
                              variant="body2" 
                              sx={{ 
                                fontFamily: 'monospace', 
                                fontSize: '0.75rem',
                                color: user.externalID ? 'text.primary' : 'text.secondary'
                              }}
                            >
                              {user.externalID || 'Not set'}
                            </Typography>
                          </TableCell>
                          
                          <TableCell align="right">
                            <IconButton
                              aria-label="delete"
                              onClick={() => handleDeleteUser(user.id)}
                              color="error"
                              size="small"
                            >
                              <DeleteIcon />
                            </IconButton>
                          </TableCell>
                        </TableRow>
                      ))}
                    </TableBody>
                  </Table>
                </TableContainer>
              )}
            </>
          )}
        </DialogContent>
        
        <DialogActions>
          <Button onClick={handleClose}>Close</Button>
        </DialogActions>
      </Dialog>

      {/* Add User Dialog */}
      <AddUserDialog
        open={addUserDialogOpen}
        tenantId={tenant.id}
        tenantName={tenant.name}
        onClose={() => setAddUserDialogOpen(false)}
        onSubmit={handleCreateUser}
      />
    </>
  );
};

export default UserManagementDialog;