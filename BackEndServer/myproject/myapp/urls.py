from django.urls import path
from . import views

urlpatterns = [
    path('api/processMomoCallBack/', views.processMoMoCallBack),
    path('',views.home),
    path('api/checkOrderStatus/',views.checkOrder),
]