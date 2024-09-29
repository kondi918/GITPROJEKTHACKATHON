import { createRouter, createWebHistory } from 'vue-router';
import HomePage from './components/pages/HomePage.vue';
import ShopPage from './components/pages/ShopPage.vue';
import QuizListPage from './components/pages/QuizListPage.vue';

const routes = [
  {
    path: '/',
    name: 'HomePage',
    component: HomePage,
  },
  {
    path: '/shop',
    name: 'ShopPage',
    component: ShopPage,
  },
  {
    path: '/category/:categoryName',
    name: 'QuizList',
    component: QuizListPage,
    props: true,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
