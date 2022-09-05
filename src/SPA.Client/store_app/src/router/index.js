import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import { useUserStore } from '../store/UserStore'

const routes = [
  {
    path: '/logIn',
    name: 'LogIn',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../components/LoginInRegistrer.vue')
  },
  {
    path: '/',
    name: 'Home',
    component: Home,
    meta: {
      requiresAuth: true
    }
  },
  {
    path: '/about',
    name: 'About',
    meta: {
      requiresAuth: true
    },
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  }
]



const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

if (!router) throw 'This doesnt have any route'

router.beforeEach((to, from, next) => {

  const token = useUserStore();
  const requireAuth = to.matched.some(x => x.meta.requiresAuth);

  if (requireAuth) {
    if (!token.getToken) {
      next();
    } else {
      next('/logIn');
    }
  }else{
    next()
  }

});

export default router
