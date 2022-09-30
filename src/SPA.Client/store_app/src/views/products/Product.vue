<template>
  <div>

    <!-- <router-link to="products/create" class="tag is-light my-2">Add new product</router-link> -->
    <div class="has-text-right field">
      <router-link to="products/create">Add new product</router-link>

    </div>


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
        <tr v-for="(item,index) in products" :key="index">
          <td>{{item.productId}}</td>
          <td>{{item.name}}</td>
          <td>{{item.description}}</td>
          <td>{{item.price}}</td>
          <td>
            <button class="button is-warning mx-2">Edit</button>
            <button class="button is-danger">Delete</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import { onMounted, ref } from 'vue';
import { useProductApi } from '../../services/useProductApi';

export default {

  setup() {
    const useProduct = useProductApi();
    const products = ref([]);
    const page = ref(1);

    onMounted(async () => {
      products.value = await useProduct.getAll(page.value, 2);
    })


    return { products };
  },
}
</script>