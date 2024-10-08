﻿const baseUrl = "https://localhost:7056/api";

//Keys of ClaimTypes
const roleClaimTypeKey = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
const userIdClaimTypeKey = "http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid";
const nameClaimTypeKey = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";

//Values of ClaimTypes
const adminRoleClaimTypeValue = "Admin";

// Axios configuration
let axiosConfig = {
    headers: { Authorization: `Bearer ${sessionStorage.getItem("token")}` }
};

//Methods
function getDecodedToken() {
    const token = sessionStorage.getItem("token");
    if (token == null) {
        return "";
    }
    else {
        const decodedToken = jwt_decode(token);
        return decodedToken;
    }
}

function readUserNameFromToken() {
    const decodedToken = getDecodedToken();
    return decodedToken[nameClaimTypeKey];
}

function readUserIdFromToken() {
    const decodedToken = getDecodedToken();
    var id = decodedToken[userIdClaimTypeKey];
    return id;
}


function readUserRoleFromToken() {
    const decodedToken = getDecodedToken();
    return decodedToken[roleClaimTypeKey];
}

function hasUserAdminRole() {
    if (readUserRoleFromToken() === adminRoleClaimTypeValue) {
        return true;
    }
    else {
        return false;
    }
}