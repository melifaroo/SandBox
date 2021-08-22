<template>
  <div class="bloggers">
    <h1>Bloggers</h1>   
    <h2>count = {{bloggers.length}}</h2>  
    <a class="btn btn-success" href="/sandbox/blogging/addblogger">Add blogger</a>     
    <h2>by scrolling table</h2>   
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
