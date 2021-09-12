<template>
  <div class="Authors">
    <authorslist :authors="authors" />
  </div>
</template>

<script>
    import authorslist from "../components/AuthorsList.vue"
    import libraryService from '..'
    export default {
      data() { return { authors: [], }; },
      created() { libraryService.getAuthors().then(result => this.authors = result).catch((error) => console.log(error));  },
      components :{ authorslist, },
    };
</script>