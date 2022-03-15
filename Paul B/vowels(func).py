def search4vowels(word:str)->set:
    """Выводит гласные, найденные в слове."""
    vowels=set('aeiou')
    return sorted(vowels.intersection(set(word)))
    
