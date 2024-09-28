<template>
    <div class="col-12 col-md-6 col-lg-4 col-xl-3">
        <div class="categoryViewContainer">
            <div class="categoryIcon">
                <div class="randomIcon mb-4"></div>
                <!-- <img :src=categoryImageString /> -->
            </div>
            <div class="categoryName">
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

    .randomIcon{
        width:25px;
        height:25px;
        border-radius: 50%;
        border:1px solid white;
        background-color: aliceblue;
    }

    .categoryName{
        font-size:24px;
        letter-spacing:2.5px;
        text-transform: uppercase;
    }
</style>