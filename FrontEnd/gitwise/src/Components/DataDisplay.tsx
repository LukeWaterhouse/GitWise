import React from "react";
import { Table } from "react-bootstrap";
import { createClaimsTable, ClaimEntry, ClaimsObject } from "../Utils/claimsUtils";

import "../Styles/App.css";

interface IdTokenDataProps {
    idTokenClaims: Record<string, unknown>;
}

export const IdTokenData: React.FC<IdTokenDataProps> = ({ idTokenClaims }) => {
    const tokenClaims: ClaimsObject = createClaimsTable(idTokenClaims);

    const tableRows = Object.keys(tokenClaims).map((key) => {
        const claimEntry: ClaimEntry = tokenClaims[Number(key)];

        return (
            <tr key={key}>
                {claimEntry.map((item, i) => (
                    <td key={i}>{item}</td>
                ))}
            </tr>
        );
    });

    return (
        <div className="data-area-div">
            <p>
                See below the claims in your <strong>ID token</strong>. For more information, visit:{" "}
                <a href="https://docs.microsoft.com/en-us/azure/active-directory/develop/id-tokens#claims-in-an-id-token">
                    docs.microsoft.com
                </a>
            </p>

            <div className="data-area-div">
                <Table responsive striped bordered hover>
                    <thead>
                        <tr>
                            <th>Claim</th>
                            <th>Value</th>
                            <th>Description</th>
                        </tr>
                    </thead>
                    <tbody>{tableRows}</tbody>
                </Table>
            </div>
        </div>
    );
};
