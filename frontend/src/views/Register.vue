<template>
    <v-form class="darkText mt-5 registerForm" ref="form">
        <LoadingPopup/>
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
    import Vue from 'vue';
    import Component from 'vue-class-component'
    import LoadingPopup from '@/components/LoadingPopup.vue';
    import {Prop, Watch} from 'vue-property-decorator'
    import {createNewUser} from "@/util/api";

    @Component({components: {LoadingPopup}, name: "Register"})
    export default class Register extends Vue {
        @Prop()
        private username = 'john69'

        private usernameRules = [
            v => !!v || "Field is required",
            v => (!!v && v.length >= 4 && v.length <= 20) || 'Username must be between 4 and 20 characters longs',
            v => (!!v && !v.includes(" ")) || "No spaces allowed"
        ]
        @Prop()
        public email = 'john.doe@email.com'
        private emailRules = [
            v => !!v || "Field is required",
            v => /.+@.+\..+/.test(v) || "Invalid email",
        ]
        @Prop()
        public password = 'password1234'
        private passwordRules = [
            v => !!v || "Field is required",
            v => (!!v && !v.includes(" ")) || "No spaces allowed"
        ]
        @Prop()
        public repeatPassword = 'password1234'
        private repeatPasswordRules = [
            v => !!v || "Field is required",
            v => (!!v && !v.includes(" ")) || "No spaces allowed",
            v => (v == this.password) || "Passwords do not matches"
        ]

        @Prop()
        private error = "";

        get valid() {
            for (const rule of this.usernameRules) if (rule(this.username) != true) return false;
            for (const rule of this.emailRules) if (rule(this.email) != true) return false;
            for (const rule of this.passwordRules) if (rule(this.password) != true) return false;
            for (const rule of this.repeatPasswordRules) if (rule(this.repeatPassword) != true) return false;
            return true;
        }

        private register = async () => {
            try {
                const response = await createNewUser(this.username, this.email, this.password);
            } catch (e) {
                this.error = "Could not register account.";
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