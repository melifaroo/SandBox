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
          <td class="col-xs-3"><a class="btn btn-link" v-bind:href="'/blogs/bloggers/'+ blogger.bloggerId">{{ blogger.nickName }} </a></td>
          <td class="col-xs-6">
            <a class="btn btn-warning" v-bind:href="'/blogs/bloggers/edit/'+ blogger.bloggerId">Edit</a>
            <a class="btn btn-danger" v-bind:href="'/blogs/bloggers/delete/'+ blogger.bloggerId">Delete</a>      
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
