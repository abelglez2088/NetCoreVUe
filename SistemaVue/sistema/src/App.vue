<template>
  <v-app id="inspire">
    <v-navigation-drawer v-model="drawer" :clipped="$vuetify.breakpoint.lgAndUp" app>
      <v-list dense>
       <template>
         <v-list-item :to="{name: 'home'}">
         <v-list-item-action>
           <v-icon>home</v-icon>
         </v-list-item-action>
         <v-list-item-title>Inicio </v-list-item-title>
         </v-list-item>
       </template>

       <template>
         <v-list-group>
           <v-list-item slot="activator">
            <v-list-item-content>
              <v-list-item-title>
                Almacén
              </v-list-item-title>
            </v-list-item-content>
           </v-list-item>
           <v-list-item :to="{ name:'categorias'}"> 
             <v-list-item-action>
                <v-icon>vertical_split</v-icon> 
              </v-list-item-action>
              <v-list-item-content>
                 <v-list-item-title>
                 Categorías
                </v-list-item-title>  
              </v-list-item-content> 
           </v-list-item>

           <v-list-item :to="{ name:'articulos'}"> 
             <v-list-item-action>
                <v-icon>spa</v-icon> 
              </v-list-item-action>
              <v-list-item-content>
                 <v-list-item-title>
                 Articulos
                </v-list-item-title>  
              </v-list-item-content> 
           </v-list-item>
         </v-list-group>
       </template>

        <template>
         <v-list-group>
           <v-list-item slot="activator">
            <v-list-item-content>
              <v-list-item-title>
                Compras
              </v-list-item-title>
            </v-list-item-content>
           </v-list-item>
           <v-list-item :to="{ name:''}"> 
             <v-list-item-action>
                <v-icon>add</v-icon> 
              </v-list-item-action>
              <v-list-item-content>
                 <v-list-item-title>
                 Ingresos
                </v-list-item-title>  
              </v-list-item-content> 
           </v-list-item>

           <v-list-item :to="{ name:'proveedores'}"> 
             <v-list-item-action>
                <v-icon>local_shipping</v-icon> 
              </v-list-item-action>
              <v-list-item-content>
                 <v-list-item-title>
                 Proveedores
                </v-list-item-title>  
              </v-list-item-content> 
           </v-list-item>
          </v-list-group>
       </template>

        <template>
         <v-list-group>
           <v-list-item slot="activator">
            <v-list-item-content>
              <v-list-item-title>
                Ventas
              </v-list-item-title>
            </v-list-item-content>
           </v-list-item>
           <v-list-item :to="{ name:''}"> 
             <v-list-item-action>
                <v-icon>attach_money</v-icon> 
              </v-list-item-action>
              <v-list-item-content>
                 <v-list-item-title>
                 Ventas
                </v-list-item-title>  
              </v-list-item-content> 
           </v-list-item>

           <v-list-item :to="{ name:'clientes'}"> 
             <v-list-item-action>
                <v-icon>group</v-icon> 
              </v-list-item-action>
              <v-list-item-content>
                 <v-list-item-title>
                 Clientes
                </v-list-item-title>  
              </v-list-item-content> 
           </v-list-item>

                 </v-list-group>
       </template>

        <template>
         <v-list-group>
           <v-list-item slot="activator">
            <v-list-item-content>
              <v-list-item-title>
                Accesos
              </v-list-item-title>
            </v-list-item-content>
           </v-list-item>
           <v-list-item :to="{ name:'roles'}"> 
             <v-list-item-action>
                <v-icon>lock_open</v-icon> 
              </v-list-item-action>
              <v-list-item-content>
                 <v-list-item-title>
                 Roles
                </v-list-item-title>  
              </v-list-item-content> 
           </v-list-item>

           <v-list-item :to="{ name:'usuarios'}"> 
             <v-list-item-action>
                <v-icon>person</v-icon> 
              </v-list-item-action>
              <v-list-item-content>
                 <v-list-item-title>
                 Usuarios
                </v-list-item-title>  
              </v-list-item-content> 
           </v-list-item>
         </v-list-group>
       </template>

       <template>
         <v-list-group>
           <v-list-item slot="activator">
            <v-list-item-content>
              <v-list-item-title>
                Consulta
              </v-list-item-title>
            </v-list-item-content>
           </v-list-item>
           <v-list-item :to="{ name:''}"> 
             <v-list-item-action>
                <v-icon>notes</v-icon> 
              </v-list-item-action>
              <v-list-item-content>
                 <v-list-item-title>
                 Consultas Compras
                </v-list-item-title>  
              </v-list-item-content> 
           </v-list-item>

           <v-list-item :to="{ name:''}"> 
             <v-list-item-action>
                <v-icon>bar_chart</v-icon> 
              </v-list-item-action>
              <v-list-item-content>
                 <v-list-item-title>
                 Consultas Ventas
                </v-list-item-title>  
              </v-list-item-content> 
           </v-list-item>
         </v-list-group>
       </template>

      </v-list>
    </v-navigation-drawer>


    <v-app-bar :clipped-left="$vuetify.breakpoint.lgAndUp" app color="blue darken-3" dark fixed>
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
      <v-toolbar-title style="width: 300px" class="ml-0 pl-4">
        <span class="hidden-sm-and-down">Sistema</span>
      </v-toolbar-title>
     
      <v-spacer />
      <v-btn icon>
        <v-icon>apps</v-icon>
      </v-btn>
      </v-app-bar>

    <v-content>
      <v-container class="fill-height" fluid>
        <v-row align="center" justify="center">
         <v-slide-y-transition mode="out-in">
           <router-view/>
        </v-slide-y-transition>
        </v-row>
      </v-container>
    </v-content>
    
    <v-footer blue height="auto">
      <v-layout justify-center>
        <v-flex  text-center>
          <v-card flat item color="primary" class="white--text">
          <v-card-text class="white--text pt-0"> 
            AbelGlez &copy;2018
          </v-card-text>
          </v-card>
        </v-flex>
      </v-layout>
    </v-footer>
 
  </v-app>
</template>

<script>
export default {
  name: 'App',
  data () {
    return {
      drawer: null,
    }
  }
}
</script>