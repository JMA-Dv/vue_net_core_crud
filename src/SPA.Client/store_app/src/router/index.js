/* eslint-disable */


import { createRouter, createWebHistory } from 'vue-router'
import store from '../store/store'
const routes = [
  {
    path: '/logIn',
    name: 'LogIn',
    meta: {
      requiresAuth: false
    },

    component: () => import(/* webpackChunkName: "about" */ '../views/LoginInRegistrer.vue')
  },
  {
    path: '/clients',
    name: 'Clients',
    meta: {
      requiresAuth: true,
      hasAccess: ["Admin"]
    },
    component: () => import(/* webpackChunkName: "about" */ '../views/clients/Client.vue')
  },
  {
    path: '/products',
    name: 'Products',
    meta: {
      requiresAuth: true,
      hasAccess: ["Admin"]
    },
    component: () => import(/* webpackChunkName: "about" */ '../views/products/Product.vue')
  },

  {
    path: '/products/create',
    name: 'ProductsCreate',

    component: () => import(/* webpackChunkName: "about" */ '../views/products/CreateOrUpdate.vue')
  },
  {
    path: '/products/edit/:id',
    name: 'ProductUpdate',

    component: () => import(/* webpackChunkName: "about" */ '../views/products/CreateOrUpdate.vue')
  },
  {
    path: '/orders',
    name: 'Orders',
    meta: {
      requiresAuth: true,
      hasAccess: ["Vendor"]
    },

    component: () => import(/* webpackChunkName: "about" */ '../views/orders/Order.vue')
  },
  {
    path: '/',
    name: 'Home',
    meta: {
      requiresAuth: true,
      hasAccess: ["Admin"]

    },
    component: () => import(/* webpackChunkName: "about" */ '../views/Home.vue'),

  },
  {
    path: '/users',
    name: 'users',
    meta: {
      requiresAuth: true,
      hasAccess: ["Admin"]

    },
    component: () => import(/* webpackChunkName: "about" */ '../views/Users/User.vue'),

  },
  {
    path: '/:pathMatch(.*)*',
    name: 'NotAllowed',

    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/NotFoundOrNotAllow.vue')
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

if (!router) throw 'This doesnt have any route'

router.beforeEach(async (to, from) => {
  const token = localStorage.getItem('token');

  if (!token && to.name !== 'LogIn') {
    return { name: 'LogIn' };
  }

  const routeRequiresAuth = to.matched.some(route => route.meta.requiresAuth);

  if (!routeRequiresAuth && token) {
    return true;
  }

  if (store.getters.getUser)
    var { role } = store.getters.getUser;

  const hasPermission = to.matched.some(route => route.meta.hasAccess == role);
  if (hasPermission) {
    return true;
  } else {
    return { name: 'NotAllowed' }
    // return { name: 'NotAllowed' } 
  }

})

export default router