<template>
  <div class="hello">
    <h1>{{ title }}</h1>
  </div>
</template>

<script>
export default {
  data() {
    return {
      title: "Lista de Permisos"
    };
  }
};
</script>

<style>
h1,
h2 {
  font-weight: normal;
}

ul {
  list-style-type: none;
}

li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #35495e;
}
</style>
