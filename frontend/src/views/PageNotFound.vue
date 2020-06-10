<template>
    <v-container class="darkText">
        <v-row>
            <v-col><h1 class="text-center">Page Not Found :(</h1></v-col>
        </v-row>
        <v-row>
            <v-col><h3 class="text-center">Page you are trying to access does not exist.</h3></v-col>
        </v-row>
    </v-container>
</template>

<script>
    import Vue from 'vue';
    import Component from 'vue-class-component'

    @Component({component: {}, name: "PageNotFound"})
    export default class PageNotFound extends Vue {

    }
</script>