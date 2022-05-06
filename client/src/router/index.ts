import AdminLayout from "@/layout/admin-layout";
import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    name: "Home",
    component: () => import("../views/public/home/index.vue"),
  },
  {
    path: "/admin",
    name: "admin",
    component: AdminLayout,
    redirect: { name: "admin-article-category" },
    children: [
      {
        path: "category",
        name: "admin-article-category",
        component: () => import("../views/admin/article/tag/index.vue"),
      },
      {
        path: "tag",
        name: "admin-article-tag",
        component: () => import("../views/admin/article/tag/index.vue"),
      },
    ],
  },
];

const router = createRouter({
  routes,
  history: createWebHistory(),
});

export default router;
