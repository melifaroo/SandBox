<template>
  <div class="post-details">
    <h1> <a v-bind:href="'/blogs/posts/' + post.postId">{{ post.title }}</a> </h1>
            <p><sub>
              by <a v-bind:href="'/blogs/bloggers/' + post.blogger.bloggerId">{{post.blogger.nickName}}</a>
              in <a v-bind:href="'/blogs/' + post.blog.blogId">{{post.blog.url}}</a>
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
        postId: this.$route.params.id,
        title: "",
        content: "",
        blog: {},
        blogger: {},
      }
    };
  },
  created() {
    if ("id" in this.$route.params) {
      bloggingService.getPostById(this.$route.params.id).then( result => this.post = result ).catch( error => console.log(error) );
    }
  },
};
</script>
