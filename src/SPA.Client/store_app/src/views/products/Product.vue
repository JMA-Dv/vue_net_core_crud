<template>
  <div>

    <!-- <router-link to="products/create" class="tag is-light my-2">Add new product</router-link> -->
    <div class="has-text-right field">
      <router-link to="products/create">Add new product</router-link>

    </div>

    <div>

      <table class="table is-bordered is-striped is-narrow is-hoverable is-fullwidth">
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Description</th>
            <th>Price</th>
            <th>Actions</th>

          </tr>
        </thead>
        <tbody>
          <tr v-for="(item,index) in products.items" :key="index">
            <td>{{item.productId}}</td>
            <td>{{item.name}}</td>
            <td>{{item.description}}</td>
            <td>{{item.price}}</td>
            <td>
              <!-- <button class="button is-warning mx-2">Edit</button> -->
              <router-link class="button is-warning mx-2" :to="{name:'ProductUpdate',params:{id:item.productId}}">
                Edit
              </router-link>
              <button @click="deleteProduct(item.productId)" class="button is-danger">Delete</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <pagination :paging="p=> paging(p)" :pages="products.pages" :page="products.page"></pagination>
  </div>
</template>

<script>
import { onMounted, ref } from 'vue';
import { useProductApi } from '../../services/useProductApi';
import Pagination from '../../components/shared/Pagination.vue';

export default {
  setup() {
    const useProduct = useProductApi();
    const products = ref([]);
    // const isLoading = ref(false);
    const getProducts = async (page) => await useProduct.getAll(page, 7)

    onMounted(async () => {
      products.value = await getProducts(1)
    });

    const paging = async (page) => {
      if (page === products.value.page)
        return;
      products.value = await getProducts(page);
    }

    const deleteProduct = async (id) => {
      if (!id) return;

      return await useProduct.deleteProduct(id);

    }

    return { products, paging, deleteProduct };
  },
  components: { Pagination }
}
</script>