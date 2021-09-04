<template>
  <div class="Posts">
    <h1>Posts ({{posts.length}})</h1>        
    <form>
    <div class="form-switch">
      <input class="form-check-input" type="checkbox" id="flexSwitchCheckDefault" v-model="layout" >
      <label class="form-check-label" for="flexSwitchCheckDefault">Cards/List</label>
    </div>
    </form>
    <div v-if="layout">
      <postscards :posts="posts" />
    </div>
    <div v-else>
      <postslist :posts="posts" />
    </div>
  </div>
</template>

<script>
import postslist from "../../components/PostsList.vue"
import postscards from "../../components/PostsCards.vue"
import bloggingService from '../..'

export default {
  data() {
    return {
      posts: [],
      layout : true,
    };
  },
  created() {
      bloggingService.getPosts().then( result => this.posts = result ).catch((error) => console.log(error));  
  },
  components :{
      postslist,
      postscards
  },
};
</script>
