<template>
  <div class="home">
  </div>
</template>

<script>
// @ is an alias to /src
// import HelloWorld from '@/components/HelloWorld.vue'
import {useUserStore} from '@/store/UserStore';

export default {
  name: 'Home',
  setup(){
    const store = useUserStore()
    console.log("This is not woking",store.userName);
    return store;
    
  }
}
</script>
