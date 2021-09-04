<template>
  <div class="blog-details">
    <h1>{{ blog.url }} </h1>
        <samp v-if="blogPostsCount>0">
            {{ blogPostsCount }} Post<samp v-show="blogPostsCount > 1">s</samp>
            by {{ blogAuthorsCount }} Blogger<samp v-show="blogAuthorsCount > 1">s</samp>
        </samp>
        <samp v-else>has no posts yet</samp>
  </div>
</template>

<script>
import bloggingService from '..'

export default {
  name: 'BlogDetails',
  data() {
    return {
      blog: {
        blogId: this.$route.params.blogid,
        url: "",
      },
      blogPostsCount: 0,
      blogAuthorsCount: 0,
    };
  },
  created() {
    if ("blogid" in this.$route.params) {
      bloggingService.getBlogById(this.$route.params.blogid).then( result => this.blog = result ).catch( error => console.log(error) );
      bloggingService.getBlogPostsCount(this.$route.params.blogid).then( result => this.blogPostsCount = result ).catch( error => console.log(error) );
      bloggingService.getBlogAuthorsCount(this.$route.params.blogid).then( result => this.blogAuthorsCount = result ).catch( error => console.log(error) );
    }
  },
};
</script>
