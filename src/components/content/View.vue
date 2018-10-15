<template>
    <div class="view overlay-image">
        <div class="mask rgba-stylish-strong h-100 d-flex justify-content-center align-items-center">
            <slot></slot>
        </div>
    </div>  
</template>
<style lang="scss">

    html, body, header, .view {
        height: 100vh;
    }

    .overlay-image {
        background: url("/images/background-overlay-view.png") no-repeat center center;
            background-size: cover;
    }
</style>
