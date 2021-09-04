import { createWebHistory, createRouter } from "vue-router";
import Home from "@/views/Home.vue";
import About from "@/views/About.vue";
import BloggerForm from "@/blogs/views/bloggers/BloggerForm.vue";
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
                path: "",
                name: "Blogs",
                component: () => import('@/blogs/views/Blogs.vue')
            },
            {
                path: "create",
                name: "BlogCreateForm",
                component: BlogForm
            },
            {
                path: "edit/:blogid",
                name: "BlogEditForm",
                component: BlogForm
            },
            {
                path: "delete/:blogid",
                name: "BlogDelete",
                component: () => import('@/blogs/views/BlogDelete.vue')
            },
            {
                path: ":blogid",
                name: "Blog",
                component: () => import('@/blogs/views/Blog.vue')
            },
            {
                path: ":blogid/createpost",
                name: "PostToBlogForm",
                component:  () => import('@/blogs/views/BlogPostForm.vue')
            },
            {
                path: "posts",
                name: "Posts",
                component: () => import('@/blogs/views/posts/Posts.vue')
            },
            {
                path: "posts/:postid",
                name: "Post",
                component: () => import('@/blogs/views/posts/Post.vue')
            },
            {
                path: "posts/edit/:postid",
                name: "PostContentForm",
                component:  () => import('@/blogs/views/posts/PostContentForm.vue')
            },
            {
                path: "posts/delete/:postid",
                name: "PostDelete",
                component: () => import('@/blogs/views/posts/PostDelete.vue')
            },            
            {
                path: "bloggers",
                name: "Bloggers",
                component: () => import('@/blogs/views/bloggers/Bloggers.vue')
            },
            {
                path: "bloggers/create",
                name: "BloggerCreateForm",
                component: BloggerForm
            },
            {
                path: "bloggers/edit/:bloggerid",
                name: "BloggerEditForm",
                component: BloggerForm
            },
            {
                path: "bloggers/delete/:bloggerid",
                name: "BloggerDelete",
                component: () => import('@/blogs/views/bloggers/BloggerDelete.vue')
            },
            {
                path: "bloggers/:bloggerid",
                name: "Blogger",
                component: () => import('@/blogs/views/bloggers/Blogger.vue'),
                children: [
                    {
                        path: 'blogs',
                        name: "BloggerBlogs",
                        component: () => import('@/blogs/views/bloggers/BloggerBlogs.vue'),
                    },
                    {
                        path: 'posts',
                        name: "BloggerPosts",
                        component: () => import('@/blogs/views/bloggers/BloggerPosts.vue'),
                    },
                    {
                        path: "createpost",
                        name: "PostFromBloggerForm",
                        component:  () => import('@/blogs/views/bloggers/BloggerPostForm.vue')
                    },
                ]
            },
            {
                path: "/blogs/bloggers/:bloggerid/createpost",
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
    previous: "",
    routes,
});

router.beforeEach((to, from, next) => {
    router.previous = from.fullPath;
    console.log("beforeEach:" + from.fullPath);
    next();
  })


export default router;