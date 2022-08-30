<template>
  <div class="home">
    <HelloWorld msg="Welcome to Your Vue.js App"/>
  </div>
</template>

<script>
// @ is an alias to /src
import HelloWorld from '@/components/HelloWorld.vue'
import {useUserStore} from '@/store/UserStore';

export default {
  name: 'Home',
  components: {
    HelloWorld
  },
  setup(){
    const store = useUserStore()
    console.log("This is not woking",store.userName);
    return store;
    
  }
}
</script>
