<template>
  <table class="table is-bordered is-striped is-narrow is-hoverable is-fullwidth">
    <thead>
      <tr>
        <th>User</th>
        <th>E-Mail</th>
        <th>Admin</th>

      </tr>
    </thead>
    <tbody>
      <tr v-for="(item,index) in inf" :key="index">
        <td>{{item.name}}</td>
        <td>{{item.mail}}</td>
        <td>{{item.role}}</td>
      </tr>
    </tbody>
  </table>
</template>

<script>
import { onMounted, ref } from 'vue';
import { useUserApi } from '../../services/useUserApi';

export default {
  setup() {

    const useUser = useUserApi();
    var page = ref(1);

    const getUsers = async (page) => {
      return await useUser.getAll(page,1);
    }
    onMounted(async ()=>{
      const res = await getUsers(page.value);
      console.log("🚀 ~ file: User.vue ~ line 33 ~ onMounted ~ res", res)      
    })

    const inf = ref([
      { name: "Dault", mail: "def@email.com", role: "Vendor", }
    ])
    return { inf }
  }
}
</script>