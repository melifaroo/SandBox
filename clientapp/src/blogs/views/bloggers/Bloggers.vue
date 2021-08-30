<template>
  <div class="bloggers">
    <h1>Bloggers ({{bloggers.length}})</h1>   
    <a class="btn btn-success" href="/sandbox/blogging/addblogger">Add blogger</a>        
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
  async beforeCreate() {
    await bloggingService.getBloggers().then( result => this.bloggers = result ).catch( error => console.log(error) );     
  },
  components :{
      bloggerslist  
  }
};
</script>
