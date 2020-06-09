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

            <router-link to="/search">
                <v-btn text>
                    <span class="mr-2">Search</span>
                    <v-icon>mdi-magnify</v-icon>
                </v-btn>
            </router-link>
            <router-link v-if="loggedIn" to="/create">
                <v-btn text>
                    <span class="mr-2">Create</span>
                    <v-icon>mdi-folder-plus</v-icon>
                </v-btn>
            </router-link>
            <router-link v-if="loggedIn" to="/notifications">
                <v-btn text>
                    <span class="mr-2">Notifications</span>
                    <v-icon>mdi-bell</v-icon>
                </v-btn>
            </router-link>
            <router-link v-if="loggedIn" to="/profile">
                <v-btn text>
                    <span class="mr-2">Profile</span>
                    <v-icon>mdi-account</v-icon>
                </v-btn>
            </router-link>
            <router-link v-if="!loggedIn" to="/register">
                <v-btn text>
                    <span class="mr-2">Register</span>
                    <v-icon>mdi-account-plus</v-icon>
                </v-btn>
            </router-link>
            <router-link v-if="!loggedIn" to="/login">
                <v-btn text>
                    <span class="mr-2">Login</span>
                    <v-icon>mdi-login-variant</v-icon>
                </v-btn>
            </router-link>
        </v-app-bar>
        <v-content class="websiteContent">
            <router-view/>
        </v-content>
        <v-bottom-navigation class="bottomNav">
            <router-link to="/search" class="bottomNavigationLink">
                <v-btn value="Search">
                    <span>Search</span>
                    <v-icon>mdi-magnify</v-icon>
                </v-btn>
            </router-link>
            <router-link v-if="loggedIn" to="/create" class="bottomNavigationLink">
                <v-btn value="Create">
                    <span>Create</span>
                    <v-icon>mdi-folder-plus</v-icon>
                </v-btn>
            </router-link>
            <router-link v-if="loggedIn" to="/notifications" class="bottomNavigationLink">
                <v-btn value="Notifications">
                    <span>Notifications</span>
                    <v-icon>mdi-bell</v-icon>
                </v-btn>
            </router-link>
            <router-link v-if="loggedIn" to="/profile" class="bottomNavigationLink">
                <v-btn value="Profile">
                    <span>Profile</span>
                    <v-icon>mdi-account</v-icon>
                </v-btn>
            </router-link>
            <router-link v-if="!loggedIn" to="/register" class="bottomNavigationLink">
                <v-btn value="Register">
                    <span>Register</span>
                    <v-icon>mdi-account-plus</v-icon>
                </v-btn>
            </router-link>
            <router-link v-if="!loggedIn" to="/login" class="bottomNavigationLink">
                <v-btn value="Login">
                    <span>Login</span>
                    <v-icon>mdi-login-variant</v-icon>
                </v-btn>
            </router-link>
        </v-bottom-navigation>
    </v-app>
</template>

<script lang="ts">
    import Vue from 'vue';
    import Component from 'vue-class-component'

    @Component({components: {}, name: "App"})
    export default class App extends Vue {
        private loggedIn = true;
    }

</script>

<style scoped>
    .websiteContent {
        margin-top: 50px;
    }

    .bottomNavigationLink {
        height: 100%;
        text-decoration: none;
    }

    .bottomNav {
        display: none !important;
    }

    @media (max-width: 760px) {
        .appName {
            display: none;
        }

        .navbar {
            display: none;
        }

        .bottomNav {
            display: flex !important;
        }

        .websiteContent {
            margin-top: -25px;
        }
    }
</style>
