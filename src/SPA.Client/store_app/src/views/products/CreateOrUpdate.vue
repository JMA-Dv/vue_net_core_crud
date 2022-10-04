<template>


    <div class="field">
        <div class="field">
            <div class="control ">
                <input v-model.trim="product.name" required class="input is-medium" type="text" placeholder="Name">
            </div>
        </div>
        <div class="field">
            <div class="control">
                <input v-model.trim="product.description" class="input is-medium" type="text" placeholder="description">
            </div>
        </div>

        <div class="control ">
            <input v-model.number="product.price" required class="input is-medium" type="number" placeholder="Price">
        </div>
    </div>



    <div class="field">
        <div class="control has-text-right">
            <button class="button is-success" @click="saveProduct">
                Save
            </button>
        </div>
    </div>


</template>

<script>
import { onBeforeMount, ref } from 'vue';
import { useProductApi } from '../../services/useProductApi';
import { useRoute, useRouter } from 'vue-router';

export default {
    setup() {
        const product = ref({});

        const useProduct = useProductApi();
        const router = useRouter();
        const route = useRoute()

        onBeforeMount(async () => {
            if (route.params.id) {
                console.log("Is edit")
                product.value = await useProduct.getById(route.params.id)
            } else {
                console.log("Is Add")
            }
        })
        const saveProduct = async () => {
            let param = route.params.id;
            if (param) {
                const res = await useProduct.edit(param, product.value)
                res && router.push('/products');

            } else {
                const res = await useProduct.create(product.value);
                console.log("🚀 ~ file: CreateOrUpdate.vue ~ line 57 ~ saveProduct ~ res", res)
            }

        };
        return { product, saveProduct };
    },
}
</script>

<style>

</style>