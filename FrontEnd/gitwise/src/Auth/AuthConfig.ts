/*
 * Copyright (c) Microsoft Corporation.
 * Licensed under the MIT License.
 */

import {
    Configuration,
    LogLevel,
    PopupRequest,
    RedirectRequest,
} from "@azure/msal-browser";

/**
 * MSAL configuration object.
 * For full config docs:
 * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-browser/docs/configuration.md
 */
export const msalConfig: Configuration = {
    auth: {
        clientId: "ee7139f1-8c49-47ad-b48c-3203e4d80999",
        authority: "https://Gitwise.ciamlogin.com/",
        redirectUri: "http://localhost:3000/redirect",
        postLogoutRedirectUri: "/",
        navigateToLoginRequestUrl: false,
    },
    cache: {
        cacheLocation: "sessionStorage",
        storeAuthStateInCookie: false,
    },
    system: {
        loggerOptions: {
            loggerCallback: (level: LogLevel, message: string, containsPii: boolean): void => {
                if (containsPii) return;

                switch (level) {
                    case LogLevel.Error:
                        console.error(message);
                        break;
                    case LogLevel.Info:
                        console.info(message);
                        break;
                    case LogLevel.Verbose:
                        console.debug(message);
                        break;
                    case LogLevel.Warning:
                        console.warn(message);
                        break;
                }
            },
        },
    },
};

/**
 * Login request configuration.
 * By default MSAL adds openid/profile/email automatically.
 */
export const loginRequest: PopupRequest | RedirectRequest = {
    scopes: [],
};

/**
 * Optional: enable silent SSO between apps by adding login_hint
 */
// export const silentRequest: SilentRequest = {
//     scopes: ["openid", "profile"],
//     loginHint: "example@domain.net"
// };
