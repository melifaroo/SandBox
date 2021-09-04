<template>
  <div class="blog">
    <blogdetails />
  </div> 
  <router-link class="btn btn-success" :to="'/blogs/'+this.$route.params.blogid+'/createpost'">Create new post</router-link>    
  <div class="blog-posts">      
    <postscards :posts="posts"/>
  </div>
</template>

<script>
import postscards from "../components/PostsCards.vue"
import blogdetails from "../components/BlogDetails.vue"
import bloggingService from '..'

export default {
  data() {
    return {
        posts: []
    }
  },
  created(){
    bloggingService.getBlogPosts(this.$route.params.blogid).then( result => this.posts = result ).catch((error) => console.log(error));  
  },  
  components :{
      postscards,
      blogdetails
  },
};
</script>
