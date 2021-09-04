<template>
  <div class="deleteblog">
    <blogdetails />
    <ul>
      <a class="btn btn-secondary" @click="this.$router.go(-1)">Cancel</a>
      <a class="btn btn-danger" @click="deleteBlog(this.$route.params.blogid)">Confirm Delete</a>
    </ul>
  </div>
</template>

<script>
import BlogDetails from "../components/BlogDetails.vue";
import bloggingService from '..'

export default {
  components: {
    blogdetails: BlogDetails,
  },
  methods: {
    async deleteBlog(id) {
      await bloggingService.deleteBlog(id).catch( error => console.log(error) );
      this.$router.go(-1);
    },
  },
};
</script>
