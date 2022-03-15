def fast_exp(number, power):
    res = 1
    mult = number
    n = power
    while(n!=0):
        if n%2 == 1:
            res*=mult
        mult = mult * mult
        n=n//2
    return res
