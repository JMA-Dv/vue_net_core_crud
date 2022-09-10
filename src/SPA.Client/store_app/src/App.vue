<template>
  <section class="hero is-fullheight" :class="{'is-primary': isLogged===true, 'is-light':isLogged === false}">

    <Header v-if="isLogged"></Header>
    <div class="hero-body">
      <div class="container">

        <notifications position="top right" width="550" />
        <router-view />
      </div>
    </div>
    <Footer v-once></Footer>
  </section>
</template>
<script>
import Header from './components/shared/Header.vue';
import Footer from './components/shared/Footer.vue';
import { onBeforeMount, ref } from 'vue';
import { useUserStore } from './store/UserStore';
import axios from 'axios';
export default {
  components: {
    Header,
    Footer,
  },
  setup() {
    const userStore = useUserStore();
    const hasConfig = ref(true);
    const isLogged = ref(false)


    onBeforeMount(async () => {
      console.log("Entroi en mounted",userStore.getIsLogged)
      if(!userStore.apiUrl){
        const response = await axios.get('/config')
        if (response.data) hasConfig.value = true;
  
        hasConfig.value && userStore.setConfig(response.data.apiUrl);
      }else{
        hasConfig.value = true;
      }
      isLogged.value = userStore.getIsLogged
       
    });
    
    
    return { hasConfig,isLogged }
  }
}
</script>