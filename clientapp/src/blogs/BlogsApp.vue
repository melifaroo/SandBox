<template>
  <blogsnavbar></blogsnavbar>
  <router-view />
</template>

<script>
import BlogsNavbar from "@/blogs/components/BlogsNavbar";

export default {
  name: "BlogsApp",
  components: {
    blogsnavbar : BlogsNavbar,
  },
};
</script>