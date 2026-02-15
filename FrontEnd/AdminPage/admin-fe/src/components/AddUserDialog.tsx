import React, { useState } from 'react';
import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  TextField,
  Button,
  Stack,
  CircularProgress,
  Alert
} from '@mui/material';
import { CreateUserData } from '../types/tenant';

interface AddUserDialogProps {
  open: boolean;
  tenantId: string;
  tenantName: string;
  onClose: () => void;
  onSubmit: (userData: CreateUserData) => Promise<void>;
}

const AddUserDialog: React.FC<AddUserDialogProps> = ({
  open,
  tenantId,
  tenantName,
  onClose,
  onSubmit
}) => {
  const [formData, setFormData] = useState<Omit<CreateUserData, 'tenantId'>>({
    name: '',
    email: ''
  });
  
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleInputChange = (field: keyof Omit<CreateUserData, 'tenantId'>) => (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    const value = event.target.value;
    setFormData(prev => ({
      ...prev,
      [field]: value
    }));
  };

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    setLoading(true);
    setError(null);

    try {
      await onSubmit({
        ...formData,
        tenantId
      });
      setFormData({
        name: '',
        email: ''
      });
      onClose();
    } catch (err) {
      setError(err instanceof Error ? err.message : 'An error occurred');
    } finally {
      setLoading(false);
    }
  };

  const handleClose = () => {
    if (!loading) {
      setError(null);
      setFormData({
        name: '',
        email: ''
      });
      onClose();
    }
  };

  const isFormValid = formData.name.trim().length > 0 && formData.email.trim().length > 0;

  return (
    <Dialog open={open} onClose={handleClose} maxWidth="sm" fullWidth>
      <form onSubmit={handleSubmit}>
        <DialogTitle>Add User to {tenantName}</DialogTitle>
        <DialogContent>
          {error && (
            <Alert severity="error" sx={{ mb: 2 }}>
              {error}
            </Alert>
          )}
          
          <Stack spacing={2} sx={{ mt: 1 }}>
            <TextField
              fullWidth
              label="User Name"
              value={formData.name}
              onChange={handleInputChange('name')}
              required
              disabled={loading}
            />
            
            <TextField
              fullWidth
              label="Email"
              type="email"
              value={formData.email}
              onChange={handleInputChange('email')}
              required
              disabled={loading}
            />
          </Stack>
        </DialogContent>
        
        <DialogActions>
          <Button onClick={handleClose} disabled={loading}>
            Cancel
          </Button>
          <Button 
            type="submit" 
            variant="contained" 
            disabled={!isFormValid || loading}
            startIcon={loading ? <CircularProgress size={20} /> : null}
          >
            {loading ? 'Adding...' : 'Add User'}
          </Button>
        </DialogActions>
      </form>
    </Dialog>
  );
};

export default AddUserDialog;