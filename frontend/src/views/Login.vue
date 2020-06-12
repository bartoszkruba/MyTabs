<template>
    <v-form class="darkText mt-5 loginForm" ref="form" v-model="valid">
        <LoadingPopup v-if="loading"/>
        <v-container class="elevation-4" style="max-width: 500px">
            <v-row>
                <v-col><h1 class="text-center">Login To Your Account.</h1></v-col>
            </v-row>
            <v-row justify="center" v-show="error">
                <v-col cols="12" md="9">
                    <v-alert text type="error">{{error}}</v-alert>
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
            <v-row class="mt-5 mb-5" justify="center">
                <v-btn :disabled="!valid" x-large color="primary" v-on:click="login">Login</v-btn>
            </v-row>
        </v-container>
    </v-form>
</template>

<script lang="ts">
    import {Vue, Component} from 'vue-property-decorator'
    import LoadingPopup from "@/components/LoadingPopup.vue"
    import {login} from "@/util/api"
    import User from "@/models/User"
    import {stringToRole} from "@/util/functions"
    import {saveUserInCookies} from "@/util/cookies"

    @Component({components: {LoadingPopup}, name: "Login"})
    export default class Login extends Vue {
        private valid = false
        private email = ""
        private password = ""

        private error = ""
        private loading = false

        private emailRules = [
            v => !!v || "Field is required",
            v => /.+@.+\..+/.test(v) || "Invalid email",
        ]
        private passwordRules = [v => !!v || "Field is required"]

        private async login() {
            try {
                this.loading = true;
                const response = await login(this.email, this.password);
                const user = new User(response.data.id, response.data.token, response.data.username,
                    stringToRole(response.data.role));
                saveUserInCookies(user);
                this.$store.commit("setUser", user);
                this.loading = false;
                await this.$router.push("/");
            } catch (e) {
                if (e.response && e.response.status && e.response.status >= 400 && e.response.status < 500)
                    this.error = "Invalid email or password."
                else this.error = "Oops, something went wrong. Try again."
                this.loading = false;
            }
        }
    }

</script>

<style scoped>
    @media (max-width: 760px) {
        .loginForm {
            margin: 0 !important;
        }
    }
</style>