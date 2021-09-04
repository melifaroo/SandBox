<template>
  <div class="blogger-details">
    <h4>Blogger {{ Blogger.nickName }}  
        <samp v-if="bloggerPostsCount>0">
            has <router-link :to="'/blogs/bloggers/'+this.$route.params.bloggerid+'/posts/'">{{ bloggerPostsCount }} Post<samp v-show="bloggerPostsCount > 1">s</samp></router-link> 
            in <router-link :to="'/blogs/bloggers/'+this.$route.params.bloggerid+'/blogs/'">{{ bloggerBlogsCount }} Blog<samp v-show="bloggerBlogsCount > 1">s</samp></router-link>
        </samp>
        <samp v-else>has no posts</samp>
    </h4>    
  </div>
</template>

<script>
import bloggingService from '..'

export default {
  name: 'BloggerDetails',
  data() {
    return {
      Blogger: {
        bloggerId: this.$route.params.bloggerid,
        nickName: "",
      },
      bloggerPostsCount: 0,
      bloggerBlogsCount: 0,
    };
  },
  created() {
    if ("bloggerid" in this.$route.params) {
      bloggingService.getBloggerById(this.$route.params.bloggerid).then( result => this.Blogger = result ).catch( error => console.log(error) );
      bloggingService.getBloggerPostsCount(this.$route.params.bloggerid).then( result => this.bloggerPostsCount = result ).catch( error => console.log(error) );
      bloggingService.getBloggerBlogsCount(this.$route.params.bloggerid).then( result => this.bloggerBlogsCount = result ).catch( error => console.log(error) );
    }
  },
};
</script>
