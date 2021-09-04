<template>
  <div class="deleteblogger">
    <bloggerdetails />
    <ul>
      <a class="btn btn-secondary" @click="this.$router.go(-1)">Cancel</a>
      <a class="btn btn-danger" @click="deleteBlogger()">Confirm Delete</a>
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
    async deleteBlogger() {
      await bloggingService.deleteBlogger(this.$route.params.bloggerid).catch( error => console.log(error) );
      this.$router.go(-1);
    },
  },
};
</script>
