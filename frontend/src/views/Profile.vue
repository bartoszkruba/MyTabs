<template>
    <v-container class="darkText">
        <v-row>
            <v-col><h1 class="text-center">Profile</h1></v-col>
        </v-row>
        <v-row>
            <v-col>
                <hr>
            </v-col>
        </v-row>
        <v-row>
            <v-col><h3 class="text-center">This is profile page.</h3></v-col>
        </v-row>
    </v-container>
</template>

<script lang="ts">
    import Vue from 'vue';
    import Component from 'vue-class-component'

    @Component({components: {}, name: "Profile"})
    export default class Profile extends Vue {

    }
</script>
