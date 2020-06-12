<template>
    <v-form class="darkText mt-5 registerForm" ref="form" v-model="valid">
        <LoadingPopup v-if="loading"/>
        <v-container class="elevation-4" style="max-width: 500px">
            <v-row>
                <v-col><h1 class="text-center">Register New Account.</h1></v-col>
            </v-row>
            <v-row justify="center" v-show="error">
                <v-col cols="12" md="9">
                    <v-alert text type="error">{{error}}</v-alert>
                </v-col>
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
    import {Vue, Component} from 'vue-property-decorator'
    import LoadingPopup from '@/components/LoadingPopup.vue';
    import {createNewUser} from "@/util/api";

    @Component({components: {LoadingPopup}, name: "Register"})
    export default class Register extends Vue {
        private valid = false
        private username = ''
        private email = ''
        private password = ''
        private repeatPassword = ''
        private error = ''
        private loading = false

        private usernameRules = [
            v => !!v || "Field is required",
            v => (!!v && v.length >= 4 && v.length <= 20) || 'Username must be between 4 and 20 characters longs',
            v => (!!v && !v.includes(" ")) || "No spaces allowed"
        ]
        private emailRules = [
            v => !!v || "Field is required",
            v => /.+@.+\..+/.test(v) || "Invalid email",
        ]
        private passwordRules = [
            v => !!v || "Field is required",
            v => (!!v && !v.includes(" ")) || "No spaces allowed"
        ]
        private repeatPasswordRules = [
            v => !!v || "Field is required",
            v => (!!v && !v.includes(" ")) || "No spaces allowed",
            () => this.passwordsMatches() || "Passwords do not matches"
        ]

        private passwordsMatches() {
            return this.password == this.repeatPassword
        }

        private async register() {
            try {
                this.loading = true;
                await createNewUser(this.username, this.email, this.password);
                this.loading = false;
                await this.$router.push("login");
            } catch (e) {
                if (e.response && e.response.status && e.response.status >= 400 && e.response.status < 500 &&
                    e.response.data && e.response.data.error) {
                    this.error = e.response.data.error;
                } else this.error = "Oops, something went wrong. Try again.";
                this.loading = false;
            }
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