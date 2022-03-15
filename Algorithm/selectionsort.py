from random import randint

"""Создает массив рандомных чисел длиной 'length'
   с максимальным значением 'maxint'"""
def create_array(length=10,maxint=50):
    new_arr=[randint(0,maxint) for i in range(length)]
    return new_arr

def selection_sort(a):
    sort_len=0
    while sort_len<len(a):
        min_indx=None
        for i,elem in enumerate(a[sort_len:]):
            if min_indx==None or elem<a[min_indx]:
                min_indx=i+sort_len
        a[sort_len],a[min_indx]=a[min_indx], a[sort_len]
        sort_len+=1
    return a

a=create_array()
print('Unsorted:',a)
a=selection_sort(a)
print('Sorted',a)
