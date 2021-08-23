<template>
  <div class="bloggerForm">
    <h1>input or edit blogger details </h1>
    <div class="container">
      <form @submit.prevent="createOrUpdateBlogger">
        <div class="form-group" style="margin-bottom: 10px">
          <input type="text" class="form-control"  id="NickName"  v-model="Blogger.nickName" placeholder="Enter NickName" />
        </div>
        <ul>
          <a class="btn btn-secondary" v-bind:href="'/sandbox/blogging/bloggers'">All bloggers</a>
          <button type="submit" class="btn btn-info">Save</button>
        </ul>
      </form>
    </div>
  </div>
</template>

<script>
import bloggingService from '../..'

export default {
  name: "BloggerForm",
  data() {
    return {
      Blogger: {
        bloggerId: undefined,
        nickName: "",
      },
    };
  },
  created (){
    if ("id" in this.$route.params) {
      bloggingService.getBloggerById(this.$route.params.id).then( result => this.Blogger = result ).catch( error => console.log(error) );
    }    
  },
  methods: {   
    async createOrUpdateBlogger() {
      await bloggingService.createOrUpdateBlogger(this.Blogger).then( this.$router.push("/sandbox/blogging/bloggers") ).catch( error => console.log(error) );
    }
  },
};
</script>
  