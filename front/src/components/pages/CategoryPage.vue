<template>
    <div class="page container categoryPageContainer">  
        <div class="row mt-5">
            <SingleCategoryView categoryName="matematyka" categoryImageString="math-presentation.png"/>
            <SingleCategoryView categoryName="polski" categoryImageString="book-arrangement.png" />
            <SingleCategoryView categoryName="angielski" categoryImageString="language-translation.png" />
            <SingleCategoryView categoryName="programowanie" categoryImageString="computer-science.png" />
        </div>

        <div class="row mt-5">
            <SingleCategoryView categoryName="geografia" categoryImageString="geographic-navigation.png" />
            <SingleCategoryView categoryName="historia" categoryImageString="history-book.png" />
            <SingleCategoryView categoryName="fizyka" categoryImageString="physics-formula.png" />
            <SingleCategoryView categoryName="muzyka" categoryImageString="musical-note.png" />
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
        height:100vh;
    }
</style>