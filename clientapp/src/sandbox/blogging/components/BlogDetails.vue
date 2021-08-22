<template>
  <div class="blog-details">
    <h4>Blog {{ blog.url }}  
        <samp v-if="blogPostsCount>0">
            has <a href=#>{{ blogPostsCount }} Post<samp v-show="blogPostsCount > 1">s</samp></a> 
            by <a href=#>{{ blogAuthorsCount }} Blogger<samp v-show="blogAuthorsCount > 1">s</samp></a>
        </samp>
        <samp v-else>has no posts</samp>
    </h4>
  </div>
</template>

<script>
import bloggingService from '..'

export default {
  name: 'BlogDetails',
  data() {
    return {
      blog: {
        blogId: this.$route.params.id,
        url: "",
      },
      blogPostsCount: 0,
      blogAuthorsCount: 0,
    };
  },
  created() {
    if ("id" in this.$route.params) {
      bloggingService.getBlogById(this.$route.params.id).then( result => this.blog = result ).catch( error => console.log(error) );
      bloggingService.getBlogPostsCount(this.$route.params.id).then( result => this.blogPostsCount = result ).catch( error => console.log(error) );
      bloggingService.getBlogAuthorsCount(this.$route.params.id).then( result => this.blogAuthorsCount = result ).catch( error => console.log(error) );
    }
  },
};
</script>
