import React, { useState } from 'react';
import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  TextField,
  Button,
  Box,
  Stack,
  CircularProgress,
  Alert
} from '@mui/material';
import { CreateTenantData } from '../types/tenant';

interface AddTenantDialogProps {
  open: boolean;
  onClose: () => void;
  onSubmit: (tenantData: CreateTenantData) => Promise<void>;
}

const AddTenantDialog: React.FC<AddTenantDialogProps> = ({
  open,
  onClose,
  onSubmit
}) => {
  const [formData, setFormData] = useState<CreateTenantData>({
    name: ''
  });
  
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleInputChange = (field: keyof CreateTenantData) => (
    event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement> | any
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
      await onSubmit(formData);
      setFormData({
        name: ''
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
      onClose();
    }
  };

  const isFormValid = formData.name.trim().length > 0;

  return (
    <Dialog open={open} onClose={handleClose} maxWidth="md" fullWidth>
      <form onSubmit={handleSubmit}>
        <DialogTitle>Add New Tenant</DialogTitle>
        <DialogContent>
          {error && (
            <Alert severity="error" sx={{ mb: 2 }}>
              {error}
            </Alert>
          )}
          
          <Stack spacing={2} sx={{ mt: 1 }}>
            <TextField
              fullWidth
              label="Tenant Name"
              value={formData.name}
              onChange={handleInputChange('name')}
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
            {loading ? 'Creating...' : 'Create Tenant'}
          </Button>
        </DialogActions>
      </form>
    </Dialog>
  );
};

export default AddTenantDialog;