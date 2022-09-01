<template>
  <Header></Header>
  
  <router-view />

  <Footer></Footer>

</template>
<script>
import Header from './components/shared/Header.vue';
import Footer from './components/shared/Footer.vue';
import { onMounted, ref } from 'vue';
import { useUserStore } from './store/UserStore';

export default {
  components: {
    Header,
    Footer
  },
  setup() {
    const userStore = useUserStore()
    const hasConfig = ref(false)
    onMounted(async () => {
      const res = fetch('/config', {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json'
        },
      });
      const data = await (await res).json();
      data && !hasConfig.value;

      hasConfig.value && userStore.setConfig(data);
    })




  }
}
</script>