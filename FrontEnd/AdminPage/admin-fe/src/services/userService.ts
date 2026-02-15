import { User, CreateUserData } from '../types/tenant';
import { API_CONFIG, buildApiUrl } from '../config/api';

// API service for user operations
export const userService = {
  // Get users for a specific tenant
  getUsersByTenant: async (tenantId: string): Promise<User[]> => {
    try {
      const response = await fetch(buildApiUrl(`/api/User/tenant/${tenantId}`), {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
        },
      });

      if (!response.ok) {
        throw new Error(`Failed to fetch users: ${response.status} ${response.statusText}`);
      }

      const data = await response.json();
      
      // Transform the API response to match our User interface
      return data.map((user: any) => ({
        id: user.id,
        emailAddress: user.emailAddress || user.email || '',
        tenantId: tenantId,
        role: user.role || 1,
        externalID: user.externalID || user.externalId || '',
      }));
    } catch (error) {
      console.error('Error fetching users:', error);
      throw error;
    }
  },

  // Create a new user for a tenant
  createUser: async (userData: CreateUserData): Promise<User> => {
    try {
      const response = await fetch(buildApiUrl('/api/User'), {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          emailAddress: userData.emailAddress,
          tenantId: userData.tenantId,
          role: userData.role,
        }),
      });

      if (!response.ok) {
        throw new Error(`Failed to create user: ${response.status} ${response.statusText}`);
      }

      const data = await response.json();
      
      return {
        id: data.id,
        emailAddress: data.emailAddress || userData.emailAddress,
        tenantId: userData.tenantId,
        role: data.role || userData.role,
        externalID: data.externalID || data.externalId || '',
      };
    } catch (error) {
      console.error('Error creating user:', error);
      throw error;
    }
  },

  // Delete a user
  deleteUser: async (userId: string): Promise<void> => {
    try {
      const response = await fetch(buildApiUrl(`/api/users/${userId}`), {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json',
        },
      });

      if (!response.ok) {
        throw new Error(`Failed to delete user: ${response.status} ${response.statusText}`);
      }
    } catch (error) {
      console.error('Error deleting user:', error);
      throw error;
    }
  }
};