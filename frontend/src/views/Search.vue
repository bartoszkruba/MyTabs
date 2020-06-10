<template>
    <v-container class="darkText">
        <v-row>
            <v-col><h1 class="text-center">Search</h1></v-col>
        </v-row>
        <v-row>
            <v-col>
                <hr>
            </v-col>
        </v-row>
        <v-row>
            <v-col><h3 class="text-center">This is search page.</h3></v-col>
        </v-row>
    </v-container>
</template>

<script lang="ts">
    import Vue from "vue";
    import Component from "vue-class-component"

    @Component({components: {}, name: "Home"})
    export default class Search extends Vue {

    }
</script>
