<template>
    <v-form v-model="valid" class="darkText mt-5 registerForm">
        <v-container class="elevation-4" style="max-width: 500px">
            <v-row>
                <v-col><h1 class="text-center">Register New Account.</h1></v-col>
            </v-row>
            <v-row justify="center">
                <v-col cols="12" md="9">
                    <v-text-field v-model="firstname" :rules="nameRules" :counter="10" label="Username" required/>
                </v-col>
            </v-row>
            <v-row justify="center">
                <v-col cols="12" md="9">
                    <v-text-field v-model="firstname" :rules="nameRules" :counter="10" label="Email" required/>
                </v-col>
            </v-row>
            <v-row justify="center">
                <v-col cols="12" md="9">
                    <v-text-field v-model="firstname" :rules="nameRules" :counter="10" label="Password" required/>
                </v-col>
            </v-row>
            <v-row justify="center">
                <v-col cols="12" md="9">
                    <v-text-field v-model="firstname" :rules="nameRules" :counter="10" label="Repeat Password"
                                  required/>
                </v-col>
            </v-row>
            <v-row class="mt-5 mb-5" justify="center">
                <v-btn x-large color="primary">Register</v-btn>
            </v-row>
        </v-container>
    </v-form>
</template>

<script lang="ts">
    import Vue from 'vue';
    import Component from 'vue-class-component'

    @Component({components: {}, name: "Register"})
    export default class Register extends Vue {

    }
</script>

<style scoped>
    @media (max-width: 760px) {
        .registerForm {
            margin: 0 !important;
        }
    }
</style>