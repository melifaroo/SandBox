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
          <td><a class="btn btn-link" v-bind:href="'/blogs/posts/'+ post.postId">{{ post.title }}</a></td>
          <td><a class="btn btn-link" v-bind:href="'/blogs/bloggers/'+ post.blogger.bloggerId">{{ post.blogger.nickName }}</a></td>
          <td><a class="btn btn-link" v-bind:href="'/blogs/'+ post.blog.blogId">{{ post.blog.url }}</a></td>
          <td>
            <a class="btn btn-warning" v-bind:href="'/blogs/posts/edit/'+ post.postId">Edit</a>
            <a class="btn btn-danger" v-bind:href="'/blogs/posts/delete/'+ post.postId">Delete</a>      
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
