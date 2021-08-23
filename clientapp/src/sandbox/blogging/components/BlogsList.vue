<template>
  <div class="table-scroll">
    <table class="table table-striped mb-0" id="blogsTable">
      <thead>
        <tr>
          <th style="display:none;"><label>Id</label></th>
          <th><label>Blog</label></th>
          <th><label>Controls</label></th>
        </tr>
      </thead>
      <tbody v-if="blogs && blogs.length">
        <tr v-for="blog of blogs" v-bind:key="blog">
          <th scope="row" style="display:none;">{{ blog.blogId }}</th>
          <td><a class="btn btn-link" v-bind:href="'/sandbox/blogging/Blogs/'+ blog.blogId">{{ blog.url }}</a></td>
          <td>
            <a class="btn btn-warning" v-bind:href="'/sandbox/blogging/EditBlog/'+ blog.blogId">Rename</a>
            <a class="btn btn-danger" v-bind:href="'/sandbox/blogging/DeleteBlog/'+ blog.blogId">Delete</a>      
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  props: {
    blogs: {
        type: Array,
        default: () => []
    }
  }
};
</script>

