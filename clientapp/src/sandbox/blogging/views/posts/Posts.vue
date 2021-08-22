<template>
  <div class="Posts">
    <h1>Posts</h1>        
    <postslist :posts="posts" />
    <!--a class="btn btn-success" href="/addpost">Write new post</a-->
  </div>
</template>

<script>
import postslist from "../../components/PostsList.vue"

export default {
  data() {
    return {
      posts: [],
    };
  },
  created() {
      this.getPosts();      
  },
  components :{
      postslist
  },
  methods: {
    getPosts() {
        fetch("https://localhost:5001/sandbox/blogging/posts")
          .then(async (response) => {
            const data = await response.json();
            if (!response.ok) {
              // get error message from body or default to response statusText
              const error = (data && data.message) || response.statusText;
              return Promise.reject(error);
            }
            console.log(data);
            this.posts = data;
          })
          .catch((error) => console.log(error));
    }
  },
};
</script>
