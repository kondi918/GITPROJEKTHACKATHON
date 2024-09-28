import { createRouter, createWebHistory } from 'vue-router';
import CategoryPage from './components/pages/CategoryPage.vue';
import ShopPage from './components/pages/ShopPage.vue';

const routes = [
  {
    path: '/',
    name: 'CategoryPage',
    component: CategoryPage,
  },
  {
    path: '/shop',
    name: 'ShopPage',
    component: ShopPage,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
