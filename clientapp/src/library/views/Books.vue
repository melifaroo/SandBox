<template>
  <div class="BooksManager">
    <bookslist :books="books" />
  </div>
</template>

<script>
    import bookslist from "../components/BooksManager.vue"
    import libraryService from '..'
    export default {
    data() { return { books: [], }; },
    created() { libraryService.getStorage().then(result => this.books = result).catch((error) => console.log(error));  },
    components :{ bookslist, },
    };
</script>