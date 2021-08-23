import { createWebHistory, createRouter } from "vue-router";
import Home from "@/views/Home.vue";
import About from "@/views/About.vue";
import PersonForm from "@/sandbox/blogging/views/bloggers/BloggerForm.vue";
import BlogForm from "@/sandbox/blogging/views/blogs/BlogForm.vue";

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
        path: "/sandbox/blogging/addposttoblog/:id",
        name: "PostToBlogForm",
        component:  () => import('@/sandbox/blogging/views/posts/PostToBlogForm.vue')
    },
    {
        path: "/sandbox/blogging/addpostbyblogger/:id",
        name: "PostByBloggerForm",
        component:  () => import('@/sandbox/blogging/views/posts/PostByBloggerForm.vue')
    },
    {
        path: "/sandbox/blogging/editpost/:id",
        name: "PostContentForm",
        component:  () => import('@/sandbox/blogging/views/posts/PostContentForm.vue')
    },
    {
        path: "/sandbox/blogging/deletepost/:id",
        name: "PostDelete",
        component: () => import('@/sandbox/blogging/views/posts/PostDelete.vue')
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
        component: () => import('@/sandbox/blogging/views/bloggers/Blogger.vue'),
        children: [
            {
              // A will be rendered in the second <router-view>
              // when /your-sidebar-url/a is matched
              path: '/sandbox/blogging/bloggers/:id/blogs',
              name: "BloggerBlogs",
              component: () => import('@/sandbox/blogging/views/bloggers/BloggerBlogs.vue'),
            },
            {
              // A will be rendered in the second <router-view>
              // when /your-sidebar-url/a is matched
              path: '/sandbox/blogging/bloggers/:id/posts',
              name: "BloggerPosts",
              component: () => import('@/sandbox/blogging/views/bloggers/BloggerPosts.vue'),
            },
        ]
    },
    {
        path: "/sandbox/blogging/addblog",
        name: "BlogCreateForm",
        component: BlogForm
    },
    {
        path: "/sandbox/blogging/editblog/:id",
        name: "BlogEditForm",
        component: BlogForm
    },
    {
        path: "/sandbox/blogging/deleteblog/:id",
        name: "BlogDelete",
        component: () => import('@/sandbox/blogging/views/blogs/BlogDelete.vue')
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