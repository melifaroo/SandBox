<template>
  <div class="bloggerblogs">
    <blogscards :blogs="blogs" />
  </div>
</template>

<script>
import blogscards from "../../components/BlogsCards.vue"
import bloggingService from '../..'

export default {
  data() {
    return {
      bloggerId: this.$route.params.bloggerid,
      blogs: [],
    };
  },
  created() {
      bloggingService.getBloggerBlogs(this.$route.params.bloggerid).then(result => this.blogs = result).catch((error) => console.log(error));
  },
  components :{
     blogscards
  },
};
</script>