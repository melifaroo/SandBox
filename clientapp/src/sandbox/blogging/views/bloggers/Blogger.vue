<template>
  <div class="blogger">
    <bloggerdetails />
    <ul>
      <a class="btn btn-secondary" href="/sandbox/blogging/bloggers">All bloggers</a>
      <a class="btn btn-primary" @click="createPost(this.$route.params.id)">Create post</a>
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
  created() {
  },
  methods: {
  },
};
</script>