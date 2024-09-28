<template>
    <div class="col-12 col-md-6 col-lg-4 col-xl-3">
        <div class="productViewContainer">
            <div class="productIcon">
                <div class="randomIcon mb-4"></div>
                <!-- <img :src=categoryImageString /> -->
            </div>
            <div class="categoryName">
                {{ productName }}
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "SingleProductView",
    props: {
        productName: String,
        productImageString: String
    }
}
</script>

<style scoped>
    .productViewContainer{
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

    .productName{
        font-size:24px;
        letter-spacing:2.5px;
        text-transform: uppercase;
    }
</style>