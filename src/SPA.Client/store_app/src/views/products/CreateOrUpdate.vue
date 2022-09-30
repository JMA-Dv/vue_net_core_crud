<template>
    <div class="field">

        <div class="control ">
            <input v-model.number="product.price" class="input is-medium" type="number" placeholder="Price">
        </div>
    </div>

    <div class="field">
        <div class="control">
            <input v-model.trim="product.description" class="input is-medium" type="text" placeholder="description">
        </div>
    </div>

    <div class="field">
        <div class="control ">
            <input v-model.trim="product.name" class="input is-medium" type="text" placeholder="Name">
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
import { ref } from 'vue';
import { useProductApi } from '../../services/useProductApi';

export default {
    setup() {
        const product = ref({ name: null, description: null, price: 0 })
        const useProduct = useProductApi()
        const saveProduct = async () => await useProduct.create(product.value)


        return { product, saveProduct }
    }
}
</script>

<style>

</style>