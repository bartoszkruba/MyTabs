<template>
    <div class="popup d-flex justify-center fade-in">
        <v-progress-circular class="mt-12 spinner" size="200" indeterminate color="info"/>
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
        background-color: rgba(150, 150, 175, 0.6);
        width: 100vw;
        height: 100vh;
        padding-top: 20vh;
    }

    .fade-in {
        animation: fadeIn ease 0.5s;
        -webkit-animation: fadeIn ease 0.55s;
        -moz-animation: fadeIn ease 0.55s;
        -o-animation: fadeIn ease 0.55s;
        -ms-animation: fadeIn ease 0.55s;
    }

    @keyframes fadeIn {
        0% {
            opacity: 0;
        }
        100% {
            opacity: 1;
        }
    }

    @-moz-keyframes fadeIn {
        0% {
            opacity: 0;
        }
        100% {
            opacity: 1;
        }
    }

    @-webkit-keyframes fadeIn {
        0% {
            opacity: 0;
        }
        100% {
            opacity: 1;
        }
    }

    @-o-keyframes fadeIn {
        0% {
            opacity: 0;
        }
        100% {
            opacity: 1;
        }
    }

    @-ms-keyframes fadeIn {
        0% {
            opacity: 0;
        }
        100% {
            opacity: 1;
        }
    }
</style>