<template>
  <div class="Vlogs">
    <h1>Blogs ({{blogs.length}})</h1>
    <a class="btn btn-success" href="/sandbox/blogging/addblog">Create new blog</a>     
    <form>
    <div class="form-switch">
      <input class="form-check-input" type="checkbox" id="flexSwitchCheckDefault" v-model="layout" >
      <label class="form-check-label" for="flexSwitchCheckDefault">Cards/List</label>
    </div>
    </form>
    <!--a class="btn btn-link" :click="viewlayout = 'cards'" href=#>Cards</a> | <a class="btn btn-link" :click="viewlayout = 'list'" href=#>List</a--> 
    <div v-if="layout">
      <blogscards :blogs="blogs" />
    </div>
    <div v-else>
      <blogslist :blogs="blogs" />
    </div>
  </div>
</template>


<script>
import blogslist from "../../components/BlogsList.vue"
import blogscards from "../../components/BlogsCards.vue"
import bloggingService from '../..'

export default {
  data() {
    return {
      blogs: [],
      layout : true,
    };
  },
  async beforeCreate() {
      await bloggingService.getBlogs().then(result => this.blogs = result).catch((error) => console.log(error)); 
  },
  components :{
     blogslist,
     blogscards
  },
};
</script>
