const routes=[
    {path:'/',component:provideService},
    {path:'/animals',component:animals},
    {path:'/clients',component:clients},
    {path:'/doctors',component:doctors},
    {path:'/services',component:services},
    {path:'/vaccinations',component:vaccinations},
    {path:'/provideService',component:provideService},

    
]

const router = VueRouter.createRouter({
    history: VueRouter.createWebHashHistory(),
    routes, // 
  })

  const app = Vue.createApp({})
  app.use(router)
  app.mount('#app')
  