import Vue from "vue";
import Router from "vue-router";
import Auth from "@okta/okta-vue";

import Permisos from "@/components/PermisosRecords";

Vue.use(Auth, {
  issuer: "https://dev-928406.okta.com/oauth2/default",
  client_id: "0oawwn4087NXp7ZkW4x6",
  redirect_uri: "http://localhost:8080/implicit/callback",
  scope: "openid profile email"
});

Vue.use(Router);

let router = new Router({
  mode: "history",
  routes: [{
      path: "/create-permisos",
      name: "Permisos",
      component: Permisos,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/implicit/callback",
      component: Auth.handleCallback()
    }
  ]
});

router.beforeEach(Vue.prototype.$auth.authRedirectGuard());

export default router;
