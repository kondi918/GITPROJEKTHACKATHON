<template>
    <div class="userProfileIcon" @click="goToProfile"></div>
  </template>
  
  <script>
  export default {
    name: "UserProfileIcon",
    methods: {
      goToProfile() {
        // Programowe przekierowanie na stronę profilu
        this.$router.push({ name: 'ProfilePage' });
      }
    }
  };
  </script>
  
  <style scoped>
  .userProfileIcon {
    width: 40px;
    height: 40px;
    border-radius: 50%;
    background-color: #fff;
    position: fixed;
    top: 25px;
    right: 25px;
    cursor: pointer; /* Zmieniamy kursor na "rękę" przy najechaniu */
  }
  
  .userProfileIcon:hover {
    background-color: #ddd; /* Opcjonalnie: zmień kolor przy najechaniu */
  }
  </style>
  