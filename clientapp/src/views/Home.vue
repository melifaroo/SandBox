<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo.png">
    <Startpage msg="Welcome"/>
  </div>
</template>

<script>
// @ is an alias to /src
    import Startpage from '@/components/Startpage.vue'

export default {
  name: 'Home',
  components: {
      Startpage
  }
}
</script>
