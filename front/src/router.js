// router.js
import { createRouter, createWebHistory } from 'vue-router';
import HomePage from './components/pages/HomePage.vue';
import ShopPage from './components/pages/ShopPage.vue';
import QuizListPage from './components/pages/QuizListPage.vue';
import ProfilePage from './components/pages/ProfilePage.vue';
import TakeQuizPage from './components/pages/TakeQuizPage.vue'; // Import nowego komponentu

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
  {
    path: '/quiz/:quizId',
    name: 'TakeQuiz',
    component: TakeQuizPage,
    props: true,
  },
  {
    path: '/profile',
    name: 'ProfilePage',
    component: ProfilePage
  }
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
