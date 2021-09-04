<template>
  <div class="bloggers">
    <h1>Bloggers ({{bloggers.length}})</h1>   
    <router-link class="btn btn-success" to="/blogs/bloggers/create">Add new blogger</router-link>        
    <bloggerslist :bloggers="bloggers" />
  </div>
</template>

<script>
import bloggerslist from "../../components/BloggersList.vue"
import bloggingService from '../..'

export default {
  data() {
    return {
      bloggers: [],
    };
  },
  created() {
    bloggingService.getBloggers().then( result => this.bloggers = result ).catch( error => console.log(error) );     
  },
  components :{
      bloggerslist  
  }
};
</script>
