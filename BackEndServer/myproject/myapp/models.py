from django.db import models

# Create your models here.
class Order(models.Model):
    order_id = models.CharField(max_length=50)
    result_code = models.IntegerField()
    status = models.BooleanField(default=False)