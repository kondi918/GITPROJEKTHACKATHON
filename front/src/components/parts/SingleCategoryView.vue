<template>
    <div class="col-12 col-md-6 col-lg-4 col-xl-3">
        <div class="categoryViewContainer">
            <div class="categoryIcon">
                <img :src=categoryImageString />
            </div>
            <div class="categoryName font-fredoka">
                {{ categoryName }}
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "SingleCategoryView",
    props: {
        categoryName: String,
        categoryImageString: String
    }
}
</script>

<style scoped>
    .categoryViewContainer{
        height:30vh;
        display:flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
        color:white;
    }

    .categoryName{
        font-size:24px;
        letter-spacing:2.5px;
        text-transform: uppercase;
        color: #DDFFDD;

    }
</style>