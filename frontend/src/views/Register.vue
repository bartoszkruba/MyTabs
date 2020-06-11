<template>
    <v-form class="darkText mt-5 registerForm" ref="form">
        <v-container class="elevation-4" style="max-width: 500px">
            <v-row>
                <v-col><h1 class="text-center">Register New Account.</h1></v-col>
            </v-row>
            <v-row justify="center">
                <v-col cols="12" md="9">
                    <v-text-field v-model="username" :rules="usernameRules" :counter="20" label="Username" required/>
                </v-col>
            </v-row>
            <v-row justify="center">
                <v-col cols="12" md="9">
                    <v-text-field v-model="email" :rules="emailRules" label="Email" required/>
                </v-col>
            </v-row>
            <v-row justify="center">
                <v-col cols="12" md="9">
                    <v-text-field type="password" v-model="password" :rules="passwordRules" label="Password" required/>
                </v-col>
            </v-row>
            <v-row justify="center">
                <v-col cols="12" md="9">
                    <v-text-field type="password" v-model="repeatPassword" :rules="repeatPasswordRules"
                                  label="Repeat Password" required/>
                </v-col>
            </v-row>
            <v-row class="mt-5 mb-5" justify="center">
                <v-btn :disabled="!valid" x-large color="primary" v-on:click="register">Register</v-btn>
            </v-row>
        </v-container>
    </v-form>
</template>

<script lang="ts">
    import Vue from 'vue';
    import Component from 'vue-class-component'
    import {Prop} from 'vue-property-decorator'

    @Component({components: {}, name: "Register"})
    export default class Register extends Vue {

        get valid() {
            for (const rule of this.usernameRules) if (rule(this.username) != true) return false;
            for (const rule of this.emailRules) if (rule(this.email) != true) return false;
            for (const rule of this.passwordRules) if (rule(this.password) != true) return false;
            for (const rule of this.repeatPasswordRules) if (rule(this.repeatPassword) != true) return false;
            return true;
        }

        @Prop()
        private username = ''

        private usernameRules = [
            v => !!v || "Field is required",
            v => (!!v && v.length >= 4 && v.length <= 20) || 'Username must be between 4 and 20 characters longs',
            v => (!!v && !v.includes(" ")) || "No spaces allowed"
        ]
        @Prop()
        public email = ''
        private emailRules = [
            v => !!v || "Field is required",
            v => /.+@.+\..+/.test(v) || "Invalid email",
        ]
        @Prop()
        public password = ''
        private passwordRules = [
            v => !!v || "Field is required",
            v => (!!v && !v.includes(" ")) || "No spaces allowed"
        ]
        @Prop()
        public repeatPassword = ''
        private repeatPasswordRules = [
            v => !!v || "Field is required",
            v => (!!v && !v.includes(" ")) || "No spaces allowed",
            v => (v == this.password) || "Passwords do not matches"
        ]

        private register = async () => {
            console.log(`Username: ${this.username}`)
            console.log(`Email: ${this.email}`)
            console.log(`Password: ${this.password}`)
            console.log(`Repeat Password: ${this.repeatPassword}`)
        }
    }
</script>

<style scoped>
    @media (max-width: 760px) {
        .registerForm {
            margin: 0 !important;
        }
    }
</style>