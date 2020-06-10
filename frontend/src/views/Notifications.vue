<template>
    <v-container>
        <v-row>
            <v-col><h1 class="text-center">Notifications</h1></v-col>
        </v-row>
        <v-row>
            <v-col>
                <hr>
            </v-col>
        </v-row>
        <v-row>
            <v-col><h3 class="text-center">This is notifications site.</h3></v-col>
        </v-row>
    </v-container>
</template>

<script lang="ts">
    import Vue from "vue"
    import Component from "vue-class-component"

    @Component({components: {}, name: "Notifications"})
    export default class Notifications extends Vue {

    }

</script>
