<template>
    <v-app>
        <v-app-bar app color="primary" dark class="navbar">
            <div class="d-flex align-center">
                <router-link to="/">
                    <v-img alt="Vuetify Logo" class="shrink mr-2" contain
                           src="https://cdn.vuetifyjs.com/images/logos/vuetify-logo-dark.png"
                           transition="scale-transition"
                           width="40"/>
                </router-link>

                <router-link to="/" class="appName">
                    <h1 class="ml-2" style="color: white">MyTabs</h1>
                </router-link>
            </div>

            <v-spacer></v-spacer>

            <router-link to="/create">
                <v-btn text>
                    <span class="mr-2">Create</span>
                    <v-icon>mdi-folder-plus</v-icon>
                </v-btn>
            </router-link>
            <router-link to="/notifications">
                <v-btn text>
                    <span class="mr-2">Notifications</span>
                    <v-icon>mdi-bell</v-icon>
                </v-btn>
            </router-link>
            <router-link to="/register">
                <v-btn text>
                    <span class="mr-2">Register</span>
                    <v-icon>mdi-account-plus</v-icon>
                </v-btn>
            </router-link>
            <router-link to="/login">
                <v-btn text>
                    <span class="mr-2">Login</span>
                    <v-icon>mdi-login-variant</v-icon>
                </v-btn>
            </router-link>
            <router-link to="/about">
                <v-btn text>
                    <span class="mr-2">About</span>
                    <v-icon>mdi-information-outline</v-icon>
                </v-btn>
            </router-link>
        </v-app-bar>
        <v-content class="websiteContent">
            <router-view/>
        </v-content>
    </v-app>
</template>

<script lang="ts">
    import Vue from 'vue';
    import Component from 'vue-class-component'

    @Component({components: {}, name: "App"})
    export default class App extends Vue {
    }

</script>

<style scoped>
    .websiteContent{
        margin-top: 50px;
    }

    @media (max-width: 900px) {
        .appName {
            display: none;
        }
    }
    @media (max-width: 760px) {
        .appName {
            display: none;
        }

        .navbar {
            display: none;
        }
        .websiteContent{
            margin-top: -25px;
        }
    }
</style>
