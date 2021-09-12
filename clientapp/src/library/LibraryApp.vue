<template>
  <libnavbar></libnavbar>
  <router-view />
</template>

<script>
import LibNavbar from "@/library/components/LibNavbar";

export default {
  name: "LibraryApp",
  components: {
    libnavbar : LibNavbar,
  },
};
</script>