<template>
    <div class="page container productPageContainer">
        <div class="row">
            <SingleProductView productName="Książka" productImageString="ksiazka.png" />
            <SingleProductView productName="Książka" productImageString="ksiazka.png" />
            <SingleProductView productName="Książka" productImageString="ksiazka.png" />
            <SingleProductView productName="Książka" productImageString="ksiazka.png" />
        </div>

        <div class="row">
            <SingleProductView productName="Książka" productImageString="ksiazka.png" />
            <SingleProductView productName="Książka" productImageString="ksiazka.png" />
            <SingleProductView productName="Książka" productImageString="ksiazka.png" />
            <SingleProductView productName="Książka" productImageString="ksiazka.png" />
        </div>
    </div>
</template>

<script>
import SingleProductView from '../parts/SingleProductView.vue';

export default {
    name: "ShopPage",
    components: {
        SingleProductView,
    }
}
</script>

<style scoped>
    .productPageContainer{
        padding-top:80px;
        height:100vh;
    }
</style>