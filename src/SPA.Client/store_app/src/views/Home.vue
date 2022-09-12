<template>
  <div class="home">
<p>........................</p>
    
  </div>
</template>

<script>
// @ is an alias to /src
// import HelloWorld from '@/components/HelloWorld.vue'

import { useStore } from 'vuex';


export default {
  name: 'Home',
  setup(){
    const store = useStore()
    return {store};
    
  }
}
</script>
