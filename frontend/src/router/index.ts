import Vue from 'vue'
import VueRouter, {RouteConfig} from 'vue-router'
import {APP_NAME} from "@/util/constants"
import Search from '@/views/Search.vue'
import Create from '@/views/Create.vue'
import Notifications from "@/views/Notifications.vue"
import Profile from '@/views/Profile.vue'
import Register from '@/views/Register.vue'
import Login from '@/views/Login.vue'
import PageNotFound from '@/views/PageNotFound.vue'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
    {
        path: '/',
        name: 'Search',
        component: Search,
        meta: {title: `${APP_NAME} | Search`}
    },
    {
        path: '/create',
        name: 'Create',
        component: Create,
        meta: {title: `${APP_NAME} | Create`}
    },
    {
        path: "/notifications",
        name: "Notifications",
        component: Notifications,
        meta: {title: `${APP_NAME} | Notifications`}
    },
    {
        path: "/profile",
        name: "Profile",
        component: Profile,
        meta: {title: `${APP_NAME} | Profile`}
    },
    {
        path: "/register",
        name: "Register",
        component: Register,
        meta: {title: `${APP_NAME} | Register`}
    },
    {
        path: "/login",
        name: "Login",
        component: Login,
        meta: {title: `${APP_NAME} | Login`}
    },
    {
        path: "*",
        name: "Page Not Found",
        component: PageNotFound,
        meta: {title: `${APP_NAME} | Page Not Found`}
    }
]

const router = new VueRouter({routes, mode: "history"})
router.beforeEach((to, from, next) => {
    document.title = to.meta.title
    next()
})

export default router
