vowels=['a','o','e','i','u','y']
found=[]
word=input("Provide a word to search for vowels: ")
for letter in word:
    if letter in vowels:
        if letter not in found:
            found.append(letter)
            
for vowel in found:
    print(vowel)
