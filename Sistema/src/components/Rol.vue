<template>
  <v-layout align-start>
    <v-flex>
      <v-data-table
      :headers="headers" 
      :items="roles" 
      :search="search"
       class="elevation-1">
        <template v-slot:top>
          <v-toolbar flat color="white">
            <v-toolbar-title>Roles</v-toolbar-title>
            <v-divider class="mx-4" inset vertical></v-divider>
            <v-spacer></v-spacer>
            <v-text-field class="text-xs-center" v-model="search" label="Busqueda" single-line hide-details></v-text-field>
             <v-spacer></v-spacer>
                 
          </v-toolbar>
        </template>
        
        <template v-slot:item.condicion="{ item }" >
          <td v-if="item.condicion" class="blue--text" > Activo</td>        
          <td v-else class="red--text" >Inactivo</td>   
       </template> 
        <template v-slot:no-data>
          <v-btn color="primary" @click="listar">Actualizar</v-btn>
        </template>
      </v-data-table>
    </v-flex>
  </v-layout>
  
</template>
<script>
import axios from 'axios'
export default {
  data() {
    return {
      roles:[],  
      dialog: false,
      headers: [
        { text: "Nombre", value: "nombre", },
        { text: "Descripción", value: "descripcion", sortable: false, },
        { text: "Estado", value: "condicion", sortable: false }
        
      ],
      search: '',
                 
    }
  },
  computed: {
   
  },

  watch: {
   
  },

  created() {
   
    this.listar();
  },
  methods: {
      listar(){
        let me=this;
          axios.get('api/Roles/Listar').then(function(response){
              //console.log(response);
              me.roles=response.data;
          }).catch(function(error){
              console.log(error);
          });
      }
      
    }
};
</script>
