<template>
  
</template>

<script>
export default {
  data(){
    return{
      
    }
  },
  methods:{
    register(){
      if(this.name != '' && this.email != '' && this.password != ''){
        this.$emit('submit-register', this.name, this.email, this.password)
      }
      else{
        alert('Please enter all fields')
      }
    }
  }
}
</script>

<style scoped>

</style>