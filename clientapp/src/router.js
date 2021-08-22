import { createWebHistory, createRouter } from "vue-router";
import Home from "@/views/Home.vue";
import About from "@/views/About.vue";
import PersonForm from "@/sandbox/blogging/views/bloggers/BloggerForm.vue";

const routes = [
    {
        path: "/",
        name: "Home",
        component: Home,
    },
    {
        path: "/about",
        name: "About",
        component: About,
    },


    {
        path: "/sandbox/blogging/bloggers",
        name: "Bloggers",
        component: () => import('@/sandbox/blogging/views/bloggers/Bloggers.vue')
    },
    {
        path: "/sandbox/blogging/posts",
        name: "Posts",
        component: () => import('@/sandbox/blogging/views/posts/Posts.vue')
    },
    {
        path: "/sandbox/blogging/addblogger",
        name: "BloggerCreateForm",
        component: PersonForm
    },
    {
        path: "/sandbox/blogging/editblogger/:id",
        name: "BloggerEditForm",
        component: PersonForm
    },
    {
        path: "/sandbox/blogging/deleteblogger/:id",
        name: "BloggerDelete",
        component: () => import('@/sandbox/blogging/views/bloggers/BloggerDelete.vue')
    },
    {
        path: "/sandbox/blogging/bloggers/:id",
        name: "Blogger",
        component: () => import('@/sandbox/blogging/views/bloggers/Blogger.vue')
    },
    {
        path: "/sandbox/blogging/blogs/:id",
        name: "Blog",
        component: () => import('@/sandbox/blogging/views/blogs/Blog.vue')
    },
    {
        path: "/sandbox/blogging/blogs",
        name: "Blogs",
        component: () => import('@/sandbox/blogging/views/blogs/Blogs.vue')
    },
    {
        path: "/sandbox/blogging/DBSeed",
        name: "DBSeed",
        component: () => import('@/sandbox/blogging/views/dbseed.vue')
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;