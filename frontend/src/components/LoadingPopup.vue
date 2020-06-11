<template>
    <div class="popup">
        <v-progress-circular class="mt-12" size="200" indeterminate color="primary"/>
    </div>
</template>

<script lang="ts">
    import Vue from 'vue'
    import Component from 'vue-class-component'

    @Component
    export default class LoadingPopup extends Vue {

    }
</script>

<style scoped>
    .popup {
        position: fixed;
        bottom: 0;
        right: 0;
        z-index: 999;
        background-color: rgba(200, 200, 200, 0.7);
        width: 100vw;
        height: 100vh;
    }
</style>