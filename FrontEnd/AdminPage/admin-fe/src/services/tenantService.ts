import { Tenant, CreateTenantData } from '../types/tenant';

// Mock data for demonstration
const mockTenants: Tenant[] = [
  {
    id: '1',
    name: 'John Doe',
    email: 'john.doe@example.com',
    company: 'Tech Corp',
    status: 'active',
    createdAt: new Date('2024-01-15'),
    lastLogin: new Date('2024-02-14'),
    plan: 'premium',
    maxUsers: 50,
    currentUsers: 23
  },
  {
    id: '2',
    name: 'Jane Smith',
    email: 'jane.smith@startup.com',
    company: 'Startup Inc',
    status: 'active',
    createdAt: new Date('2024-02-01'),
    lastLogin: new Date('2024-02-13'),
    plan: 'basic',
    maxUsers: 10,
    currentUsers: 5
  },
  {
    id: '3',
    name: 'Bob Johnson',
    email: 'bob@enterprise.com',
    company: 'Enterprise Solutions',
    status: 'inactive',
    createdAt: new Date('2023-12-20'),
    lastLogin: new Date('2024-01-30'),
    plan: 'enterprise',
    maxUsers: 200,
    currentUsers: 0
  },
  {
    id: '4',
    name: 'Alice Wilson',
    email: 'alice@newcompany.com',
    company: 'New Company LLC',
    status: 'pending',
    createdAt: new Date('2024-02-10'),
    plan: 'basic',
    maxUsers: 10,
    currentUsers: 1
  }
];

let tenants = [...mockTenants];

export const tenantService = {
  // Get all tenants
  getTenants: async (): Promise<Tenant[]> => {
    return new Promise((resolve) => {
      setTimeout(() => resolve([...tenants]), 500);
    });
  },

  // Create a new tenant
  createTenant: async (tenantData: CreateTenantData): Promise<Tenant> => {
    return new Promise((resolve) => {
      setTimeout(() => {
        const newTenant: Tenant = {
          ...tenantData,
          id: Date.now().toString(),
          status: 'pending',
          createdAt: new Date(),
          currentUsers: 0
        };
        tenants.push(newTenant);
        resolve(newTenant);
      }, 500);
    });
  },

  // Update tenant status
  updateTenantStatus: async (id: string, status: Tenant['status']): Promise<Tenant> => {
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        const tenantIndex = tenants.findIndex(t => t.id === id);
        if (tenantIndex !== -1) {
          tenants[tenantIndex] = { ...tenants[tenantIndex], status };
          resolve(tenants[tenantIndex]);
        } else {
          reject(new Error('Tenant not found'));
        }
      }, 300);
    });
  },

  // Delete tenant
  deleteTenant: async (id: string): Promise<void> => {
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        const tenantIndex = tenants.findIndex(t => t.id === id);
        if (tenantIndex !== -1) {
          tenants.splice(tenantIndex, 1);
          resolve();
        } else {
          reject(new Error('Tenant not found'));
        }
      }, 300);
    });
  }
};