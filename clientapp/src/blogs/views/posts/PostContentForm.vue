<template>
  <div class="postForm">
    <h1>Edit post content</h1>
    <div class="container">
      <form @submit.prevent="updatePost">
        <div class="form-group" style="margin-bottom: 10px">
          <input type="text" class="form-control"  id="title"  v-model="Post.title" placeholder="Post title" />
        </div>
        <div class="form-group" style="margin-bottom: 10px">
          <input type="text" class="form-control"  id="content"  v-model="Post.content" placeholder="Post content" />
        </div>
        <ul>
          <a class="btn btn-secondary" @click="this.$router.go(-1)">Return</a>
          <button type="submit" class="btn btn-info">Save</button>
        </ul>
      </form>
    </div>
  </div>
</template>

<script>
import bloggingService from '../..'

export default {
  name: "PostContentForm",
  data() {
    return {
      Post: {
        postId: this.$route.params.postid,
        title: "",
        content: "",
        blogger: {},
        blog: {},
      },
    };
  },
  created (){
      bloggingService.getPostById(this.$route.params.postid).then( result => this.Post = result ).catch( error => console.log(error) );
  },
  methods: {   
    async updatePost() {
      await bloggingService.updatePost(this.Post).catch( error => console.log(error) );      
      this.$router.go(-1);
    }
  },
};
</script>
  