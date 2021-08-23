<template>
  <div class="blogger-details">
    <h4>Blogger {{ Blogger.nickName }}  
        <samp v-if="bloggerPostsCount>0">
            has <a :href="'/sandbox/blogging/bloggers/'+this.$route.params.id+'/posts/'">{{ bloggerPostsCount }} Post<samp v-show="bloggerPostsCount > 1">s</samp></a> 
            in <a :href="'/sandbox/blogging/bloggers/'+this.$route.params.id+'/blogs/'">{{ bloggerBlogsCount }} Blog<samp v-show="bloggerBlogsCount > 1">s</samp></a>
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
        bloggerId: this.$route.params.id,
        nickName: "",
      },
      bloggerPostsCount: 0,
      bloggerBlogsCount: 0,
    };
  },
  created() {
    if ("id" in this.$route.params) {
      bloggingService.getBloggerById(this.$route.params.id).then( result => this.Blogger = result ).catch( error => console.log(error) );
      bloggingService.getBloggerPostsCount(this.$route.params.id).then( result => this.bloggerPostsCount = result ).catch( error => console.log(error) );
      bloggingService.getBloggerBlogsCount(this.$route.params.id).then( result => this.bloggerBlogsCount = result ).catch( error => console.log(error) );
    }
  },
};
</script>
