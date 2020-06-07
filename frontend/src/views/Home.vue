<template>
    <div class="home">
        <h1 class="text-center">Home</h1>
        <h2 class="text-center">{{msg}}</h2>
    </div>
</template>

<script lang="ts">
    import Vue from "vue";
    import Component from "vue-class-component"
    import {Prop} from 'vue-property-decorator'

    @Component({components: {}, name: "Home"})
    export default class Home extends Vue {

        @Prop({default: "No Message"})
        private msg!: string
    }
</script>
