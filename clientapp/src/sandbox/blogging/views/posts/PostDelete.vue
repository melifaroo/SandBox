<template>
  <div class="deletepost">
    <postdetails />
    <ul>
      <a class="btn btn-secondary" v-bind:href="'/sandbox/blogging/posts'">Cancel</a>
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
      await bloggingService.deletePost(id).then( this.$router.push("/sandbox/blogging/posts") ).catch( error => console.log(error) );
    },
  },
};
</script>
