<template>
<div class="container">
    <div class="header">
        <h1>Customers</h1>
    </div>
    <div class="customersList">
        <ul>
            <li>sampleCustomer</li>
        </ul>
    </div>
    <div class="addCustomer">
        <button type="button">Add Customer</button>
    </div>
</div>
</template>

<script>
export default {

}
</script>

<style scoped>
*{
    z-index: -10;
}
.container{
    position: fixed;
    width: 90%;
    left: 5%;
    top: 20%;
}

.header{
    margin: 10px;
    padding: 10px;
    border: 1px solid black;
    border-radius: 25px;
    background: black;
    color: white;
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
}

.customersList{
    position: fixed;
    border: 1px solid black;
    width: 80%;
    height: 50%;
    left: 10%;

}

.customersList ul{
    list-style-type: none;
}

.addCustomer{
    position: fixed;
    bottom: 8%;
    right: 10%;
}
</style>