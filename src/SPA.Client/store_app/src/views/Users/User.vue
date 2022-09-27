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
      <tr v-for="(item,index) in users.data " :key="index">
        <td>{{item.userName}}</td>
        <td>{{item.email}}</td>
        <td>{{item.role}}</td>
      </tr>
    </tbody>
  </table>
  <Pagination></Pagination>
</template>

<script>
import { onMounted, ref } from 'vue';
import { useUserApi } from '../../services/useUserApi';
import Pagination from '../../components/shared/Pagination.vue';

export default {
  setup() {
    const useUser = useUserApi();
    const page = ref(1);
    const users = ref([]);
    const getUsers = async (page) => {
      return await useUser.getAll(page, 1);
    };
    onMounted(async () => {
      users.value = await getUsers(page.value);
      console.log("🚀 ~ file: User.vue ~ line 37 ~ onMounted ~ users", users.value);
    });
    const inf = ref([
      { name: "Dault", mail: "def@email.com", role: "Vendor", }
    ]);
    return { inf, users };
  },
  components: { Pagination }
}
</script>