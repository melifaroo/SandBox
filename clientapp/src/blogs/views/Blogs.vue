<template>
  <div class="Blogs">
    <h1>Blogs ({{blogs.length}})</h1>
    <router-link class="btn btn-success" :to="'/blogs/create'">Create new blog</router-link>     
    <form>
    <div class="form-switch">
      <input class="form-check-input" type="checkbox" id="flexSwitchCheckDefault" v-model="layout" >
      <label class="form-check-label" for="flexSwitchCheckDefault">Cards/List</label>
    </div>
    </form>
    <div v-if="layout">
      <blogscards :blogs="blogs" />
    </div>
    <div v-else>
      <blogslist :blogs="blogs" />
    </div>
  </div>
</template>


<script>
import blogslist from "../components/BlogsList.vue"
import blogscards from "../components/BlogsCards.vue"
import bloggingService from '..'

export default {
  data() {
    return {
      blogs: [],
      layout : true,
    };
  },
  created() {
      bloggingService.getBlogs().then(result => this.blogs = result).catch((error) => console.log(error)); 
  },
  components :{
     blogslist,
     blogscards
  },
};
</script>
