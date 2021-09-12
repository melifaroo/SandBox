<template>
  <div class="Readers">
    <readerslist :readers="readers" />
  </div>
</template>

<script>
    import readerslist from "../components/ReadersList.vue"
    import libraryService from '..'
    export default {
      data() { return { readers: [], }; },
      created() { libraryService.getReaders().then(result => this.readers = result).catch((error) => console.log(error));  },
      components :{ readerslist, },
    };
</script>