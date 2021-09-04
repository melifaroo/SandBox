<template>
  <div class="blogger">
    <bloggerdetails />
    <ul>
      <router-link class="btn btn-secondary" :to="'/blogs/bloggers'">All bloggers</router-link>
      <router-link  class="btn btn-primary" :to="'/blogs/bloggers/'+this.$route.params.bloggerid+'/createpost'">Create post</router-link >
    </ul>
  </div>
  
  <router-view /> 
</template>

<script>
import BloggerDetails from "../../components/BloggerDetails.vue";

export default {
  data() {
    return {
    };
  },
  components: {
    bloggerdetails: BloggerDetails,
  },
};
</script>