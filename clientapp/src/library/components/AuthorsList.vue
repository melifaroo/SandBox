<template>
  <div>
    <h1> <samp v-if="authors.length > 0">{{authors.length}}</samp><samp v-else>No</samp> Author<samp v-show="authors.length != 1">s</samp> presented in library </h1>
    <div class="table-scroll">    
      <table class="table table-striped mb-0" id="authorsTable">
        <thead>
          <tr>
            <th style="display:none;"><label>Id</label></th>
            <th><label>Full Name</label></th>
            <th><label>Controls</label></th>
          </tr>
        </thead>
        <tbody v-if="authors && authors.length">
          <tr v-for="author of authors" v-bind:key="author">
            <th scope="row" style="display:none;">{{ author.authorId }}</th>
            <td align="right"><router-link class="btn btn-link" :to="'/library/authors/'+ author.authorId">{{ author.fullName }}</router-link></td>
            <td align="left">
              <router-link class="btn btn-warning" :to="'/library/authors/correct/'+ author.authorId">Correct</router-link>
              <router-link class="btn btn-primary" :to="'/library/authors/'+ author.authorId">View books</router-link>      
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
    export default { props: { authors: { type: Array, default: () => [] } } };
</script>
