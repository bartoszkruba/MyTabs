import Vue from 'vue'
import VueRouter, {RouteConfig} from 'vue-router'
import Home from '../views/Home.vue'
import About from '../views/About.vue'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
    {
        path: '/',
        name: 'Home',
        component: Home,
        meta: {title: "Home"}
    },
    {
        path: '/about',
        name: 'About',
        component: About,
        meta: {title: "About"}
    }
]

const router = new VueRouter({routes, mode: "history"})
router.beforeEach((to, from, next) => {
    document.title = to.meta.title
    next()
})

export default router
