import React, { useState } from 'react';
import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  TextField,
  Button,
  FormControl,
  InputLabel,
  Select,
  MenuItem,
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
    name: '',
    email: '',
    company: '',
    plan: 'basic',
    maxUsers: 10
  });
  
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleInputChange = (field: keyof CreateTenantData) => (
    event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement> | any
  ) => {
    const value = event.target.value;
    setFormData(prev => ({
      ...prev,
      [field]: field === 'maxUsers' ? parseInt(value) || 0 : value
    }));
  };

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    setLoading(true);
    setError(null);

    try {
      await onSubmit(formData);
      setFormData({
        name: '',
        email: '',
        company: '',
        plan: 'basic',
        maxUsers: 10
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

  const isFormValid = formData.name && formData.email && formData.company && formData.maxUsers > 0;

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
            <Box sx={{ display: 'flex', gap: 2 }}>
              <TextField
                fullWidth
                label="Full Name"
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
            </Box>
            
            <TextField
              fullWidth
              label="Company"
              value={formData.company}
              onChange={handleInputChange('company')}
              required
              disabled={loading}
            />
            
            <Box sx={{ display: 'flex', gap: 2 }}>
              <FormControl fullWidth required>
                <InputLabel>Plan</InputLabel>
                <Select
                  value={formData.plan}
                  label="Plan"
                  onChange={handleInputChange('plan')}
                  disabled={loading}
                >
                  <MenuItem value="basic">Basic</MenuItem>
                  <MenuItem value="premium">Premium</MenuItem>
                  <MenuItem value="enterprise">Enterprise</MenuItem>
                </Select>
              </FormControl>
              
              <TextField
                fullWidth
                label="Max Users"
                type="number"
                value={formData.maxUsers}
                onChange={handleInputChange('maxUsers')}
                required
                disabled={loading}
                inputProps={{ min: 1 }}
              />
            </Box>
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