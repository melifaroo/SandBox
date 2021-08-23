<template>
  <div class="post-details">
    <h1>{{ post.title }} </h1>
            <p><sub>
              in {{post.blog.url}}
              by {{post.blogger.nickname}}
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
