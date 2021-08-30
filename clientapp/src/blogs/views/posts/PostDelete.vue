<template>
  <div class="deletepost">
    <postdetails />
    <ul>
      <a class="btn btn-secondary" href="/blogs/posts">Cancel</a>
      <a class="btn btn-danger" @click="deletePost(this.$route.params.id)">Confirm Delete</a>
    </ul>
  </div>
</template>

<script>
import PostDetails from "../../components/PostDetails.vue";
import bloggingService from '../..'

export default {
  components: {
    postdetails: PostDetails,
  },
  methods: {
    async deletePost(id) {
      await bloggingService.deletePost(id).then( this.$router.push("/blogs/posts") ).catch( error => console.log(error) );
    },
  },
};
</script>
