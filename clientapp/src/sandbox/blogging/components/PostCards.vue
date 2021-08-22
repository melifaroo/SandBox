<template>
  <div class="card-deck flex-wrap" v-if="posts && posts.length">
    <div v-for="post of currentPageItems" v-bind:key="post">
      <div class="card bg-light mb-6" style="width=16rem;">
        <div class="card-header">
          <h5 class="card-title">
            <a v-bind:href="'/sandbox/blogging/Posts/' + post.postId">{{post.title}}</a>
          </h5>
        </div>        
        <div class="card-body">
            <h1>{{post.content}}</h1>            
          <p>
            <a class="btn btn-primary" v-bind:href="'/sandbox/blogging/PostForm/' + post.postId">Edit post</a>
            <a class="btn btn-danger" v-bind:href="'/sandbox/blogging/DeletePost/' + post.postId">Delete</a>
          </p>
        </div>
      </div>
    </div>
  </div>
  <nav>
    <ul class="pagination justify-content-center">
      <li v-bind:class="(currentPage<2)?'page-item disabled':'page-item'">
        <a class="page-link" @click="currentPage--" tabindex="-1" aria-disabled="true" >Previous</a>
      </li>
     
      <li v-for="page in pageCount" v-bind:key="page" class="page-item"><a class="page-link" @click="currentPage = page">{{page}}</a></li>

      <li v-bind:class="(currentPage>pageCount-1)?'page-item disabled':'page-item'">
        <a class="page-link" @click="currentPage++" tabindex="-1" aria-disabled="true">Next</a>
      </li>
    </ul>
  </nav>
</template>


<script>
export default {
  data() {
    return {
      currentPage: 1,
      perPage: 5,
      paginated_items: [],
      currentPageIndex:0,
    };
  },

  props: {
    posts: {
      type: Array,
      default: () => [],
    },
  },
  computed: {
    pageCount() {
        return Math.ceil(this.posts.length / this.perPage);
    },
    currentPageItems() {
      return this.posts.slice( (this.currentPage-1)*this.perPage, Math.min( this.currentPage*this.perPage, this.blogs.length ) );
    },
  },
  methods: {
  },
};
</script>