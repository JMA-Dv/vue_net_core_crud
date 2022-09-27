<template>
  <div class="hero-head">
    <nav class="navbar">
      <div class="container">
        <div class="navbar-brand">
          <a class="navbar-item">
            <img src="https://bulma.io/images/bulma-type-white.png" alt="Logo">
          </a>
          <span class="navbar-burger" data-target="navbarMenuHeroB">
            <span aria-hidden="true">1</span>
            <span aria-hidden="true">2</span>
            <span aria-hidden="true">3</span>
          </span>
        </div>
        <div id="navbarMenuHeroC" class="navbar-menu">
          <div class="navbar-end">
            <router-link v-for="(item,index) in routes" :key="index" :to="item.route" class="navbar-item" :class="{'is-active' : router.currentRoute == item.route}">
              {{item.name}}
            </router-link>
            <!-- <a class="navbar-item is-active">
              
            </a>
            <a class="navbar-item">
              Examples
            </a>
            <a class="navbar-item">
              {{user.unique_name}}
            </a>
          -->
            <span class="navbar-item">
              <a class="button is-info is-inverted" @click="signOut">
                <span>LogOut</span>
              </a>
            </span> 
          </div>
        </div>
      </div>
    </nav>
  </div>


</template>

<script>
import { computed, ref } from 'vue';
import { useRouter } from 'vue-router';
import { useStore } from 'vuex';
export default {
  emits: ['is-logged'],
  setup(props, { emit }) {
    const router = useRouter();
    const userStore = useStore();
    const routes = ref([
      {route:'/',name:'Home'},
      {route:'/orders',name:'Orders'},
      {route:'/clients',name:'Client'},
      {route:'/products',name:'Products'},
      {route:'/users',name:'Users'},
    ])
    const signOut = async () => {
      localStorage.removeItem('token');
      userStore.commit("setIsLogged",false);
      emit('is-logged');
      await router.push({ path: 'logIn' })
    }

    return { signOut, user:computed(()=> userStore.getters.getUser),routes,router }
  }
}
</script>



<style>
/* .hero.is-primary {
  background-color: #2B4F6E;
} */
</style>

