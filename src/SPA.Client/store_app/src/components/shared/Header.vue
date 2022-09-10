<template>
  <div class="hero-head">
    <nav class="navbar">
      <div class="container">
        <div class="navbar-brand">
          <a class="navbar-item">
            <img src="https://bulma.io/images/bulma-type-white.png" alt="Logo">
          </a>
          <span class="navbar-burger" data-target="navbarMenuHeroB">
            <span></span>
            <span></span>
            <span>asas</span>
          </span>
        </div>
        <div id="navbarMenuHeroC" class="navbar-menu">
          <div class="navbar-end">
            <a class="navbar-item is-active">
              Home
            </a>
            <a class="navbar-item">
              Examples
            </a>
            <a class="navbar-item">
              Documentation
            </a>
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
import { useRouter } from 'vue-router';
import { useUserStore } from '../../store/UserStore';

export default {
setup(){
  const router = useRouter();
  const user = useUserStore()
  const signOut =async ()=>{
    localStorage.removeItem('token');
    console.log(user.getIsLogged)
    await router.push({path:'logIn'})

  }

  return {signOut}
}
}
</script>



<style>
  .hero.is-primary{
    background-color: #2B4F6E;
  }
</style>

