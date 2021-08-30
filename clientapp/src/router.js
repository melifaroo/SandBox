import { createWebHistory, createRouter } from "vue-router";
import Home from "@/views/Home.vue";
import About from "@/views/About.vue";
import PersonForm from "@/blogs/views/bloggers/BloggerForm.vue";
import BlogForm from "@/blogs/views/BlogForm.vue";

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
        path: "/blogs",
        name: "BlogsMain",
        component: () => import('@/blogs/BlogsApp.vue'),
        children: [
            {
                path: "/blogs",
                name: "Blogs",
                component: () => import('@/blogs/views/Blogs.vue')
            },
            {
                path: "/blogs/create",
                name: "BlogCreateForm",
                component: BlogForm
            },
            {
                path: "/blogs/edit/:id",
                name: "BlogEditForm",
                component: BlogForm
            },
            {
                path: "/blogs/delete/:id",
                name: "BlogDelete",
                component: () => import('@/blogs/views/BlogDelete.vue')
            },
            {
                path: "/blogs/:id",
                name: "Blog",
                component: () => import('@/blogs/views/Blog.vue')
            },
            {
                path: "/blogs/:id/createpost",
                name: "PostToBlogForm",
                component:  () => import('@/blogs/views/BlogPostForm.vue')
            },

            {
                path: "/blogs/posts",
                name: "Posts",
                component: () => import('@/blogs/views/posts/Posts.vue')
            },
            {
                path: "/blogs/posts/:id",
                name: "Post",
                component: () => import('@/blogs/views/posts/Post.vue')
            },
            {
                path: "/blogs/posts/edit/:id",
                name: "PostContentForm",
                component:  () => import('@/blogs/views/posts/PostContentForm.vue')
            },
            {
                path: "/blogs/posts/delete/:id",
                name: "PostDelete",
                component: () => import('@/blogs/views/posts/PostDelete.vue')
            },
            
            {
                path: "/blogs/bloggers",
                name: "Bloggers",
                component: () => import('@/blogs/views/bloggers/Bloggers.vue')
            },
            {
                path: "/blogs/bloggers/create",
                name: "BloggerCreateForm",
                component: PersonForm
            },
            {
                path: "/blogs/bloggers/edit/:id",
                name: "BloggerEditForm",
                component: PersonForm
            },
            {
                path: "/blogs/bloggers/delete/:id",
                name: "BloggerDelete",
                component: () => import('@/blogs/views/bloggers/BloggerDelete.vue')
            },
            {
                path: "/blogs/bloggers/:id",
                name: "Blogger",
                component: () => import('@/blogs/views/bloggers/Blogger.vue'),
                children: [
                    {
                    path: '/blogs/bloggers/:id/blogs',
                    name: "BloggerBlogs",
                    component: () => import('@/blogs/views/bloggers/BloggerBlogs.vue'),
                    },
                    {
                    path: '/blogs/bloggers/:id/posts',
                    name: "BloggerPosts",
                    component: () => import('@/blogs/views/bloggers/BloggerPosts.vue'),
                    },
                ]
            },
            {
                path: "/blogs/bloggers/:id/createpost",
                name: "PostByBloggerForm",
                component:  () => import('@/blogs/views/bloggers/BloggerPostForm.vue')
            },
    
        ]   
    },
    {
        path: "/dbseed",
        name: "DBSeed",
        component: () => import('@/views/DbSeed.vue')
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;