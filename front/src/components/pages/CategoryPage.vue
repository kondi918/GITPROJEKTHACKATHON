<template>
    <div class="page container categoryPageContainer">  
        <div class="row mt-5">
            <SingleCategoryView categoryName="matematyka" categoryImageString="matematyka.png" />
            <SingleCategoryView categoryName="polski" categoryImageString="polski.png" />
            <SingleCategoryView categoryName="angielski" categoryImageString="angielski.png" />
            <SingleCategoryView categoryName="programowanie" categoryImageString="programowanie.png" />
        </div>

        <div class="row mt-5">
            <SingleCategoryView categoryName="matematyka" categoryImageString="matematyka.png" />
            <SingleCategoryView categoryName="polski" categoryImageString="polski.png" />
            <SingleCategoryView categoryName="angielski" categoryImageString="angielski.png" />
            <SingleCategoryView categoryName="programowanie" categoryImageString="programowanie.png" />
        </div>
    </div>
</template>

<script>
import SingleCategoryView from '../parts/SingleCategoryView.vue';

export default {
    name: "CategoryPage",
    components: {
        SingleCategoryView,
    },
}
</script>

<style>
    .categoryPageContainer{
        padding-top:80px;
        min-height:100vh;
    }
</style>