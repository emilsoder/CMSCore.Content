interface AuthConfig {
  clientID: string;
  domain: string;
  callbackURL: string;
  apiUrl: string;
}

export const AUTH_CONFIG: AuthConfig = {
  clientID: 'dYHFgoTMjfseGRjW6fjMV9hmF2Ko0QiT',
  domain: 'cmscore-prod.eu.auth0.com',
  callbackURL: 'http://localhost:3000/callback',
  apiUrl: 'http://localhost:50467/api'
};
