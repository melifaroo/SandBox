<template>
  <div>
    <h1> <samp v-if="books.length > 0">{{books.length}}</samp><samp v-else>No</samp> Book<samp v-show="books.length != 1">s</samp> presented in library </h1>
    <div class="table-scroll">
      <table class="table table-striped mb-0" id="booksTable">
        <thead>
          <tr>
            <th style="display:none;"><label>Id</label></th>
            <th><label>Title</label></th>
            <th><label>Author</label></th>
            <th><label>Controls</label></th>
          </tr>
        </thead>
        <tbody v-if="books && books.length">
          <tr v-for="book of books" v-bind:key="book">
            <th scope="row" style="display:none;">{{ book.bookId }}</th>
            <td align="right"><router-link class="btn btn-link" :to="'/library/books/'+ book.bookId">{{ book.title }}</router-link></td>
            <td align="left"><label>by </label><router-link class="btn btn-link" :to="'/library/authors/'+ book.authorId">{{ book.author }}</router-link></td>
            <!--td align="center"><label>{{ book.totalAmount }}</label></td-->
            <td align="left">
              <!--router-link class="btn btn-warning" :to="'/library/books/correct/'+ book.bookId">Correct</router-link-->
              <router-link class="btn btn-success" :to="'/library/authors/'+ book.authorId">Borrow</router-link>      
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
    export default { props: { books: { type: Array, default: () => [] } } };
</script>