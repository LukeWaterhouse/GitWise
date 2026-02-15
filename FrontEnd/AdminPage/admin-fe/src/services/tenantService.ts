import { Tenant, CreateTenantData } from '../types/tenant';
import { API_CONFIG, buildApiUrl } from '../config/api';

// API service for tenant operations
export const tenantService = {
  // Get all tenants
  getTenants: async (): Promise<Tenant[]> => {
    try {
      const response = await fetch(buildApiUrl(API_CONFIG.ENDPOINTS.TENANTS), {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
        },
      });

      if (!response.ok) {
        throw new Error(`Failed to fetch tenants: ${response.status} ${response.statusText}`);
      }

      const data = await response.json();
      
      // Transform the API response to match our Tenant interface
      // API returns: { id: string, name: string }
      return data.map((tenant: any) => ({
        id: tenant.id,
        name: tenant.name || 'Unknown',
      }));
    } catch (error) {
      console.error('Error fetching tenants:', error);
      throw error;
    }
  },

  // Placeholder functions - not implemented yet
  createTenant: async (tenantData: CreateTenantData): Promise<Tenant> => {
    throw new Error('Create tenant functionality not implemented yet');
  },

  updateTenant: async (id: string, tenantData: Partial<Tenant>): Promise<Tenant> => {
    throw new Error('Update tenant functionality not implemented yet');
  },

  deleteTenant: async (id: string): Promise<void> => {
    throw new Error('Delete tenant functionality not implemented yet');
  }
};