<template>
  <section class="hero  is-dark is-fullheight" >

    <Header ></Header>
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
import {  onMounted, ref } from 'vue';
import axios from 'axios';
import { useStore } from 'vuex';
export default {
  components: {
    Header,
    Footer,
  },
  setup() {
    const userStore = useStore();
    const hasConfig = ref(true);
    const isLogged = ref(false)

    onMounted(async () => {
      if (!userStore.apiUrl) {
        const response = await axios.get('/config')
        if (response.data) hasConfig.value = true;

        hasConfig.value && userStore.dispatch("urlConfig", response.data.apiUrl);
      } else {
        hasConfig.value = true;
      }
    });
    return { hasConfig, isLogged }
  }
}
</script>