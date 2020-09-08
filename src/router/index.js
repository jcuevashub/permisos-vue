import Vue from "vue";
import Router from "vue-router";
import Auth from "@okta/okta-vue";

import Hello from "@/components/Hello";

import Permisos from "@/components/PermisosRecords";

Vue.use(Auth, {
  issuer: "https://developer.okta.com/oauth2/default",
  client_id: "0oawe660oOrPKDjzh4x6",
  redirect_uri: "http://localhost:8080/implicit/callback",
  scope: "openid profile email"
});

Vue.use(Router);

let router = new Router({
  mode: "history",
  routes: [
    {
      path: "/",
      name: "Permisos",
      component: Permisos
    },
    {
      path: "/implicit/callback",
      component: Auth.handleCallback()
    },
    {
      path: "/permisos-records",
      name: "Permisos",
      component: Permisos
      // meta: {
      //   requiresAuth: true
      // }
    }
  ]
});

router.beforeEach(Vue.prototype.$auth.authRedirectGuard());

export default router;
