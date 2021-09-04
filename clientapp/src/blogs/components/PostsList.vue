<template>
  <div class="table-scroll">
    <table class="table table-striped mb-0" id="postsTable">
      <thead>
        <tr>
          <th style="display:none;"><label>Id</label></th>
          <th><label>Title</label></th>
          <th><label>Author</label></th>
          <th><label>Blog</label></th>
          <th><label>Controls</label></th>
        </tr>
      </thead>
      <tbody v-if="posts && posts.length" >
        <tr v-for="post of posts" v-bind:key="post">
          <th scope="row" style="display:none;">{{ post.postId }}</th>
          <td><router-link class="btn btn-link" :to="'/blogs/posts/'+ post.postId">{{ post.title }}</router-link></td>
          <td><router-link class="btn btn-link" :to="'/blogs/bloggers/'+ post.blogger.bloggerId">{{ post.blogger.nickName }}</router-link></td>
          <td><router-link class="btn btn-link" :to="'/blogs/'+ post.blog.blogId">{{ post.blog.url }}</router-link></td>
          <td>
            <router-link class="btn btn-warning" :to="'/blogs/posts/edit/'+ post.postId">Edit</router-link>
            <router-link class="btn btn-danger" :to="'/blogs/posts/delete/'+ post.postId">Delete</router-link>      
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  props: {
    posts: {
        type: Array,
        default: () => []
    }
  }
};
</script>
