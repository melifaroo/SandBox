<template>
  <div class="table-scroll">
    <table class="table table-striped mb-0" id="readersTable">
      <thead>
        <tr>
          <th style="display:none;"><label>Id</label></th>
          <th><label>Full Name</label></th>
          <th><label>Controls</label></th>
        </tr>
      </thead>
      <tbody v-if="readers && readers.length">
        <tr v-for="reader of readers" v-bind:key="reader">
          <th scope="row" style="display:none;">{{ reader.readerId }}</th>
          <td align="right"><router-link class="btn btn-link" :to="'/library/readers/'+ reader.readerId">{{ reader.fullName }}</router-link></td>
          <td align="left">
            <router-link class="btn btn-warning" :to="'/library/readers/correct/'+ reader.readerId">Correct</router-link>
            <router-link class="btn btn-primary" :to="'/library/readers/'+ reader.readerId">View borrowings</router-link>      
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
    export default { props: { readers: { type: Array, default: () => [] } } };
</script>
