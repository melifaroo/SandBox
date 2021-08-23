<template>
  <div class="blog">
    <blogdetails />
  </div> 
  <a class="btn btn-success" href="/sandbox/blogging/addpost">Create new post</a>    
  <div class="blog-posts">      
    <postscards :posts="posts" />
    <!--a class="btn btn-success" href="/addpost">Write new post</a-->
  </div>
</template>

<script>
import postscards from "../../components/PostsCards.vue"
import blogdetails from "../../components/BlogDetails.vue"
import bloggingService from '../..'

export default {
  data() {
    return {
      posts: [],
    };
  },
  async beforeCreate() {
      await bloggingService.getBlogPosts(this.$route.params.id).then(  result => this.posts = result  ).catch((error) => console.log(error));     
  },
  components :{
      postscards,
      blogdetails
  },
};
</script>
