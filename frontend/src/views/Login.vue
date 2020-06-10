<template>
    <v-container>
        <v-row>
            <v-col><h1 class="text-center">Login to you account.</h1></v-col>
        </v-row>
        <v-row>
            <v-col>
                <hr>
            </v-col>
        </v-row>
        <v-row>
            <v-col>
                <h3 class="text-center">This is login page.</h3>
            </v-col>
        </v-row>
    </v-container>
</template>

<script lang="ts">
    import Vue from 'vue'
    import Component from 'vue-class-component'

    @Component({components: {}, name: "Login"})
    export default class Login extends Vue {

    }
</script>