def bin_search(nums:list, target:int):
    """ list - numbers array, target - desired number"""
    if len(nums)==0:
        return "Empty array"
    l=0
    r=len(nums) 
    while l+1<r:
        m=l+(r-l)/2
        if m>target:
            r=m
        else:
            l=m     
    return  (nums.index(l),target) if l==target else "Target not in array"



