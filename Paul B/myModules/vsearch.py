def search4vowels(phrase: str) -> set:
    """Выводит гласные, найденные в слове."""
    vowels = set('aeiou')
    return vowels.intersection(set(phrase))


def search4letters(phrase: str, letters: str='aeiou') -> set:
    """Выводит множество букв их 'letters', найденных в указанной фразе."""
    return set(letters).intersection(set(phrase))
    
