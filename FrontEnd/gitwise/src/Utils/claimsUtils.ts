export type ClaimEntry = [string, string | number, string];

export interface ClaimsObject {
    [index: number]: ClaimEntry;
}

export type Claims = Record<string, unknown>;

const changeDateFormat = (date: number): string => {
    const dateObj = new Date(date * 1000);
    return `${date} - [${dateObj.toString()}]`;
};

const populateClaim = (
    claim: string,
    value: string | number,
    description: string,
    index: number,
    claimsObject: ClaimsObject
): void => {
    const entry: ClaimEntry = [claim, value, description];
    claimsObject[index] = entry;
};

export const createClaimsTable = (claims: Claims): ClaimsObject => {
    const claimsObj: ClaimsObject = {};
    let index = 0;

    Object.keys(claims).forEach((key) => {
        const value = claims[key];

        // Only process primitive string/number claims
        if (typeof value !== "string" && typeof value !== "number") {
            return;
        }

        switch (key) {
            case "aud":
                populateClaim(
                    key,
                    value,
                    "Identifies the intended recipient of the token. In ID tokens, the audience is your app's Application ID.",
                    index++,
                    claimsObj
                );
                break;

            case "iss":
                populateClaim(
                    key,
                    value,
                    "Identifies the issuer / authorization server that issued the token.",
                    index++,
                    claimsObj
                );
                break;

            case "iat":
                populateClaim(
                    key,
                    changeDateFormat(Number(value)),
                    "Issued At indicates when the authentication for this token occurred.",
                    index++,
                    claimsObj
                );
                break;

            case "nbf":
                populateClaim(
                    key,
                    changeDateFormat(Number(value)),
                    "The time before which the JWT must not be accepted.",
                    index++,
                    claimsObj
                );
                break;

            case "exp":
                populateClaim(
                    key,
                    changeDateFormat(Number(value)),
                    "Expiration time after which the JWT must not be accepted.",
                    index++,
                    claimsObj
                );
                break;

            case "name":
                populateClaim(
                    key,
                    value,
                    "Human-readable name for display purposes only.",
                    index++,
                    claimsObj
                );
                break;

            case "preferred_username":
                populateClaim(
                    key,
                    value,
                    "Primary username (email/phone/UPN). Mutable — not for authorization decisions.",
                    index++,
                    claimsObj
                );
                break;

            case "nonce":
                populateClaim(
                    key,
                    value,
                    "Must match the nonce in the original authorization request.",
                    index++,
                    claimsObj
                );
                break;

            case "oid":
                populateClaim(
                    key,
                    value,
                    "The user's object ID — the only reliable unique user identifier.",
                    index++,
                    claimsObj
                );
                break;

            case "tid":
                populateClaim(
                    key,
                    value,
                    "The tenant ID of the user.",
                    index++,
                    claimsObj
                );
                break;

            case "upn":
                populateClaim(
                    key,
                    value,
                    "User principal name — may be reassigned and is not a stable unique identifier.",
                    index++,
                    claimsObj
                );
                break;

            case "email":
                populateClaim(
                    key,
                    value,
                    "Email may be reassigned and should not be used as a permanent user identifier.",
                    index++,
                    claimsObj
                );
                break;

            case "acct":
                populateClaim(
                    key,
                    value,
                    "Indicates user type (homed/guest). Useful for access control.",
                    index++,
                    claimsObj
                );
                break;

            case "sid":
                populateClaim(
                    key,
                    value,
                    "Session ID, used for per-session sign-out.",
                    index++,
                    claimsObj
                );
                break;

            case "sub":
                populateClaim(
                    key,
                    value,
                    "Pairwise identifier unique per application ID.",
                    index++,
                    claimsObj
                );
                break;

            case "ver":
                populateClaim(
                    key,
                    value,
                    "Version of the token.",
                    index++,
                    claimsObj
                );
                break;

            case "uti":
            case "rh":
                index++;
                break;

            case "_claim_names":
            case "_claim_sources":
            default:
                populateClaim(key, value, "", index++, claimsObj);
                break;
        }
    });

    return claimsObj;
};
