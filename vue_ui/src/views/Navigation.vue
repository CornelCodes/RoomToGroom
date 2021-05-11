<template>

  <nav class="navbar navbar-expand-lg navbar-light bg-light">
  <div class="container-fluid">
    <a class="navbar-brand" href="/">Room To Groom</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
            <li class="nav-item">
                <a href="/" class="nav-link">Home</a>
            </li>
            <li class="nav-item">
                <a href="Pets" class="nav-link">Pets</a>
            </li>
            <li class="nav-item">
                <a href="Customers" class="nav-link">Customers</a>
            </li>
            <li class="nav-item">
                <a href="Login" class="nav-link">Login</a>
            </li>
            <li class="nav-item">
                <a href="Register" class="nav-link">Register</a>
            </li>
        </ul>
      <form class="d-flex">
        <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search">
        <button class="btn btn-outline-success" type="submit">Search</button>
      </form>
    </div>
  </div>
</nav>
</template>

<script>
import "bootstrap/dist/css/bootstrap.min.css";

export default {

}
</script>

<style>

</style>