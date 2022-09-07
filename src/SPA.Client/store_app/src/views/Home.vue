<template>
  <div class="home">
<p>........................</p>
    
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
    console.log("Rendering home-.-.....");
    return store;
    
  }
}
</script>
