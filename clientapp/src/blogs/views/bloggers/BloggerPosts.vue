<template>
  <div class="bloggerposts">
    <postscards :posts="posts" />
  </div>
</template>

<script>
import postscards from "../../components/PostsCards.vue"
import bloggingService from '../..'

export default {
  data() {
    return {
      bloggerId: this.$route.params.bloggerid,
      posts: []
    };
  },
  created() {
    bloggingService.getBloggerPosts(this.$route.params.bloggerid).then(result => {
                for(var i in result)
                   this.posts.push(result[i]);
         }).catch((error) => console.log(error));
  },
  components :{
     postscards
  },
};
</script>