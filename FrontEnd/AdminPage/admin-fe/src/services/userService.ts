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
        name: user.name || 'Unknown',
        email: user.email || '',
        tenantId: tenantId,
      }));
    } catch (error) {
      console.error('Error fetching users:', error);
      throw error;
    }
  },

  // Create a new user for a tenant
  createUser: async (userData: CreateUserData): Promise<User> => {
    try {
      const response = await fetch(buildApiUrl(`${API_CONFIG.ENDPOINTS.TENANTS}/${userData.tenantId}/users`), {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          name: userData.name,
          email: userData.email,
        }),
      });

      if (!response.ok) {
        throw new Error(`Failed to create user: ${response.status} ${response.statusText}`);
      }

      const data = await response.json();
      
      return {
        id: data.id,
        name: data.name || userData.name,
        email: data.email || userData.email,
        tenantId: userData.tenantId,
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