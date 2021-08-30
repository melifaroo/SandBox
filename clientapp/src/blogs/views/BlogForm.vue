<template>
  <div class="blogForm">
    <h1>Blog details</h1>
    <div class="container">
      <form @submit.prevent="createOrUpdateBlog">
        <div class="form-group" style="margin-bottom: 10px">
          <input type="text" class="form-control"  id="url"  v-model="Blog.url" placeholder="Enter blog title" />
        </div>
        <ul>
          <a class="btn btn-secondary" href="/blogs">All blogs</a>
          <button type="submit" class="btn btn-info">Save</button>
        </ul>
      </form>
    </div>
  </div>
</template>

<script>
import bloggingService from '..'

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
  created (){
    if ("id" in this.$route.params) {
      bloggingService.getBlogById(this.$route.params.id).then( result => this.Blog = result ).catch( error => console.log(error) );
    }    
  },
  methods: {   
    async createOrUpdateBlog() {
      await bloggingService.createOrUpdateBlog(this.Blog).then( this.$router.push("/blogs") ).catch( error => console.log(error) );
    }
  },
};
</script>
  