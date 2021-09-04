<template>
  <div class="postview">         
    <postdetails />
    <div class="card-body">
        <p style="text-align: left;">{{post.content}}</p>  
    </div>
  </div>
</template>

<script>
import PostDetails from "../../components/PostDetails.vue";
import bloggingService from '../..'

export default {
  components: {
    postdetails: PostDetails,
  },
    data() {
    return {
      post: {
        postId: this.$route.params.postid,
        title: "",
        content: "",
        blog: {},
        blogger: {},
      }
    };
  },
  created() {
    if ("postid" in this.$route.params) {
      bloggingService.getPostById(this.$route.params.postid).then( result => this.post = result ).catch( error => console.log(error) );
    }
  },
};
</script>
