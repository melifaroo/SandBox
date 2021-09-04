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
          <td><router-link class="btn btn-link" :to="'/blogs/'+ blog.blogId">{{ blog.url }}</router-link></td>
          <td>
            <router-link class="btn btn-warning" :to="'/blogs/edit/'+ blog.blogId">Rename</router-link>
            <router-link class="btn btn-danger" :to="'/blogs/delete/'+ blog.blogId">Delete</router-link>      
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

