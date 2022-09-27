<template>
  <div class="home">
<p>........................</p>
    {{store.getters.getUser}}
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
