export interface Tenant {
  id: string;
  name: string;
}

export interface CreateTenantData {
  name: string;
}

export interface User {
  id: string;
  emailAddress: string;
  tenantId: string;
  role: 1 | 2; // 1 = User, 2 = Admin
  externalID?: string;
}

export interface CreateUserData {
  emailAddress: string;
  tenantId: string;
  role: 1 | 2;
}