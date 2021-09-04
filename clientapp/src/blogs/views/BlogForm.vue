<template>
  <div class="blogForm">
    <h1>Blog details</h1>
    <div class="container">
      <form @submit.prevent="createOrUpdateBlog">
        <div class="input-group">
          <div class="input-group-prepend">
            <span class="input-group-text">Blog Title</span>
          </div>
          <input type="text" class="form-control" id="url" v-model="Blog.url" placeholder="Enter blog title" />
        </div>
        <ul>
          <a class="btn btn-secondary" @click="this.$router.go(-1)">All blogs</a>
          <button type="submit" class="btn btn-info">Save</button>
        </ul>
      </form>
    </div>
  </div>
</template>

<script>
import bloggingService from "..";

export default {
  name: "BlogForm",
  data() {
    return {
      Blog: {
        blogId: undefined,
        url: "",
      },
    };
  },
  created() {
    if ("blogid" in this.$route.params) {
      bloggingService.getBlogById(this.$route.params.blogid).then((result) => (this.Blog = result)).catch((error) => console.log(error));
    }
  },
  methods: {
    async createOrUpdateBlog() {
      await bloggingService.createOrUpdateBlog(this.Blog).catch((error) => console.log(error));
      this.$router.go(-1);
    },
  },
};
</script>
  