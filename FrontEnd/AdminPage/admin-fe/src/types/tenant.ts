export interface Tenant {
  id: string;
  name: string;
}

export interface CreateTenantData {
  name: string;
}

export interface User {
  id: string;
  name: string;
  email: string;
  tenantId: string;
}

export interface CreateUserData {
  name: string;
  email: string;
  tenantId: string;
}