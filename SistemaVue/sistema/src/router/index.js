import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Categoria from '../components/Categoria.vue'
import Articulo from '../components/Articulo.vue'
import Rol from '../components/Rol.vue'
import Usuario from '../components/Usuario.vue'
import Cliente from '../components/Cliente.vue'
import Proveedor from '../components/Proveedor.vue'


Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: Home
  },
  {
    path: './categorias',
    name: 'categorias',
    component: Categoria
  },
  {
    path: './articulos',
    name: 'articulos',
    component: Articulo
  },
  
  {
    path: './roles',
    name: 'roles',
    component: Rol
  },
  {
    path: './usuarios',
    name: 'usuarios',
    component: Usuario
  },
  {
    path: './clientes',
    name: 'clientes',
    component: Cliente
  },
  {
    path: './proveedores',
    name: 'proveedores',
    component: Proveedor
  }

]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
