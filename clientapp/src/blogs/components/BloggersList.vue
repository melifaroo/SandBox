<template>
  <div class="table-scroll">
    <table class="table table-striped" id="bloggerTable">
      <thead>
        <tr>
          <th class="col-xs-3" scope="col" style="display:none;"><label for="Id">Id</label></th>
          <th class="col-xs-3"><label>NickName</label></th>
          <th class="col-xs-6"><label>Controls</label></th>
        </tr>
      </thead>
      
      <tbody v-if="bloggers && bloggers.length">
        <tr  v-for="blogger of bloggers" v-bind:key="blogger">
          <th class="col-xs-3" scope="row" style="display:none;">{{ blogger.bloggerId }}</th>
          <td class="col-xs-3"><router-link class="btn btn-link" :to="'/blogs/bloggers/'+ blogger.bloggerId">{{ blogger.nickName }} </router-link></td>
          <td class="col-xs-6">
            <router-link class="btn btn-warning" :to="'/blogs/bloggers/edit/'+ blogger.bloggerId">Edit</router-link>
            <router-link class="btn btn-danger" :to="'/blogs/bloggers/delete/'+ blogger.bloggerId">Delete</router-link>      
          </td>
        </tr>
      </tbody>
    </table>
  </div>
    
</template>

<script>
export default {
  props: {
    bloggers: {
        type: Array,
        default: () => []
    }
  }
};

</script>
