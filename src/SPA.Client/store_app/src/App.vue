<template>
  <section class="hero is-light is-fullheight">

    <Header v-if="hasConfig"></Header>
    <div class="hero-body">
      <div class="container">

        <router-view />
      </div>
    </div>
    
    
    
    <Footer></Footer>
  </section>
</template>
<script>
import Header from './components/shared/Header.vue';
import Footer from './components/shared/Footer.vue';
import { inject, onMounted, ref } from 'vue';
import { useUserStore } from './store/UserStore';

export default {
  components: {
    Header,
    Footer,
},
  setup() {
    const userStore = useUserStore();
    const hasConfig = ref(true);
    const logIn = inject('proxies');

    onMounted(async () => {
      logIn();
      if (userStore.getUrl) {
        // const res = fetch('/config', {
        //   method: 'GET',
        //   headers: {
        //     'Content-Type': 'application/json'
        //   },
        // });

        // const data = (res !== undefined) ? await (await res).json(): res;

        // if (data) {
        //   hasConfig.value = true;
        // }

        // hasConfig.value && userStore.setConfig(data);

      }
      return{hasConfig}
    });


  }
}
</script>
