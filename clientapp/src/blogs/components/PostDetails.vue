<template>
  <div class="post-details">
    <h1> <router-link :to="'/blogs/posts/' + post.postId">{{ post.title }}</router-link> </h1>            
            <p><sub>
              by <router-link :to="'/blogs/bloggers/' + post.blogger.bloggerId">{{post.blogger.nickName}}</router-link>
              in <router-link :to="'/blogs/' + post.blog.blogId">{{post.blog.url}}</router-link>
            </sub></p>
  </div>
</template>

<script>
import bloggingService from '..'

export default {
  name: 'PostDetails',
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
