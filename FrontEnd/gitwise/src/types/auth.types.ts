import { Configuration } from "@azure/msal-browser";

export interface AuthConfig extends Configuration {
	auth: {
		clientId: string;
		authority: string;
		redirectUri: string;
		postLogoutRedirectUri: string;
		navigateToLoginRequestUrl: boolean;
	};
}

export interface AuthUser {
	displayName?: string;
	mail?: string;
	id?: string;
}
