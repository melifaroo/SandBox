<template>
  <div class="deleteblog">
    <blogdetails />
    <ul>
      <a class="btn btn-secondary" v-bind:href="'/sandbox/blogging/blogs'">Cancel</a>
      <a class="btn btn-danger" @click="deleteBlog(this.$route.params.id)">Confirm Delete</a>
    </ul>
  </div>
</template>

<script>
import BlogDetails from "../../components/BlogDetails.vue";
import bloggingService from '../..'

export default {
  components: {
    blogdetails: BlogDetails,
  },
  methods: {
    async deleteBlog(id) {
      await bloggingService.deleteBlog(id).then( this.$router.push("/sandbox/blogging/blogs") ).catch( error => console.log(error) );
    },
  },
};
</script>
