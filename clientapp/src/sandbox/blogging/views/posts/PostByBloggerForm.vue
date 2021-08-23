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
          <a class="btn btn-secondary" href="/sandbox/blogging/posts">Return</a>
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
        postId: undefined,
        title: "",
        content: "",
        blogger: {},
        blog: {},
      },
    };
  },
  created (){
      bloggingService.getPostById(this.$route.params.id).then( result => this.Post = result ).catch( error => console.log(error) );
  },
  methods: {   
    async updatePost() {
      await bloggingService.updatePost(this.Post).then( this.$router.push("/sandbox/blogging/posts")  ).catch( error => console.log(error) );
    }
  },
};
</script>
  