console.log("Silent page loaded")
var mgr = new Oidc.UserManager({ loadUserInfo: true, filterProtocolClaims: true, response_mode: "query" });
mgr.signinSilentCallback();
