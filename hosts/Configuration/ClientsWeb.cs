// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.using System.Collections.Generic;

using System.Collections.Generic;
using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace IdentityServerHost.Configuration
{
    public static class ClientsWeb
    {
        static string[] allowedScopes = 
        {
            IdentityServerConstants.StandardScopes.OpenId,
            IdentityServerConstants.StandardScopes.Profile,
            IdentityServerConstants.StandardScopes.Email,
            "resource1.scope1", 
            "resource2.scope1",
            "transaction"
        };
        
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                ///////////////////////////////////////////
                // JS OIDC Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "js_oidc",
                    ClientName = "JavaScript OIDC Client",
                    ClientUri = "http://identityserver.io",
                    
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    
                    RedirectUris =
                    {
                        "https://localhost:9090/index.html",
                        "https://localhost:9090/callback.html",
                        "https://localhost:9090/silent.html",
                        "https://localhost:9090/popup.html",
                        "https://localhost:44301/index.html",
                        "https://localhost:44301/callback.html",
                        "https://localhost:44301/silent.html",
                        "https://localhost:44301/popup.html",
                        "http://localhost:9090/index.html",
                        "http://localhost:9090/callback.html",
                        "http://localhost:9090/silent.html",
                        "http://localhost:9090/popup.html",
                        "http://localhost:44301/index.html",
                        "http://localhost:44301/callback.html",
                        "http://localhost:44301/silent.html",
                        "http://localhost:44301/popup.html",
                        "http://newpostyork.com:9090/index.html",
                        "http://newpostyork.com:9090/callback.html",
                        "http://newpostyork.com:9090/silent.html",
                        "http://newpostyork.com:9090/popup.html",
                        "http://postingtonwash.com:9090/index.html",
                        "http://postingtonwash.com:9090/callback.html",
                        "http://postingtonwash.com:9090/silent.html",
                        "http://postingtonwash.com:9090/popup.html",

                        "http://ec2co-ecsel-1e6vf2i4xmkfh-784591644.us-east-1.elb.amazonaws.com:9090/index.html",
                        "http://ec2co-ecsel-1e6vf2i4xmkfh-784591644.us-east-1.elb.amazonaws.com:9090/callback.html",
                        "http://ec2co-ecsel-1e6vf2i4xmkfh-784591644.us-east-1.elb.amazonaws.com:9090/silent.html",
                        "http://ec2co-ecsel-1e6vf2i4xmkfh-784591644.us-east-1.elb.amazonaws.com:9090/popup.html",

                        "http://ec2co-ecsel-1e6vf2i4xmkfh-784591644.us-east-1.elb.amazonaws.com:9090/index2.html",
                        "https://demo.subless.com/index2.html",
                        "https://demo.subless.com/index.html",
                        "https://demo.subless.com/callback.html",
                        "https://demo.subless.com/silent.html",
                        "https://demo.subless.com/popup.html",
                    },

                    PostLogoutRedirectUris = { 
                        "https://localhost:9090/index.html", 
                        "https://localhost:44301/index.html",
                        "http://postingtonwash.com:9090/index2.html",
                        "http://newpostyork.com:9090/index.html",
                        "https://demo.subless.com/index.html",
                        "http://ec2co-ecsel-1e6vf2i4xmkfh-784591644.us-east-1.elb.amazonaws.com:9090/index2.html",
                        "http://ec2co-ecsel-1e6vf2i4xmkfh-784591644.us-east-1.elb.amazonaws.com:9090/index.html",
                    },
                    AllowedCorsOrigins = { 
                        "https://localhost:9090",
                        "https://localhost:44301",
                        "http://localhost:9090",
                        "http://localhost:44301",
                        "http://newpostyork.com:9090",
                        "http://newpostyork.com:44301",
                        "http://postingtonwash.com:9090",
                        "http://postingtonwash.com:44301",
                        "http://ec2co-ecsel-1e6vf2i4xmkfh-784591644.us-east-1.elb.amazonaws.com:9090"
                    },

                    AllowedScopes = allowedScopes
                },
                
                ///////////////////////////////////////////
                // MVC Automatic Token Management Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "mvc.tokenmanagement",
                    
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,

                    AccessTokenLifetime = 75,

                    RedirectUris = { "https://localhost:44301/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:44301/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44301/signout-callback-oidc" },

                    AllowOfflineAccess = true,

                    AllowedScopes = allowedScopes
                },
                
                ///////////////////////////////////////////
                // MVC Code Flow Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "mvc.code",
                    ClientName = "MVC Code Flow",
                    ClientUri = "http://identityserver.io",

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    RequireConsent = true,
                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://localhost:44302/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:44302/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44302/signout-callback-oidc" },

                    AllowOfflineAccess = true,

                    AllowedScopes = allowedScopes
                },
                
                ///////////////////////////////////////////
                // MVC Hybrid Flow Sample (Back Channel logout)
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "mvc.hybrid.backchannel",
                    ClientName = "MVC Hybrid (with BackChannel logout)",
                    ClientUri = "http://identityserver.io",

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RequirePkce = false,

                    RedirectUris = { "https://localhost:44303/signin-oidc" },
                    BackChannelLogoutUri = "https://localhost:44303/logout",
                    PostLogoutRedirectUris = { "https://localhost:44303/signout-callback-oidc" },

                    AllowOfflineAccess = true,

                    AllowedScopes = allowedScopes
                },
                
                ///////////////////////////////////////////
                // MVC Code Flow with JAR/JWT Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "mvc.jar.jwt",
                    ClientName = "MVC Code Flow with JAR/JWT",

                    ClientSecrets =
                    {
                        new Secret
                        {
                            Type = IdentityServerConstants.SecretTypes.JsonWebKey,
                            Value = "{'e':'AQAB','kid':'ZzAjSnraU3bkWGnnAqLapYGpTyNfLbjbzgAPbbW2GEA','kty':'RSA','n':'wWwQFtSzeRjjerpEM5Rmqz_DsNaZ9S1Bw6UbZkDLowuuTCjBWUax0vBMMxdy6XjEEK4Oq9lKMvx9JzjmeJf1knoqSNrox3Ka0rnxXpNAz6sATvme8p9mTXyp0cX4lF4U2J54xa2_S9NF5QWvpXvBeC4GAJx7QaSw4zrUkrc6XyaAiFnLhQEwKJCwUw4NOqIuYvYp_IXhw-5Ti_icDlZS-282PcccnBeOcX7vc21pozibIdmZJKqXNsL1Ibx5Nkx1F1jLnekJAmdaACDjYRLL_6n3W4wUp19UvzB1lGtXcJKLLkqB6YDiZNu16OSiSprfmrRXvYmvD8m6Fnl5aetgKw'}"
                        }
                    },

                    AllowedGrantTypes = GrantTypes.Code,
                    RequireRequestObject = true,

                    RedirectUris = { "https://localhost:44304/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:44304/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44304/signout-callback-oidc" },

                    AllowOfflineAccess = true,

                    AllowedScopes = allowedScopes
                },
            };
        }
    }
}