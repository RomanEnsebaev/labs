vowels=set('aeiouy')
word=input("Provide a word to search for vowels: ")
found=sorted(vowels.intersection(set(word)))
for vowels in found:
    print(vowels)
