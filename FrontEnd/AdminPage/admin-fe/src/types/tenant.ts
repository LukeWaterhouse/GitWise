export interface Tenant {
  id: string;
  name: string;
  email: string;
  company: string;
  status: 'active' | 'inactive' | 'pending';
  createdAt: Date;
  lastLogin?: Date;
  plan: 'basic' | 'premium' | 'enterprise';
  maxUsers: number;
  currentUsers: number;
}

export interface CreateTenantData {
  name: string;
  email: string;
  company: string;
  plan: 'basic' | 'premium' | 'enterprise';
  maxUsers: number;
}