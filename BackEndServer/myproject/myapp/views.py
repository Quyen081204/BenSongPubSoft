from django.shortcuts import render
from django.http import HttpResponse, JsonResponse
import json
from .models import Order

# Create your views here.
def processMoMoCallBack(request):
    print('================ Enter server =============')
    if request.method == 'POST':
        data = json.loads(request.body)
        order_id = data.get("orderId")
        result_code = data.get("resultCode")

        new_order = Order.objects.create(order_id = order_id, result_code = result_code)
        if result_code == 0:
            new_order.status = True
            new_order.save()

def checkOrder(request):
    data = json.loads(request.body)
    order_id = data.get('order_id')
    #check
    order = Order.objects.filter(order_id=order_id)
    if not order.exist():
        return JsonResponse({"resultCode":-1})

    return JsonResponse({"resultCode": order.result_code})



def home(request):
    return HttpResponse("This is backend of Ben Song Pub")

