<template>
  <div class="Borrowings">
    <borrowingslist :borrowings="borrowings" />
  </div>
</template>

<script>
    import borrowingslist from "../components/BorrowingsList.vue"
    import libraryService from '..'
    export default {
    data() { return { borrowings: [], }; },
    created() { libraryService.getRegister().then(result => this.borrowings = result).catch((error) => console.log(error));  },
    components :{ borrowingslist, },
    };
</script>