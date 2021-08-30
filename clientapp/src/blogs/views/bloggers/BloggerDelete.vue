<template>
  <div class="deleteblogger">
    <bloggerdetails />
    <ul>
      <a class="btn btn-secondary" href="/blogs/bloggers">Cancel</a>
      <a class="btn btn-danger" @click="deleteBlogger(this.$route.params.id)">Confirm Delete</a>
    </ul>
  </div>
</template>

<script>
import BloggerDetails from "../../components/BloggerDetails.vue";
import bloggingService from '../..'

export default {
  components: {
    bloggerdetails: BloggerDetails,
  },
  methods: {
    async deleteBlogger(id) {
      await bloggingService.deleteBlogger(id).then( this.$router.push("/blogs/bloggers") ).catch( error => console.log(error) );
    },
  },
};
</script>
