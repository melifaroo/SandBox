<template>
  <div class="bloggerForm">
    <h1>input or edit blogger details </h1>
    <div class="container">
      <form @submit.prevent="createOrUpdateBlogger">
        <div class="input-group">
          <div class="input-group-prepend">
              <span class="input-group-text" >NickName</span>
          </div>   
          <input type="text" class="form-control"  id="NickName"  v-model="Blogger.nickName" placeholder="Enter NickName" />
        </div>
        <ul>
          <a class="btn btn-secondary" @click="this.$router.go(-1)">Cancel</a>
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
    if ("bloggerid" in this.$route.params) {
      bloggingService.getBloggerById(this.$route.params.bloggerid).then( result => this.Blogger = result ).catch( error => console.log(error) );
    }    
  },
  methods: {   
    async createOrUpdateBlogger() {
      await bloggingService.createOrUpdateBlogger(this.Blogger).catch( error => console.log(error) );
      this.$router.go(-1);
    }
  },
};
</script>
  