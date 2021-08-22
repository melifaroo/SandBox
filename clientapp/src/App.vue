<template>
  <navbar></navbar>
  <router-view />
</template>

<script>
import Navbar from "@/components/Navbar";

export default {
  name: "App",
  components: {
    Navbar,
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
.table-scroll {
  height: 400px;
  overflow-y: auto;
  overflow-x: hidden;
}
.table-scroll table{
  border-spacing: 0px;
  border-collapse: separate;
  border-color: lightblue;
}
.table-scroll table tr th{
  border: 0px solid;
  border-color: lightgray;
}
.table-scroll table tr td {
  border: 1px dotted;
  border-color: lightgray;
}
.table-scroll thead tr:nth-child(1) th {
  background: white;
  position: sticky;
  top: 0;
  z-index: 1;
}

</style>

