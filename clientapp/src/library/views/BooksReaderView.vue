<template>
  <form> <label>Please select reader account</label></form>
  <div class="Books">
    <bookslist :books="books" />
  </div>
</template>

<script>
    import bookslist from "../components/BooksReader.vue"
    import libraryService from '..'
    export default {
    data() { return { books: [], }; },
    created() { libraryService.getBooksReaderView().then(result => this.books = result).catch((error) => console.log(error));  },
    components :{ bookslist, },
    };
</script>