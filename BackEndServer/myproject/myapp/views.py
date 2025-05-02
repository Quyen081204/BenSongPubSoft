from django.shortcuts import render
from django.http import HttpResponse, JsonResponse
import json

from django.views.decorators.csrf import csrf_exempt

from .models import Order

# Create your views here.
@csrf_exempt
def processMoMoCallBack(request):
    # Should verify the signature
    print('================ Enter process Momo callback =============')
    if request.method == 'POST':
        data = json.loads(request.body)
        print('Response from Momo')
        print(data)
        order_id = data.get("orderId")
        result_code = data.get("resultCode")

        new_order = Order.objects.create(order_id = order_id, result_code = result_code)
        if result_code == 0:
            new_order.status = True
            new_order.save()
        return HttpResponse(status=200)

    if request.method == 'GET':
        return HttpResponse("This process Momo callback api")

@csrf_exempt
def checkOrder(request):
    if request.method == 'POST':
        print("== Nhan dc Request tu winform")
        data = json.loads(request.body)
        order_id = data.get('order_id')
        #check
        order = Order.objects.filter(order_id=order_id).first()
        if order == None:
            return JsonResponse({"resultCode":-1, "status": False})

        return JsonResponse({"resultCode": order.result_code, "status":order.status})



def home(request):
    return HttpResponse("This is backend of Ben Song Pub")

