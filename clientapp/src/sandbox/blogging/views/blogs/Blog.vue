<template>
  <div class="blog">
    <blogdetails />
    <ul>
      <a class="btn btn-secondary" onclick="history.back()">Return</a>
      <a class="btn btn-primary" @click="createPostToBlog(this.$route.params.id)">Create post</a>
    </ul>
  </div>
  <div class="blog-posts">
    <h1>Posts in blog</h1>        
    <postslist :posts="posts" />
    <!--a class="btn btn-success" href="/addpost">Write new post</a-->
  </div>
</template>

<script>
import postslist from "../../components/PostsList.vue"
import blogdetails from "../../components/BlogDetails.vue"

export default {
  data() {
    return {
      posts: [],
    };
  },
  created() {
      this.getBlogPosts();      
  },
  components :{
      postslist,
      blogdetails
  },
  methods: {
    getBlogPosts() {
        fetch("https://localhost:5001/sandbox/blogging/blogs/"+this.$route.params.id+"/posts")
          .then(async (response) => {
            const data = await response.json();
            if (!response.ok) {
              // get error message from body or default to response statusText
              const error = (data && data.message) || response.statusText;
              return Promise.reject(error);
            }
            this.posts = data;
          })
          .catch((error) => console.log(error));
    }
  },
};
</script>
