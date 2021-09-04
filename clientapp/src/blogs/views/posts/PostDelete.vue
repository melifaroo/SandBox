<template>
  <div class="deletepost">
    <postdetails />
    <ul>
      <a class="btn btn-secondary" @click="$router.go(-1)">Cancel</a>
      <a class="btn btn-danger" @click="deletePost(this.$route.params.postid)">Confirm Delete</a>
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
      await bloggingService.deletePost(id).catch( error => console.log(error) );
      this.$router.go(-1);
    },
  },
};
</script>
