<template>
  <div class="blogger">
    <bloggerdetails />
    <ul>
      <a class="btn btn-secondary" onclick="history.back()">Return</a>
      <a class="btn btn-primary" @click="createPost(this.$route.params.id)">Create post</a>
    </ul>
  </div>
</template>

<script>
import BloggerDetails from "../../components/BloggerDetails.vue";

export default {
  components: {
    bloggerdetails: BloggerDetails,
  },
  methods: {
  },
};
</script>