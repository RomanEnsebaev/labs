from random import randint

"""Создает массив рандомных чисел длиной 'length'
   с максимальным значением 'maxint'"""
def create_array(length=10,maxint=50):
    new_arr=[randint(0,maxint) for i in range(length)]
    return new_arr

"""Производит сортировку методом пузырька"""
def bubble_sort(arr):
    swapped=True
    while swapped:
        swapped=False
        for i in range(1,len(arr)):
            if arr[i-1]>arr[i]:
                arr[i],arr[i-1]=arr[i-1],arr[i]
                swapped=True
    return arr

a=create_array()
print(a)
a=bubble_sort(a)
print(a)
            
