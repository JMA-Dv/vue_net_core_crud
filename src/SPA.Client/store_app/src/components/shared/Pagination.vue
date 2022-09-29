<template>
    <nav class="pagination is-rounded" role="navigation" aria-label="pagination">
        <a class="pagination-previous">Previous</a>
        <a class="pagination-next">Next page</a>
        <ul class="pagination-list">
            <li v-for="index in pages" :key="index"><a class="pagination-link" @click="paging(index)"
                    :class="{'is-current': index === page}">{{index}}</a></li>
        </ul>
    </nav>
</template>

<script>
export default {
    props: {
        page: {
            type: Number,
            required: true
        },
        pages: {
            type: Number,
            required: true
        },
        paging: {
            type: Function,
            required: true
        }
    },
    setup() {

    }
}
</script>

<style>

</style>