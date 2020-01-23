<template>
  <v-layout align-start>
    <v-flex>
      <v-data-table
      :headers="headers" 
      :items="Personas" 
      :search="search"
       class="elevation-1">
        <template v-slot:top>
          <v-toolbar flat color="white">
            <v-toolbar-title>Personas</v-toolbar-title>
            <v-divider class="mx-4" inset vertical></v-divider>
            <v-spacer></v-spacer>
            <v-text-field class="text-xs-center" v-model="search" label="Busqueda" single-line hide-details></v-text-field>
             <v-spacer></v-spacer>
            <v-dialog v-model="dialog" max-width="500px">
              <template v-slot:activator="{ on }">
                <v-btn color="primary" dark class="mb-2" v-on="on">Nuevo</v-btn>
              </template>
              <v-card>
                <v-card-title>
                  <span class="headline">{{ formTitle }}</span>
                </v-card-title>

                <v-card-text>
                  <v-container>
                    <v-row>
                      <v-col cols="12" sm="6" md="6">
                        <v-text-field v-model="nombre" label="Nombre"></v-text-field>
                      </v-col>
                       <v-col cols="12" sm="6" md="6">
                        <v-select v-model="idrol"
                          :items="roles" label='Rol'>
                        </v-select>
                      </v-col>
                      <v-col cols="12" sm="6" md="6">
                        <v-select v-model="tipo_documento"
                          :items="documentos" label='Tipo Documento'>
                        </v-select>
                      </v-col>

                      <v-col cols="12" sm="6" md="6">
                        <v-text-field v-model="num_documento" label="Número Documento"></v-text-field>
                      </v-col>
                      <v-col cols="6" sm="6" md="6">
                        <v-text-field v-model="direccion" label="Dirección"></v-text-field>
                      </v-col>
                      <v-col cols="6" sm="6" md="6">
                        <v-text-field  v-model="telefono" label="Teléfono"></v-text-field>
                      </v-col>
                      <v-col cols="12" sm="6" md="6">
                        <v-text-field v-model="email" label="Email"></v-text-field>
                      </v-col>
                      <v-col cols="12" sm="6" md="6">
                        <v-text-field type="password" v-model="password" label="Passwor"></v-text-field>
                      </v-col>
                      <v-col cols="12" sm="6" md="6" v-show="valida">
                        <div class="red--text" v-for="v in validaMensaje" :key="v" v-text="v"></div>  
                      </v-col>
                    </v-row>
                  </v-container>
                </v-card-text>

                <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn color="blue darken-1" text @click="close">Cancelar</v-btn>
                  <v-btn color="blue darken-1" text @click="guardar">Guardar</v-btn>
                </v-card-actions>
              </v-card>
            </v-dialog>
            <v-dialog v-model="adModal" max-width="290px" >
                <v-card>
                  <v-card-title class="headline" v-if="adAccion==1">¿Activar Usuario?</v-card-title>
                  <v-card-title class="headline" v-if="adAccion==2">¿Desactivar Usuario?</v-card-title>
                  <v-card-text>
                    Estás a punto de
                    <span v-if="adAccion==1">Activar</span>
                    <span v-if="adAccion==2">desactivar</span>
                    al Usuario {{ adNombre }}
                  </v-card-text>
                  <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn color="warning" dark  @click="activarDesactivarCerrar">
                      Cancelar
                    </v-btn>
                     <v-btn v-if="adAccion==1" text small color="primary"  @click="activar">
                      Activar
                    </v-btn>
                    <v-btn v-if="adAccion==2" text small color="error"  @click="desactivar">
                      Desactivar
                    </v-btn>
                  </v-card-actions>
                </v-card>
            </v-dialog>
         
          </v-toolbar>
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
      clientes:[],  
      dialog: false,
      headers: [
        { text: "Opciones", value: "opciones", sortable: false },
        { text: "Nombre", value: "nombre" },
        { text: "Tipo Persona", value: "tipo_persona"},
        { text: "Tipo Documento", value: "tipo_documento"},
        { text: "Número Documento", value: "num_documento",sortable: false },
        { text: "Dirección", value: "direccion",sortable: false },
        { text: "Teléfono", value: "telefono", sortable: false, },
        { text: "Email", value: "email", sortable: false, }
       
   
      ],
      search: '',
      editedIndex: -1,
      idrol:'',
      roles:[],
      nombre: '',
      tipo_documento:'',
      documentos:['INE','CURP','PASAPORTE','CEDULA'],
      num_documento:'',
      direccion: '',
      telefono:'',
      email:'',
      password:'',
      actPassword:false,
      passwordAnt:'',
      valida: 0,
      validaMensaje:[],
      adModal:0,
      adAccion: 0,
      adNombre: 0,
      adId: ''            
    }
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "Nuevo Usuario" : "Actualizar Usuario";
    }
  },

  watch: {
    dialog(val) {
      val || this.close();
    }
  },

  created() {
   
    this.listar();
    this.select();
  },
  methods: {
      listar(){
        let me=this;
          axios.get('api/Personas/ListarClientes').then(function(response){
              //console.log(response);
              me.clientes=response.data;
          }).catch(function(error){
              console.log(error);
          });
      },

      select(){
        let me=this;
        var rolesArray=[];
          axios.get('api/roles/Select').then(function(response){
             rolesArray=response.data;
             rolesArray.map(function(x){
               me.roles.push({text: x.nombre,value:x.idrol});
             });

             
          }).catch(function(error){
              console.log(error);
          });
      },

      editItem(item) {
          this.id=item.idusuario;
          this.idrol=item.idrol;
          this.nombre=item.nombre;
          this.tipo_documento=item.tipo_documento;
          this.num_documento=item.num_documento;
          this.direccion=item.direccion;
          this.telefono=item.telefono;
          this.email=item.email;
          this.password=item.password_hash;
          this.passwordAnt=item.password_hash;
          this.editedIndex = 1; 
          this.dialog = true
      },

    
      close() {
            this.dialog = false
            this.limpiar ();
            
      }, 
      
      limpiar(){
          this.id="",
          this.idrol="",
          this.nombre="";
          this.tipo_documento="";
          this.num_documento="";
          this.direccion="";
          this.telefono=""; 
          this.email=""; 
          this.password=""; 
          this.actPassword0="";
          this.passwordAnt="";
          this.editedIndex=-1;
      },

      guardar () {
            if(this.validar()){
              return;
            }
            if (this.editedIndex > -1) {
               //codigo para editar
               let me =this;
               if(me.password!=me.passwordAnt){
                 me.actPassword=true;
               }

                axios.put('api/Usuarios/Actualizar',{
                  'idusuario':me.id,
                  'idrol' : me.idrol,
                  'nombre': me.nombre,
                  'tipo_documento': me.tipo_documento,
                  'num_documento':me.num_documento,
                  'direccion': me.direccion,
                  'telefono' : me.telefono,
                  'email' : me.email,
                  'password' : me.password,
                  'act_password': me.actPassword
                }).then(function(response){
                    me.close();
                    me.listar();
                    me.limpiar();
                }).catch(function(error){
                    console.log(error);
                });
                
            } else {
              //codigo para guardar
                let me =this;
                axios.post('api/usuarios/Crear',{
                  'idrol' : me.idrol,
                  'nombre': me.nombre,
                  'tipo_documento': me.tipo_documento,
                  'num_documento':me.num_documento,
                  'direccion': me.direccion,
                  'telefono' : me.telefono,
                  'email' : me.email,
                  'password' : me.password
                }).then(function(response){
                    me.close();
                    me.listar();
                    me.limpiar();
                }).catch(function(error){
                    console.log(error);
                })
            }
      }, 

      validar(){
        this.valida=0;
        this.validaMensaje=[];
        if(this.nombre.length<3 || this.nombre.length>100){
          this.validaMensaje.push("El nombre debe tener más de 3 caracteres y menos de 100.");
        }
        if(!this.idrol){
          this.validaMensaje.push("Seleccione una Rol.");
        }
        if(!this.tipo_documento){
          this.validaMensaje.push("Seleccione una tipo de Documento.");
        }
        if(!this.email){
          this.validaMensaje.push("Ingrese el email del usuario.");
        }
        if(!this.password){
          this.validaMensaje.push("Ingrese el password del usuario");
        }

        if(this.validaMensaje.length){
          this.valida=1;
        }
        return this.valida;
      },

      ActivarDesactivarMostrar(accion,item){

        this.adModal=1;
        this.adNombre=item.nombre;
        this.adId=item.idusuario;

        if(accion==1){
          this.adAccion=1;
          
        }else if(accion==2){
            this.adAccion=2;           
        }else{
          this.adModal=0;
        }
      },

       activar(){
               let me = this;
                  axios.put('api/Usuarios/Activar/'+this.adId,{}).then(function(response) {
                    me.adModal = 0;
                    me.adAccion = 0;
                    me.adNombre = ""                  ;
                    me.adId = "";
                    me.listar();

                  }).catch(function(error) {
                    console.log(error)
                  });

            },
            desactivar(){
               let me = this;
                  axios.put('api/Usuarios/Desactivar/'+this.adId,{}).then(function(response) {
                    me.adModal = 0;
                    me.adAccion = 0;
                    me.adNombre = "";
                    me.adId = "";
                    me.listar();

                  }).catch(function(error) {
                    console.log(error)
                  });

            },
            activarDesactivarCerrar(){
              this.adModal = 0;

            }
    }
};
</script>
