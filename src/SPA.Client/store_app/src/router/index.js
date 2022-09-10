import { createRouter, createWebHistory } from 'vue-router'

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
    component: () => import(/* webpackChunkName: "about" */ '../views/Home.vue'),
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
  if(!to.matched || to.matched.length === 0 ){
    next({name:'LogIn'});

  }
  const routeRequiresAuth = to.matched.some(route => route.meta.requiresAuth);  
  const token = localStorage.getItem('token');

  if(!routeRequiresAuth){
    next();
  }
  if(!token){
    next({name:'LogIn'});
  }else{
    console.log("Should render")
    next();
  }
  

});

export default router
